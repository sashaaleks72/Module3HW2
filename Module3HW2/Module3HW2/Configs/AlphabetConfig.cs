using System.Collections.Generic;

namespace Module3HW2
{
    public class AlphabetConfig
    {
        public AlphabetConfig()
        {
            Alphabets = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Alphabets { get; set; }
    }
}
