using System.Collections.Generic;

namespace Cryptographies
{
    public class EnigmaSettings
    {
        public List<int> walzenlage { get; set; }
        public Queue<KeyValuePair<char, char>> walzen1 { get; set; }
        public Queue<KeyValuePair<char, char>> walzen2 { get; set; }
        public Queue<KeyValuePair<char, char>> walzen3 { get; set; }
        public Dictionary<int, int> turnover { get; set; }
        public List<int> positions { get; set; }
        public List<char> umkehrwalze { get; set; }
        public Dictionary<char, int> steckerbrett { get; set; }

    }
}
