using System;

namespace NChooseKCount
{
    public class NChooseKCount
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine(Binom(n, k));
        }

        private static int Binom(int n, int k)
        {
            int numerator = Factorial(n);
            int denominator = Factorial(k) * Factorial(n - k);
            return numerator / denominator;
        }

        static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            int factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
