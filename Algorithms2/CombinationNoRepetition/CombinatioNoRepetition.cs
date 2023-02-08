﻿using System;

namespace CombinationNoRepetition
{
    public class CombinatioNoRepetition
    {
        private static int K;
        private static string[] Input;
        private static string[] Combinations;

        static void Main(string[] args)
        {
            Input = Console.ReadLine().Split();
            K = int.Parse(Console.ReadLine());
            Combinations = new string[K];

            Combinate(0, 0);
        }

        private static void Combinate(int index, int start)
        {
            if (index >= Combinations.Length)
            {
                Console.WriteLine(string.Join(" ", Combinations));
                return;
            }

            for (int i = start; i < Input.Length; i++)
            {
                Combinations[index] = Input[i];
                Combinate(index + 1, i + 1);
            }
        }
    }
}
