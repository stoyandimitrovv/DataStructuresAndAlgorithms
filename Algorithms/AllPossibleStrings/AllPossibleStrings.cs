using System;
using System.Linq;

namespace AllPossibleStrings
{
    public class AllPossibleStrings
    {
        public static void Main()
        {
            string[] set = Console.ReadLine().Split();
            int k = int.Parse(Console.ReadLine());
            PrintAllKLength(set, k);
        }

        private static void PrintAllKLength(string[] set, int k)
        {
            int n = set.Length;
            PrintAllKLengthRec(set, "", n, k);
        }

        private static void PrintAllKLengthRec(string[] set, string str, int length, int k)
        {
            if (k == 0)
            {
                Console.WriteLine(str);
                return;
            }
            for (int i = 0; i < length; i++)
            {
                String newString = str + set[i];
                PrintAllKLengthRec(set, newString, length, k - 1);
            }
        }
    }
}
