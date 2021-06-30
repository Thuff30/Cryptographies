using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptographies
{
    public static class CaeserShift
    {
        static char[] reference = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        public static string Encode(string userin, int shiftNum) 
        {
            StringBuilder sb = new StringBuilder();
            char[] input = ConvertToArray(userin);
            Queue<char> shift = PopulateQueue(reference);
            shift = ShiftQueue(shift, shiftNum);
            
            //Convert queue to array
            char[] code = shift.ToArray();

            foreach(var letter in input)
            {
                if (letter != ' ')
                {
                    sb.Append(code[Array.IndexOf(reference, Char.ToLower(letter))]);
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
            char[] input = ConvertToArray(userin);
            Queue<char> shift = PopulateQueue(reference);
            shift = ShiftQueue(shift, shiftNum);

            char[] code = shift.ToArray();

            foreach(var letter in input)
            {
                if (letter != ' ')
                {
                    sb.Append(reference[Array.IndexOf(code, Char.ToLower(letter))]);
                }
                else
                {
                    sb.Append(letter);
                }
            }

            return sb.ToString();
        }

        static char[] ConvertToArray(string userin)
        {
            char[] result = new char[userin.Length];
            //Convert user input to array
            for (int i = 0; i < userin.Length; i++)
            {
                result[i] = userin[i];
            }
            return result;
        }
        static Queue<char> PopulateQueue(char[] reference)
        {
            Queue<char> shift = new Queue<char>();
            for (int i = 0; i < reference.Length; i++)
            {
                shift.Enqueue(reference[i]);
            }
            return shift;
        }
        
        static Queue<char> ShiftQueue(Queue<char> shift, int shiftNum)
        {
            for (int i = 0; i < shiftNum; i++)
            {
                var templetter = shift.Dequeue();
                shift.Enqueue(templetter);
            }
            return shift;
        }
    }
}
