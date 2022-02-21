namespace Module3HW2
{
    public interface IAlphabetConfigurationService
    {
        public void SerializeAlphabetConfig(AlphabetConfig alphabetConfig, string jsonFilePath);
        public AlphabetConfig DeserializeAlphabetConfig(string jsonFilePath);
    }
}
