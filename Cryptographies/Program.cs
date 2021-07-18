using System;
using System.Collections.Generic;

namespace Cryptographies
{
    class Program
    {
        static void Main(string[] args)
        {
            string output = "";
            string key = "";
            int shift = 0;
            List<string> caesarVariants = new List<string> { "caesar shift cipher", "caesar shift", "caesar" };
            List<string> vigenereVariants = new List<string> { "vigenere's", "vigenere's cipher", "vigeneres", "vigeneres cipher" };
            List<string> enigmaVariants = new List<string> { "enigma", "enigma cipher", "enigma's cipher" };
            Dictionary<char, char> steckerbrett = new Dictionary<char, char>();
            List<int> grundstellung = new List<int>();
            List<int> walzenlage = new List<int>();
            char umkehrwalzeChoice = ' ';

            Console.WriteLine("Would you like to use a Vigenere's Cipher, Caesar Shift Cipher, or Enigma Cipher?");
            string cipher = Console.ReadLine().ToLower();

            Console.WriteLine("Would you like to encode or decode an message?");
            string choice = Console.ReadLine().ToLower();


            char[] reference = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            if (choice == "encode")
            {
                Console.WriteLine("Please enter a message to encode:");
            }
            else
            {
                Console.WriteLine("please enter a message to decode:");
            }
            string userin = Console.ReadLine();

            if (caesarVariants.Contains(cipher) || vigenereVariants.Contains(cipher)) {
                Console.WriteLine("Please enter the number key of the shift:");
                shift = Int32.Parse(Console.ReadLine());
            }
            if (enigmaVariants.Contains(cipher))
            {
                Console.WriteLine("Please choose 3 Walzen (rotors) to use in the Enigma Machine by entering numbers between 1 and 8 separated by commas:");
                string walzenlageString = Console.ReadLine();
                Console.WriteLine("Please enter the letter to be displayed for reach rotors starting position separated by commas:");
                string grundstellungstring = Console.ReadLine().Trim().ToUpper();
                Console.WriteLine("Please choose reflector B or C:");
                string umkehrwalzeChoiceString = Console.ReadLine().Trim().ToUpper();
                umkehrwalzeChoice = umkehrwalzeChoiceString[0];
                Console.WriteLine("Please enter up to 10 pairs of letters, separated by commas, to represent the cable connections on the plug board. " +
                    "Note that letters can not be repeated (ie. if one combination is TU another combination cannot be VT because T has already been connected to U).");
                string steckerbrettString = Console.ReadLine().Trim().ToUpper();
                
                foreach(var walzen in walzenlageString.Split(','))
                {
                    walzenlage.Add(Int32.Parse(walzen.Trim()));
                }

                foreach(var setting in grundstellungstring.ToUpper().Trim().ToCharArray())
                {
                    if (!Char.IsPunctuation(setting))
                    {
                        
                        grundstellung.Add(Array.IndexOf(reference, setting));
                    }
                }

                foreach (var plug in steckerbrettString.Split(','))
                {
                    char[] plugarray = plug.ToCharArray();
                    steckerbrett.Add(plugarray[0], plugarray[1]);
                    steckerbrett.Add(plugarray[1], plugarray[0]);
                }
            }

            if (vigenereVariants.Contains(cipher))
            {
                Console.WriteLine("Please enter the key phrase:");
                key = Console.ReadLine().ToLower();
            }

            if(choice == "encode")
            {
                if (caesarVariants.Contains(cipher))
                {
                    output = CaeserShift.Encode(userin, shift);
                }
                else if (vigenereVariants.Contains(cipher))
                {
                    output = Vigenere.Encode(userin, key, shift);
                }
                else
                {
                    output = Enigma.Encode(userin, grundstellung, walzenlage, umkehrwalzeChoice, steckerbrett);
                }
            }
            else
            {
                if (caesarVariants.Contains(cipher))
                {
                    output = CaeserShift.Decode(userin, shift);
                }
                else
                {
                    output = Vigenere.Decode(userin, key, shift);
                }
            }
            Console.WriteLine(output);
        }
    }
}
