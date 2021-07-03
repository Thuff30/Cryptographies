using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptographies
{
    public static class SharedFunctions
    {
        public static char[] ConvertToArray(string userin)
        {
            char[] result = new char[userin.Length];
            //Convert user input to array
            for (int i = 0; i < userin.Length; i++)
            {
                if (userin[i] != ' ')
                {
                    result[i] = Char.ToUpper(userin[i]);
                }
            }
            return result;
        }
        public static Queue<char> PopulateQueue(char[] reference)
        {
            Queue<char> shift = new Queue<char>();
            for (int i = 0; i < reference.Length; i++)
            {
                shift.Enqueue(reference[i]);
            }
            return shift;
        }
        public static Queue<char> ShiftQueue(Queue<char> q, int shiftNum)
        {
            for (int i = 0; i < shiftNum; i++)
            {
                var templetter = q.Dequeue();
                q.Enqueue(templetter);
            }
            return q;
        }
    }
}
