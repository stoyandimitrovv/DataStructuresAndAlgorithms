using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAStack
{
    public class ReverseAStack
    {
        public static void Main()
        {
            Stack<string> stack = new Stack<string>(Console.ReadLine().Split());

            ReverseStack(stack);

            foreach (string str in stack)
            {
                Console.WriteLine(str);
            }
        }

        private static void ReverseStack(Stack<string> stack)
        {
            if (stack.Count > 0)
            {
                string a = stack.Peek();
                stack.Pop();
                ReverseStack(stack);

                InsertAtBottom(stack, a);
            }
        }

        private static void InsertAtBottom(Stack<string> stack, string current)
        {
            if (stack.Count == 0)
            {
                stack.Push(current);
            }
            else
            {
                string a = stack.Peek();
                stack.Pop();
                InsertAtBottom(stack, current);

                stack.Push(a);
            }
        }
    }
}
