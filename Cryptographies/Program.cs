using System;
using System.Collections.Generic;

namespace Cryptographies
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Would you like to use a Vigenere's Cipher or Caeser Shift Cipher?");
            string cipher = Console.ReadLine().ToLower();
            Console.WriteLine("Would you like to encode or decode an message?");
            string choice = Console.ReadLine().ToLower();
            string output = "";
            string key = "";
            List<string> caeserVariants = new List<string> { "caeser shift cipher", "caeser shift", "caeser" };
            List<string> vigenereVariants = new List<string> { "vigenere's", "vigenere's cipher", "vigeneres", "vigeneres cipher" };
            if (choice == "encode")
            {
                Console.WriteLine("Please enter a message to encode:");
            }
            else
            {
                Console.WriteLine("please enter a message to decode:");
            }
            string userin = Console.ReadLine();
            Console.WriteLine("Please enter the number key of the shift:");
            int shift = Int32.Parse(Console.ReadLine());
            if (cipher == "vigenere's cipher" || cipher == "vigenere's")
            {
                Console.WriteLine("Please enter the key phrase:");
                key = Console.ReadLine().ToLower();
            }
            if(choice == "encode")
            {
                if (caeserVariants.Contains(cipher))
                {
                    output = CaeserShift.Encode(userin, shift);
                }
                else
                {
                    output = Vigenere.Encode(userin, key, shift);
                }
            }
            else
            {
                if (caeserVariants.Contains(cipher))
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
