using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskPart1.Utils
{
    public class JsonUtil
    {
        public static List<T> ReadJsonData<T>(string jsonDataFile)
        {
            string jsonFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\GitProjects\MarsAdvancedTaskPart1\AdvanceTaskPart1\bin\Debug\net8.0\TestData\" + jsonDataFile);
            string jPath = Path.GetFullPath(jsonFilePath);
            string jsonData = File.ReadAllText(jPath);
            List<T> values = JsonConvert.DeserializeObject<List<T>>(jsonData);
            return values;
        }
    }
}
