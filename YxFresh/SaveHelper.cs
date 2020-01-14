using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace YxFresh
{
    public class SaveHelper
    {
        const string file_path = "save";

        public SaveHelper()
        {
            
        }

        public void Save(YXFSave save)
        {
            File.WriteAllText(file_path, JsonConvert.SerializeObject(save));
        }

        public YXFSave Load()
        {
            return JsonConvert.DeserializeObject<YXFSave>(File.ReadAllText(file_path));
        }

        public bool IsSaveExist()
        {
            return File.Exists(file_path);
        }

        public class YXFSave
        {
            public string pdd_token = "";
            public List<string> domains_row = new List<string>();
            public string tenda_username = "";
            public string tenda_password = "";
            public string tenda_host = "http://tendawifi.com";
        }
    }
}
