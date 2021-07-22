using System;
using System.Collections.Generic;

namespace Cryptographies
{
    public static class SharedFunctions
    {
        public static char[] ConvertToArray(string userin)
        {
            List<char> result = new List<char>();
            //char[] result = new char[userin.Length];
            char[] filteredInput = userin.ToCharArray();
            //Convert user input to array
            foreach (var letter in filteredInput)
            {
                if (!Char.IsPunctuation(letter) && !Char.IsWhiteSpace(letter))
                {
                    result.Add(Char.ToUpper(letter));
                }
            }
            return result.ToArray();
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
