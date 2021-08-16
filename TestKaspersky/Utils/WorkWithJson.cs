using System.IO;
using Newtonsoft.Json;

namespace TestKaspersky.Utils
{
    public class WorkWithJson
    {
        public static TestData JsonToTestData()
        {
            TestData data = JsonConvert.DeserializeObject<TestData>(File.ReadAllText(@"Resources\testdata.json"));
            return data;
        }

        public static SettingsData JsonToSetting()
        {
            SettingsData data = JsonConvert.DeserializeObject<SettingsData>(File.ReadAllText(@"Resources\settings.json"));
            return data;
        }
    }
}
