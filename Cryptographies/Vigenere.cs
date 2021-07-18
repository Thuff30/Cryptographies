using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cryptographies
{
    public static class Vigenere
    {
        static char[] reference = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        public static string Encode(string userin, string key, int shiftNum)
        {
            StringBuilder sb = new StringBuilder();
            char[] input = SharedFunctions.ConvertToArray(userin);
            List<char[]> tabulaRecta = GenerateCodeTable(shiftNum);
            char[] code = CodeString(input.Length, key);

            for(int i = 0; i < input.Length; i++)
            {
                //Get X Axis
                char[] temparray = tabulaRecta[Array.IndexOf(reference, Char.ToUpper(input[i]))];
                //Get and append Y Axis
                sb.Append(temparray[Array.IndexOf(reference, Char.ToUpper(code[i]))]);
            }

            return sb.ToString().ToUpper();
        }

        public static string Decode(string userin, string key, int shiftNum)
        {
            StringBuilder sb = new StringBuilder();
            char[] input = SharedFunctions.ConvertToArray(userin);
            List<char[]> tabulaRecta = GenerateCodeTable(shiftNum);
            char[] code = CodeString(input.Length, key);

            for (int i = 0; i < input.Length; i++)
            {
                char[] temparray = tabulaRecta[Array.IndexOf(reference, Char.ToUpper(code[i]))];
                sb.Append(reference[Array.IndexOf(temparray, Char.ToUpper(input[i]))]);
            }

            return sb.ToString().ToUpper();
        }

        static List<char[]> GenerateCodeTable(int shiftNum)
        {
            Queue<char> shift = SharedFunctions.PopulateQueue(reference);
            List<char[]> tabulaRecta = new List<char[]>();
            for (int i = 0; i < shiftNum; i++)
            {
                var templetter = shift.Dequeue();
                shift.Enqueue(templetter);
            }
            tabulaRecta.Add(shift.ToArray());
            for(int i = 1; i < 26; i++)
            {
                var templetter = shift.Dequeue();
                shift.Enqueue(templetter);
                tabulaRecta.Add(shift.ToArray());
            }
            return tabulaRecta;
        }

        static char[] CodeString(int inputLength, string key)
        {
            int repetitions = inputLength / key.Length;
            int remainder = inputLength % key.Length;
            StringBuilder sb = new StringBuilder();
            char[] keyArray = key.ToArray();

            for (int i = 0; i < repetitions; i++)
            {
                sb.Append(key);
            }
            for(int i = 0; i < remainder; i++)
            {
                sb.Append(keyArray[i]);
            }

            return sb.ToString().ToArray();
        }
    }
}
