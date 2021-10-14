using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptographies.Objects
{
    public class EnigmaInput
    {
        public List<int> Grundstellung { get; set; }
        public List<int> Walzenlage { get; set; }
        public char UmkherwalzeChoice { get; set; }
        public Dictionary<char,char> Steckerbrett { get; set; }
    }
}
