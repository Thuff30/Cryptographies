using System;
using System.Collections.Generic;
using Cryptographies.Objects;

namespace Cryptographies
{
    public static class Enigma
    {
        static char[] reference = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        public static string Encode(string userin, EnigmaInput input) {
            
            EnigmaSettings settings = new EnigmaSettings {
                walzenlage = input.Walzenlage,
                walzen1 = ShiftRotor(PopulateQueue(input.Walzenlage[0]), input.Grundstellung[0]),
                walzen2 = ShiftRotor(PopulateQueue(input.Walzenlage[1]), input.Grundstellung[1]),
                walzen3 = ShiftRotor(PopulateQueue(input.Walzenlage[2]), input.Grundstellung[2]),
                turnover = WalzenWende(input.Walzenlage),
                positions = input.Grundstellung,
                umkehrwalze = AssignUmkehrwalze(Char.ToUpper(input.UmkherwalzeChoice)),
                steckerbrett = Steckerverbindungen(input.Steckerbrett, reference)
            };

            string output = EnigmaFunctions.Encode(settings, userin);
            return output;
        }

        public static string Decode(string userin, EnigmaInput input)
        {

            EnigmaSettings settings = new EnigmaSettings
            {
                walzenlage = input.Walzenlage,
                walzen1 = ShiftRotor(PopulateQueue(input.Walzenlage[0]), input.Grundstellung[0]),
                walzen2 = ShiftRotor(PopulateQueue(input.Walzenlage[1]), input.Grundstellung[1]),
                walzen3 = ShiftRotor(PopulateQueue(input.Walzenlage[2]), input.Grundstellung[2]),
                turnover = WalzenWende(input.Walzenlage),
                positions = input.Grundstellung,
                umkehrwalze = AssignUmkehrwalze(Char.ToUpper(input.UmkherwalzeChoice)),
                steckerbrett = Steckerverbindungen(input.Steckerbrett, reference)
            };

            string output = EnigmaFunctions.Decode(settings, userin);
            return output;
        }

        //Returns a queue that will act as the rotors
        static Queue<KeyValuePair<char, char>> PopulateQueue(int rotorNum)
        {
            char[] array = AssignArray(rotorNum);
            Queue<KeyValuePair<char, char>> rotor = new Queue<KeyValuePair<char, char>>();

            for (int i = 0; i < array.Length; i++)
            {
                rotor.Enqueue(new KeyValuePair<char,char>(reference[i],array[i]));
            }
            return rotor;
        }

        //Determines which array should be used to represent the internal wiring of the rotors based on the rotors selected
        static char[] AssignArray(int rotorNum)
        {
            char[] wiring = new char[26];
            switch (rotorNum)
            {
                case 1:
                    wiring = new char[] { 'E', 'K', 'M', 'F', 'L', 'G', 'D', 'Q', 'V', 'Z', 'N', 'T', 'O', 'W', 'Y', 'H', 'X', 'U', 'S', 'P', 'A', 'I', 'B', 'R', 'C', 'J' };
                    break;
                case 2:
                    wiring = new char[] { 'A', 'J', 'D', 'K', 'S', 'I', 'R', 'U', 'X', 'B', 'L', 'H', 'W', 'T', 'M', 'C', 'Q', 'G', 'Z', 'N', 'P', 'Y', 'F', 'V', 'O', 'E' };
                    break;
                case 3:
                    wiring = new char[] { 'B', 'D', 'F', 'H', 'J', 'L', 'C', 'P', 'R', 'T', 'X', 'V', 'Z', 'N', 'Y', 'E', 'I', 'W', 'G', 'A', 'K', 'M', 'U', 'S', 'Q', 'O' };
                    break;
                case 4:
                    wiring = new char[] { 'E', 'S', 'O', 'V', 'P', 'Z', 'J', 'A', 'Y', 'Q', 'U', 'I', 'R', 'H', 'X', 'L', 'N', 'F', 'T', 'G', 'K', 'D', 'C', 'M', 'W', 'B' };
                    break;
                case 5:
                    wiring = new char[] { 'V', 'Z', 'B', 'R', 'G', 'I', 'T', 'Y', 'U', 'P', 'S', 'D', 'N', 'H', 'L', 'X', 'A', 'W', 'M', 'J', 'Q', 'O', 'F', 'E', 'C', 'K' };
                    break;
                case 6:
                    wiring = new char[] { 'J', 'P', 'G', 'V', 'O', 'U', 'M', 'F', 'Y', 'Q', 'B', 'E', 'N', 'H', 'Z', 'R', 'D', 'K', 'A', 'S', 'X', 'L', 'I', 'C', 'T', 'W' };
                    break;
                case 7:
                    wiring = new char[] { 'N', 'Z', 'J', 'H', 'G', 'R', 'C', 'X', 'M', 'Y', 'S', 'W', 'B', 'O', 'U', 'F', 'A', 'I', 'V', 'L', 'P', 'E', 'K', 'Q', 'D', 'T' };
                    break;
                case 8:
                    wiring = new char[] { 'F', 'K', 'Q', 'H', 'T', 'L', 'X', 'O', 'C', 'B', 'J', 'S', 'P', 'D', 'Z', 'R', 'A', 'M', 'E', 'W', 'N', 'I', 'U', 'Y', 'G', 'V' };
                    break;
            }

            return wiring;
        }

        //Returns a dictionary containing the positions at which the rotors should trigger the next rotor in the series to move one notch 
        static Dictionary<int, int> WalzenWende(List<int> walzenlage)
        {
            Dictionary<int, int> turnover = new Dictionary<int, int>();

            foreach(var walzen in walzenlage)
            {
                int tempnum = 0;
                int tempnum2 = 0;

                //Determine which walzen have been used
                switch (walzen)
                {
                    case 1:
                        tempnum = 17;
                        break;
                    case 2:
                        tempnum = 5;
                        break;
                    case 3:
                        tempnum = 22;
                        break;
                    case 4:
                        tempnum = 10;
                        break;
                    case 5:
                        tempnum = 0;
                        break;
                    case 6:
                    case 7:
                    case 8:
                        tempnum = 0;
                        tempnum2 = 13;
                        break;
                }

                //Assign turnover values for the walzen
                turnover.Add(walzen,tempnum);
                if (tempnum2 != 0)
                {
                    turnover.Add(-(walzen), tempnum2);
                }
            }
            return turnover;
        }

        //Returns a list representing the wiring of the chosen reflector
        static List<char> AssignUmkehrwalze(char umkehrwalzeChoice)
        {
            List<char> umkerhwalze = new List<char>();
            switch (umkehrwalzeChoice)
            {
                case 'B':
                    umkerhwalze = new List<char> { 'Y', 'R', 'U', 'H', 'Q', 'S', 'L', 'D', 'P', 'X', 'N', 'G', 'O', 'K', 'M', 'I', 'E', 'B', 'F', 'Z', 'C', 'W', 'V', 'J', 'A', 'T' };
                    break;
                case 'C':
                    umkerhwalze = new List<char> { 'F', 'V', 'P', 'J', 'I', 'A', 'O', 'Y', 'E', 'D', 'R', 'Z', 'X', 'W', 'G', 'C', 'T', 'K', 'U', 'Q', 'S', 'B', 'N', 'M', 'H', 'L' };
                    break;
            }
            return umkerhwalze;
        }

        //Shifts a rotor a predetermined number of positions
        static Queue<KeyValuePair<char, char>> ShiftRotor(Queue<KeyValuePair<char, char>> rotor, int shiftNum)
        {
            for (int i = 0; i < shiftNum; i++)
            {
                var tempNum = rotor.Dequeue();
                rotor.Enqueue(tempNum);
            }
            return rotor;
        }

        //Returns a dictionary containing the connections on the plugboard
        static Dictionary<char, int> Steckerverbindungen(Dictionary<char, char> steckerbrett, char[] reference)
        {
            Dictionary<char, int> stecker = new Dictionary<char, int>();

            foreach (var pair in steckerbrett)
            {
                stecker.Add(pair.Key, Array.IndexOf(reference, Char.ToUpper(pair.Value)));
            }

            foreach(var letter in reference)
            {
                int test;
                if (!stecker.TryGetValue(letter, out test))
                {
                    stecker.Add(letter, Array.IndexOf(reference, letter));
                }
            }
            return stecker;
        }
    }
}
