using System;
using System.Collections.Generic;
using System.Linq;

namespace FruitDrinks
{
    public class FruitDrinks
    {
        public static void Main()
        {
            string[] fruits = Console.ReadLine().Split(" ");
            string[] toppings = Console.ReadLine().Split(" ");
            var fruitCombinations = GetCombinations(fruits, 2);
            var drinkCombinations = new List<string[]>();

            foreach (var fruitCombo in fruitCombinations)
            {
                foreach (var topping in toppings)
                {
                    drinkCombinations.Add(fruitCombo.Concat(new string[] { topping }).ToArray());
                }
            }

            foreach (var drinkCombo in drinkCombinations)
            {
                Console.WriteLine(string.Join(" ", drinkCombo));
            }
        }

        private static List<string[]> GetCombinations(string[] input, int length)
        {
            var list = new List<string[]>();
            Generate(0, 0, input, new string[length], list);
            return list;
        }

        private static void Generate(int index, int start, string[] input, string[] combo, List<string[]> list)
        {
            if (index == combo.Length)
            {
                list.Add((string[])combo.Clone());
                return;
            }

            for (int i = start; i < input.Length; i++)
            {
                combo[index] = input[i];
                Generate(index + 1, i, input, combo, list);
            }
        }

    }
}