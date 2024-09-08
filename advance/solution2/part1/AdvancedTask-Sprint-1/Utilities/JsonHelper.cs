using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Task_1.Utilities
{

    public class JsonHelper
    {
        public static List<T> ReadTestDataFromJson<T>(string jsonFilePath)
        {
#pragma warning disable CS8600
            string jsonContent = File.ReadAllText(jsonFilePath);
            List<T> testData = JsonConvert.DeserializeObject<List<T>>(jsonContent);
            return testData;
        }
    }
}
