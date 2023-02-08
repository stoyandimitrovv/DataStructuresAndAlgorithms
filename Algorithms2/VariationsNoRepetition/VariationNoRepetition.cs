using System;
using System.Linq;

namespace VariationsNoRepetition
{
    public class VariationNoRepetition
    {
        private static int K;
        private static string[] Input;
        private static string[] Variations;
        private static bool[] IsUsed;

        public static void Main()
        {
            Input = Console.ReadLine().Split();
            K = int.Parse(Console.ReadLine());
            Variations = new string[K];
            IsUsed = new bool[Input.Length];

            Variate(0);
        }

        private static void Variate(int index)
        {
            if (index >= Variations.Length)
            {
                Console.WriteLine(string.Join(" ", Variations));
                return;
            }

            for (int i = 0; i < Input.Length; i++)
            {
                if (!IsUsed[i])
                {
                    IsUsed[i] = true;
                    Variations[index] = Input[i];
                    Variate(index + 1);
                    IsUsed[i] = false;
                }
            }
        }
    }
}
