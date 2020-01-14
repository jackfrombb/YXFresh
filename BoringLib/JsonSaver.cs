using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace BoringLib
{
    class JsonSaver<T>
    {
        string file_path;

        public JsonSaver(string save_file_path)
        {
            file_path = save_file_path;
        }

        public void Save(T save)
        {
            File.WriteAllText(file_path, JsonConvert.SerializeObject(save));
        }

        public T Load()
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(file_path));
        }

        public bool IsSaveExist()
        {
            return File.Exists(file_path);
        }
    }
}
