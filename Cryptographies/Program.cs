using System;

namespace Cryptographies
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Would you like to encode or decode an message?");
            string choice = Console.ReadLine().ToLower();
            string output = "";
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
            if(choice == "encode")
            {
                output = CaeserShift.Encode(userin, shift);
            }
            else
            {
                output = CaeserShift.Decode(userin, shift);
            }
            Console.WriteLine(output);
        }
    }
}
