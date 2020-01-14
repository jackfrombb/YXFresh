namespace YxFresh
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.start_observe_btn = new System.Windows.Forms.Button();
            this.yandex_group = new System.Windows.Forms.GroupBox();
            this.domains_textbox = new System.Windows.Forms.TextBox();
            this.domains_name_label = new System.Windows.Forms.Label();
            this.pdd_token_textbox = new System.Windows.Forms.TextBox();
            this.pdd_token_label = new System.Windows.Forms.Label();
            this.tenda_group = new System.Windows.Forms.GroupBox();
            this.tenda_host_textbox = new System.Windows.Forms.TextBox();
            this.host_label = new System.Windows.Forms.Label();
            this.tenda_password_textbox = new System.Windows.Forms.TextBox();
            this.tenda_password_label = new System.Windows.Forms.Label();
            this.tenda_username_textbox = new System.Windows.Forms.TextBox();
            this.tenda_username_label = new System.Windows.Forms.Label();
            this.log_textbox = new System.Windows.Forms.TextBox();
            this.yandex_group.SuspendLayout();
            this.tenda_group.SuspendLayout();
            this.SuspendLayout();
            // 
            // start_observe_btn
            // 
            this.start_observe_btn.Location = new System.Drawing.Point(571, 309);
            this.start_observe_btn.Name = "start_observe_btn";
            this.start_observe_btn.Size = new System.Drawing.Size(264, 84);
            this.start_observe_btn.TabIndex = 0;
            this.start_observe_btn.Text = "Старт";
            this.start_observe_btn.UseVisualStyleBackColor = true;
            this.start_observe_btn.Click += new System.EventHandler(this.Start_observe_btn_Click);
            // 
            // yandex_group
            // 
            this.yandex_group.Controls.Add(this.pdd_token_textbox);
            this.yandex_group.Controls.Add(this.pdd_token_label);
            this.yandex_group.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.yandex_group.Location = new System.Drawing.Point(12, 12);
            this.yandex_group.Name = "yandex_group";
            this.yandex_group.Size = new System.Drawing.Size(823, 91);
            this.yandex_group.TabIndex = 1;
            this.yandex_group.TabStop = false;
            this.yandex_group.Text = "Яндекс";
            // 
            // domains_textbox
            // 
            this.domains_textbox.Location = new System.Drawing.Point(12, 226);
            this.domains_textbox.Multiline = true;
            this.domains_textbox.Name = "domains_textbox";
            this.domains_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.domains_textbox.Size = new System.Drawing.Size(823, 77);
            this.domains_textbox.TabIndex = 3;
            // 
            // domains_name_label
            // 
            this.domains_name_label.AutoSize = true;
            this.domains_name_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.domains_name_label.Location = new System.Drawing.Point(19, 203);
            this.domains_name_label.Name = "domains_name_label";
            this.domains_name_label.Size = new System.Drawing.Size(419, 20);
            this.domains_name_label.TabIndex = 2;
            this.domains_name_label.Text = "Домены для отслеживания [Имя домена] [id записи] ...";
            // 
            // pdd_token_textbox
            // 
            this.pdd_token_textbox.Location = new System.Drawing.Point(11, 49);
            this.pdd_token_textbox.Name = "pdd_token_textbox";
            this.pdd_token_textbox.Size = new System.Drawing.Size(791, 26);
            this.pdd_token_textbox.TabIndex = 1;
            // 
            // pdd_token_label
            // 
            this.pdd_token_label.AutoSize = true;
            this.pdd_token_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pdd_token_label.Location = new System.Drawing.Point(7, 26);
            this.pdd_token_label.Name = "pdd_token_label";
            this.pdd_token_label.Size = new System.Drawing.Size(91, 20);
            this.pdd_token_label.TabIndex = 0;
            this.pdd_token_label.Text = "PDD Token";
            // 
            // tenda_group
            // 
            this.tenda_group.Controls.Add(this.tenda_host_textbox);
            this.tenda_group.Controls.Add(this.host_label);
            this.tenda_group.Controls.Add(this.tenda_password_textbox);
            this.tenda_group.Controls.Add(this.tenda_password_label);
            this.tenda_group.Controls.Add(this.tenda_username_textbox);
            this.tenda_group.Controls.Add(this.tenda_username_label);
            this.tenda_group.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tenda_group.Location = new System.Drawing.Point(12, 109);
            this.tenda_group.Name = "tenda_group";
            this.tenda_group.Size = new System.Drawing.Size(823, 91);
            this.tenda_group.TabIndex = 4;
            this.tenda_group.TabStop = false;
            this.tenda_group.Text = "Tenda";
            // 
            // tenda_host_textbox
            // 
            this.tenda_host_textbox.Location = new System.Drawing.Point(11, 49);
            this.tenda_host_textbox.Name = "tenda_host_textbox";
            this.tenda_host_textbox.Size = new System.Drawing.Size(299, 26);
            this.tenda_host_textbox.TabIndex = 5;
            this.tenda_host_textbox.Text = "http://tendawifi.com";
            // 
            // host_label
            // 
            this.host_label.AutoSize = true;
            this.host_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.host_label.Location = new System.Drawing.Point(7, 26);
            this.host_label.Name = "host_label";
            this.host_label.Size = new System.Drawing.Size(57, 20);
            this.host_label.TabIndex = 4;
            this.host_label.Text = "Адрес";
            // 
            // tenda_password_textbox
            // 
            this.tenda_password_textbox.Location = new System.Drawing.Point(550, 49);
            this.tenda_password_textbox.Name = "tenda_password_textbox";
            this.tenda_password_textbox.Size = new System.Drawing.Size(252, 26);
            this.tenda_password_textbox.TabIndex = 3;
            this.tenda_password_textbox.UseSystemPasswordChar = true;
            // 
            // tenda_password_label
            // 
            this.tenda_password_label.AutoSize = true;
            this.tenda_password_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tenda_password_label.Location = new System.Drawing.Point(546, 22);
            this.tenda_password_label.Name = "tenda_password_label";
            this.tenda_password_label.Size = new System.Drawing.Size(67, 20);
            this.tenda_password_label.TabIndex = 2;
            this.tenda_password_label.Text = "Пароль";
            // 
            // tenda_username_textbox
            // 
            this.tenda_username_textbox.Location = new System.Drawing.Point(316, 49);
            this.tenda_username_textbox.Name = "tenda_username_textbox";
            this.tenda_username_textbox.Size = new System.Drawing.Size(228, 26);
            this.tenda_username_textbox.TabIndex = 1;
            // 
            // tenda_username_label
            // 
            this.tenda_username_label.AutoSize = true;
            this.tenda_username_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tenda_username_label.Location = new System.Drawing.Point(312, 22);
            this.tenda_username_label.Name = "tenda_username_label";
            this.tenda_username_label.Size = new System.Drawing.Size(55, 20);
            this.tenda_username_label.TabIndex = 0;
            this.tenda_username_label.Text = "Логин";
            // 
            // log_textbox
            // 
            this.log_textbox.Location = new System.Drawing.Point(12, 309);
            this.log_textbox.Multiline = true;
            this.log_textbox.Name = "log_textbox";
            this.log_textbox.ReadOnly = true;
            this.log_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.log_textbox.Size = new System.Drawing.Size(553, 84);
            this.log_textbox.TabIndex = 5;
            // 
            // MainWindow
            // 
            this.ClientSize = new System.Drawing.Size(847, 405);
            this.Controls.Add(this.domains_name_label);
            this.Controls.Add(this.domains_textbox);
            this.Controls.Add(this.log_textbox);
            this.Controls.Add(this.tenda_group);
            this.Controls.Add(this.yandex_group);
            this.Controls.Add(this.start_observe_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "YXFresher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyUp);
            this.yandex_group.ResumeLayout(false);
            this.yandex_group.PerformLayout();
            this.tenda_group.ResumeLayout(false);
            this.tenda_group.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_observe_btn;
        private System.Windows.Forms.GroupBox yandex_group;
        private System.Windows.Forms.Label pdd_token_label;
        private System.Windows.Forms.TextBox pdd_token_textbox;
        private System.Windows.Forms.TextBox domains_textbox;
        private System.Windows.Forms.Label domains_name_label;
        private System.Windows.Forms.GroupBox tenda_group;
        private System.Windows.Forms.TextBox tenda_password_textbox;
        private System.Windows.Forms.Label tenda_password_label;
        private System.Windows.Forms.TextBox tenda_username_textbox;
        private System.Windows.Forms.Label tenda_username_label;
        private System.Windows.Forms.TextBox log_textbox;
        private System.Windows.Forms.TextBox tenda_host_textbox;
        private System.Windows.Forms.Label host_label;
    }
}

