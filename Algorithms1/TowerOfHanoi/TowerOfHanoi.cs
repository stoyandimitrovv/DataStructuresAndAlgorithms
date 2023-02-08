using System;
using System.Collections.Generic;
using System.Linq;

namespace TowerOfHanoi
{
    public class TowerOfHanoi
    {
        static Stack<int> source = new Stack<int>();
        static Stack<int> destination = new Stack<int>();
        static Stack<int> spare = new Stack<int>();
        static int count = 0;
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine()); // Number of disks
            

            for (int i = n; i > 0; i--)
            {
                source.Push(i);
            }
            Console.WriteLine("Towers of Hanoi with " + n + " disks:");
            MoveDisks(n, source, destination, spare);
        }

        private static void MoveDisks(
            int bottomDisk,
            Stack<int> source,
            Stack<int> destination,
            Stack<int> spare)
        {
            if (bottomDisk == 0)
            {
                return;
            }
            MoveDisks(bottomDisk - 1, source, spare, destination);
            int disk = source.Pop();
            destination.Push(disk);
            //Console.WriteLine("Move disk " + disk + " from " + source + " to " + destination);
            PrintPegs(disk);
            MoveDisks(bottomDisk - 1, spare, destination, source);
        }

        private static void PrintPegs(int disk)
        {
            Console.WriteLine("Step #" + (++count) + ": Moved disk " + disk);
            Console.WriteLine("Source: " + string.Join(", ", source.ToArray().OrderByDescending(e => e)));
            Console.WriteLine("Destination: " + string.Join(", ", destination.ToArray().OrderByDescending(e => e)));
            Console.WriteLine("Spare: " + string.Join(", ", spare.ToArray().OrderByDescending(e => e)));
            Console.WriteLine();
        }
    }
}
