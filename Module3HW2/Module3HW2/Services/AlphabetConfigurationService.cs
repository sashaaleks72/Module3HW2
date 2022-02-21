using System.IO;
using Newtonsoft.Json;

namespace Module3HW2
{
    public class AlphabetConfigurationService : IAlphabetConfigurationService
    {
        public void SerializeAlphabetConfig(AlphabetConfig alphabetConfig, string jsonFilePath = @"C:\Users\sasha\source\repos\Module3HW2\Module3HW2\Module3HW2\Configs\alphabet-config.json")
        {
            string serializedObject = JsonConvert.SerializeObject(alphabetConfig);
            File.WriteAllText(jsonFilePath, serializedObject);
        }

        public AlphabetConfig DeserializeAlphabetConfig(string jsonFilePath = @"C:\Users\sasha\source\repos\Module3HW2\Module3HW2\Module3HW2\Configs\alphabet-config.json")
        {
            return JsonConvert.DeserializeObject<AlphabetConfig>(File.ReadAllText(jsonFilePath));
        }
    }
}
