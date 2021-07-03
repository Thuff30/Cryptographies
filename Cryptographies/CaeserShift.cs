using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptographies
{
    public static class CaeserShift
    {
        static char[] reference = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        public static string Encode(string userin, int shiftNum) 
        {
            StringBuilder sb = new StringBuilder();
            char[] input = SharedFunctions.ConvertToArray(userin);
            Queue<char> shift = SharedFunctions.PopulateQueue(reference);
            shift = SharedFunctions.ShiftQueue(shift, shiftNum);
            
            //Convert queue to array
            char[] code = shift.ToArray();

            foreach(var letter in input)
            {
                if (letter != ' ')
                {
                    sb.Append(code[Array.IndexOf(reference, Char.ToUpper(letter))]);
                }
                else
                {
                    sb.Append(letter);
                }
            }

            return sb.ToString();
        }
        public static string Decode(string userin, int shiftNum)
        {
            StringBuilder sb = new StringBuilder();
            char[] input = SharedFunctions.ConvertToArray(userin);
            Queue<char> shift = SharedFunctions.PopulateQueue(reference);
            shift = SharedFunctions.ShiftQueue(shift, shiftNum);

            char[] code = shift.ToArray();

            foreach(var letter in input)
            {
                if (letter != ' ')
                {
                    sb.Append(reference[Array.IndexOf(code, Char.ToUpper(letter))]);
                }
                else
                {
                    sb.Append(letter);
                }
            }

            return sb.ToString();
        }
    }
}
