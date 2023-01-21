using System;

namespace AVLTree
{
    public class Avl<T> : IAvl<T>
        where T : IComparable<T>
    {
        public Node<T> Root { get; private set; }

        public void Insert(T item)
        {
            this.Root = this.Insert(this.Root, item);
        }

        public void Traverse(Action<T> action)
        {
            this.Traverse(this.Root, action);
        }

        private Node<T> Insert(Node<T> node, T item)
        {
            if (node == null)
            {
                return new Node<T>(item);
            }

            if (item.CompareTo(node.Value) < 0)
            {
                node.Left = Insert(node.Left, item);
            }
            else if (item.CompareTo(node.Value) > 0)
            {
                node.Right = Insert(node.Right, item);
            }

            this.UpdateHeight(node);
            this.UpdateBalance(node);

            return this.Rebalance(node);
        }

        private Node<T> Rebalance(Node<T> node)
        {
            int balance = this.GetBalance(node);

            if (balance == -2)
            {
                balance = this.GetBalance(node.Right);

                node = balance > 0
                    ? this.RightLeftRotation(node)
                    : this.LeftRotation(node);
            }

            if (balance == 2)
            {
                balance = this.GetBalance(node.Left);

                node = balance < 0
                    ? this.LeftRightRotation(node)
                    : this.RightRotation(node);
            }

            return node;
        }

        private Node<T> LeftRotation(Node<T> node)
        {
            var right = node.Right;
            node.Right = node.Right.Left;
            right.Left = node;

            UpdateHeight(node);

            return right;
        }

        private Node<T> RightRotation(Node<T> node)
        {         
            var left = node.Left;
            node.Left = node.Left.Right;
            left.Right = node;

            UpdateHeight(node);

            return left;
        }

        private Node<T> RightLeftRotation(Node<T> node)
        {
            node.Right = this.RightRotation(node.Right);
            return this.LeftRotation(node);
        }

        private Node<T> LeftRightRotation(Node<T> node)
        {
            node.Left = this.LeftRotation(node.Left);
            return this.RightRotation(node);
        }

        private void UpdateBalance(Node<T> node)
        {
            node.Balance = this.GetHeight(node.Left) - this.GetHeight(node.Right);
        }

        private int GetBalance(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Balance;
        }

        private void UpdateHeight(Node<T> node)
        {
            node.Height = Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;
        }

        private int GetHeight(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Height;
        }

        private void Traverse(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            Traverse(node.Left, action);
            action(node.Value);
            Traverse(node.Right, action);
        }
    }
}
