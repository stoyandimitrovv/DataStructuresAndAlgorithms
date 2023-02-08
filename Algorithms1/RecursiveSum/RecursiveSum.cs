using System;

namespace RecursiveSum
{
    public class RecursiveSum
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            Console.WriteLine(CalculateSumRecursively(n, m));
        }

        private static int CalculateSumRecursively(int n, int m)
        {
            if (n == m)
            {
                return n;
            }

            return n + CalculateSumRecursively(n + 1, m);
        }
    }
}
