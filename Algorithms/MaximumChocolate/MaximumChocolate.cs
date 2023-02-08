using System;

namespace MaximumChocolate
{
    public class MaximumChocolate
    {
        public static void Main()
        {
            int money = int.Parse(Console.ReadLine());
            int price = int.Parse(Console.ReadLine());
            int wraps = int.Parse(Console.ReadLine());

            Console.WriteLine(CountMaxChocolates(money, price, wraps));
        }
        private static int CountMaxChocolates(int money, int price, int wraps)
        {
            int chocos = money / price;
            return chocos + CountRec(chocos, wraps);
        }

        private static int CountRec(int chocos, int requiredWrappers)
        {
            if (chocos < requiredWrappers)
            {
                return 0;
            }

            int chocosFromWrappers = chocos / requiredWrappers;
            int remainingWrappers = chocos % requiredWrappers;

            return chocosFromWrappers + CountRec(chocosFromWrappers + remainingWrappers, requiredWrappers);
        }
    }
}