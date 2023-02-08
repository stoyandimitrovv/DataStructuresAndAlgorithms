using System;

namespace RecursiveImplementationAtoi
{
    public class RecursiveImplementationAtoi
    {
        public static void Main()
        {
            string str = Console.ReadLine();

            Console.WriteLine(RecursiveAtoi(str, str.Length - 1));
        }

        private static int RecursiveAtoi(string str, int length)
        {
            if (char.IsDigit(str[length]) == false)
            {
                throw new ArgumentException();
            }

            if (length <= 0)
            {
                return str[length] - '0';
            }

            return (str[length] - '0') + RecursiveAtoi(str, length - 1) * 10;
        }
    }
}
