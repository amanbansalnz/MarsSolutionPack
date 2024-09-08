using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AdvanceTask_Sprint2.Utilities
{
    public class JsonHelper
    {
            public static List<T> ReadTestDataFromJson<T>(string jsonFilePath)
            {
                string jsonContent = File.ReadAllText(jsonFilePath);
                List<T> testData = JsonConvert.DeserializeObject<List<T>>(jsonContent);
                return testData;
            }
        }
    }

