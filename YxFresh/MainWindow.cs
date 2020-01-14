using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using static YxFresh.SaveHelper;
using YX_lib;
using static YX_lib.TendaHelper;
using static YX_lib.YandexHelper;

namespace YxFresh
{
    public partial class MainWindow : Form
    {
        YandexHelper yandex;
        SaveHelper saver;
        YXFSave save;
        TimerCallback callbackTimer;
        System.Windows.Forms.Timer timer;

        Color logNormal;
        Color logError;

        bool started = false;

        public MainWindow()
        {
            InitializeComponent();
            BtnShowStart();
            
            saver = new SaveHelper();

            if (saver.IsSaveExist())
            {
                YXFSave saves = saver.Load();
                save = saves;
                pdd_token_textbox.Text = saves.pdd_token;
                domains_textbox.Text = string.Join("\n", saves.domains_row);
                tenda_host_textbox.Text = saves.tenda_host;
                tenda_username_textbox.Text = saves.tenda_username;
                tenda_password_textbox.Text = saves.tenda_password;
            }
            else
            {
                save = new YXFSave();
            }

            timer = new System.Windows.Forms.Timer();
            timer.Enabled = false;
            timer.Interval = 60000;
            timer.Tick += doFresh;

            logNormal = log_textbox.BackColor;
            logError = Color.Red;
        }

        private void Start_observe_btn_Click(object sender, EventArgs e)
        {
            doSave();

            if (started)
            {
                started = false;
                BtnShowStart();
                timer.Stop();
            }
            else
            {
                yandex = new YandexHelper(save.pdd_token);
                started = true;
                BtnShowStop();
                doFresh(null, null);
                timer.Enabled = true;
                timer.Start();
                
            }
        }

        ///<summary>
        ///Показать Старт
        ///</summary>
        private void BtnShowStart()
        {
            start_observe_btn.Text = "Старт";
            start_observe_btn.BackColor = Color.FromArgb(212, 255, 221);
        }

        ///<summary>
        ///Показать Стоп
        ///</summary>
        private void BtnShowStop()
        {
            start_observe_btn.Text = "Стоп";
            start_observe_btn.BackColor = Color.FromArgb(255, 222, 212);
        }

        ///
        /// <summary>
        /// Сохранить значения полей и данные программы
        /// </summary>
        private void doSave()
        {

            save.pdd_token = pdd_token_textbox.Text;
            save.tenda_username = tenda_username_textbox.Text;
            save.tenda_password = tenda_password_textbox.Text;
            save.tenda_host = tenda_host_textbox.Text;

            save.domains_row.Clear();
            save.domains_row.AddRange(domains_textbox.Text.Split('\n'));

            saver.Save(save);
        }

        public static async Task<RefreshResult> RefreshAsync(object obj)
        {
            //Полуение данных
            YXFSave save = (YXFSave)obj;
            //Отчёт об успешности
            RefreshResult result = new RefreshResult();

            YandexHelper yandex = new YandexHelper(save.pdd_token);
            TendaHelper tenda = new TendaHelper(host:save.tenda_host, 
                username:save.tenda_username, password:save.tenda_password);
            

            string status = "";

            status = DateTime.Now.ToString() + "\r\n";

            try
            {
                await tenda.Login();

                //Получаем IP
                RouterInfo info = await tenda.GetStatus();

                //Если IP получены
                if (info != null)
                {
                    //Сверяем внутренний IP с внешним
                    if (info.externalIP.Length > 0)
                    {
                        if (info.externalIP.CompareTo(info.wanInfo[0].wanIp) != 0)
                        {
                            string err_str = $"IP не совпали. Внутренний: {info.wanInfo[0].wanIp} \nВнешний: {info.externalIP}";
                            status = err_str;
                            Console.WriteLine(err_str);

                            result.Success = false;
                            result.ResultMsg = status;
                            result.ResultErrorMsg = status;

                            if(await tenda.DisconnectWan1())
                            {
                                Console.WriteLine("Wan1 отключен");
                                Thread.Sleep(100);

                                if(await tenda.ConnectWan1())
                                {
                                    Console.WriteLine("Wan1 начало подключения");
                                }
                                else
                                {
                                    Console.WriteLine("Wan1 ошибка подключения");
                                }
                            }

                            return result;
                        }
                    }

                    //Добавляем актуальный IP
                    string ip_msg = $"IP: {info.wanInfo[0].wanIp} \r\n";
                    Console.WriteLine(ip_msg);
                    status += ip_msg;

                    //Цикл проверки и обновления доменов
                    foreach (var domain_and_rec in save.domains_row)
                    {
                        //Извлекаем домен и ид необходимых записей
                        string domain = domain_and_rec.Split(' ')[0];
                        string[] rec_ids = domain_and_rec.Split(' ').Skip<string>(1).ToArray();

                        status += $"{domain}: ";

                        //Цикл для введёных пользователем записей
                        foreach (var rec_id in rec_ids)
                        {
                            //Получаем необходимую запись из серверов яндекса
                            var allRecords = await yandex.GetDomainRecords(domain);

                            int found_id;
                            RecordInfo record = null;

                            //Пробуем найти актуальную запись из яндекса
                            try
                            {
                                record = (from r in allRecords.records
                                          where int.TryParse(rec_id, out found_id) && r.record_id == found_id
                                          select r).First();
                            }
                            catch {

                                status += $"[{rec_id} ошибка преобразования] ";
                                continue;
                            }

                            //Если запись найдена
                            if (record != null )
                            {
                                //Если запись содержит другой ИП
                                if (!record.content.Contains(info.wanInfo[0].wanIp))
                                {
                                    if (await yandex.RefreshARecord(domain, rec_id, info.wanInfo[0].wanIp))
                                    {
                                        status += $"[{rec_id} обновлена] ";
                                    }
                                    else
                                    {
                                        status += $"[{rec_id} ошибка] ";
                                    }
                                }
                                else
                                {
                                    status += $"[{rec_id} актуальна] ";
                                }
                            }
                            else
                            {
                                status += $"[{rec_id} не найдена] ";
                            }
                            
                        }

                        status += " \r\n";
                    }

                }

                result.Success = true;

                await tenda.Logout();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Ошибка обновления");
                Console.WriteLine(ex.StackTrace);

                result.ResultErrorMsg = ex.Message;
                result.Success = false;
            }
            
            result.ResultMsg = status;

            return result;

        }

        public async void doFresh(Object sender, EventArgs e)
        {
            var result = await RefreshAsync(save);
            log_textbox.Text = result.ResultMsg;

            if (result.Success) log_textbox.BackColor = logNormal;
            else log_textbox.BackColor = logError;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            doSave();
        }

        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                start_observe_btn.Select();
            }
        }
    }
}
