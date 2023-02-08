using System;
using System.Collections.Generic;
using System.Linq;

namespace RecamansSequence
{
    public class RecamansSequence
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<int> list = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                list.Add(Recaman(i));
            }

            Console.WriteLine(string.Join(", ", list));
        }

        private static int Recaman(int n)
        {
            HashSet<int> set = new HashSet<int>();
            int[] sequence = new int[n];
            sequence[0] = 0;
            set.Add(sequence[0]);

            for (int i = 1; i < n; i++)
            {
                int prev = sequence[i - 1];
                int next = prev - i;
                if (next > 0 && !set.Contains(next))
                {
                    sequence[i] = next;
                }
                else
                {
                    sequence[i] = prev + i;
                }
                set.Add(sequence[i]);
            }
            return sequence[n - 1];
        }
    }
}
