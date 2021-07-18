using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cryptographies
{
    static class EnigmaFunctions
    {
        public static string Encode(EnigmaSettings enigma, string userin)
        {
            char[] reference = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] input = userin.ToArray();
            char tempLet;
            char letterOut;
            StringBuilder sb = new StringBuilder();
            foreach (var letter in input)
            {
                enigma = ShiftRotors(enigma);
                KeyValuePair<char, char>[] walzen1 = enigma.walzen1.ToArray();
                KeyValuePair<char, char>[] walzen2 = enigma.walzen2.ToArray();
                KeyValuePair<char, char>[] walzen3 = enigma.walzen3.ToArray();
                if (!Char.IsWhiteSpace(letter))
                {

                    var tempValue = enigma.steckerbrett.FirstOrDefault(x=> x.Key == letter).Value;
                    var tempValue2 = walzen1[tempValue].Value;
                    tempValue = FindIndex(walzen1, tempValue2);
                    tempValue2 = walzen2[tempValue].Value;
                    tempValue = FindIndex(walzen2, tempValue2);
                    tempValue2 = walzen3[tempValue].Value;
                    tempValue = FindIndex(walzen3, tempValue2);
                    tempValue2 = enigma.umkehrwalze[tempValue];
                    tempValue = Array.IndexOf(reference, tempValue2);
                    tempValue2 = walzen3[tempValue].Key;
                    var tempValue3 = walzen3.FirstOrDefault(x => x.Value == tempValue2).Key;
                    tempValue = FindIndex(walzen3, tempValue3);
                    tempValue2 = walzen2[tempValue].Key;
                    tempValue3 = walzen2.FirstOrDefault(x => x.Value == tempValue2).Key;
                    tempValue = FindIndex(walzen2, tempValue3);
                    tempValue2 = walzen1[tempValue].Key;
                    tempValue3 = walzen1.FirstOrDefault(x => x.Value == tempValue2).Key;
                    tempValue = FindIndex(walzen1, tempValue3);
                    letterOut = enigma.steckerbrett.FirstOrDefault(x => x.Value == tempValue).Key;
                    sb.Append(letterOut);
                }
                else
                {
                    sb.Append(letter);
                }
            }
            return sb.ToString();
        }

        static int FindIndex(KeyValuePair<char, char>[] walzen, char value) 
        {
            int pos = 0;
            foreach(var pair in walzen)
            {
                if(pair.Key == value)
                {
                    break;
                }
                pos++;
            }
            return pos;
        }
        
        static EnigmaSettings ShiftRotors(EnigmaSettings enigma)
        {

            var tempNum = enigma.walzen1.Dequeue();
            enigma.walzen1.Enqueue(tempNum);
            //Check if rotor has reached the final notch
            if (enigma.positions[0] < 25)
            {
                enigma.positions[0]++;
            }
            else
            {
                enigma.positions[0] = 0;
            }

            int notch;
            int notch2;
            enigma.turnover.TryGetValue(enigma.walzenlage[0], out notch);
            enigma.turnover.TryGetValue(-(enigma.walzenlage[0]), out notch2);

            //Check if the first walzen is at the correct notch to move next walzen
            if (enigma.positions[0] == notch || enigma.positions[0] == notch2)
            {
                tempNum = enigma.walzen2.Dequeue();
                enigma.walzen2.Enqueue(tempNum);
                //Check if rotor has reached the final notch
                if (enigma.positions[1] < 25)
                {
                    enigma.positions[1]++;
                }
                else
                {
                    enigma.positions[1] = 0;
                }

                enigma.turnover.TryGetValue(enigma.walzenlage[1], out notch);
                enigma.turnover.TryGetValue(-(enigma.walzenlage[1]), out notch2);

                //Check if the first walzen is at the correct notch to move next walzen
                if (enigma.positions[1] == notch || enigma.positions[1] == notch2)
                {
                    tempNum = enigma.walzen3.Dequeue();
                    enigma.walzen3.Enqueue(tempNum);
                }
            }

            return enigma;
        }
    }
}
