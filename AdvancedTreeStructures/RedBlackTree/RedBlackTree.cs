using System;

namespace RedBlackTree
{
    public class RedBlackTree<T> : IRedBlackTree<T> 
        where T : IComparable
    {
        private Node<T> root;

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
            this.root.Color = Color.Black;
        }

        private Node<T> Insert(T element, Node<T> node)
        {
            if (node == null)
            {
                this.root = new Node<T>(element);
                return this.root;
            }

            if (element.CompareTo(node.Value) < 0)
            {
                node.Left = Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = Insert(element, node.Right);
            }

            return node;
        }

        private Node<T> RotateLeft(Node<T> node)
        {
            Node<T> newNode = node.Right;

            node.Right = newNode.Left;
            newNode.Left = node;

            return newNode;
           
        }

        private Node<T> RotateRight(Node<T> node)
        {
            Node<T> newNode = node.Left;

            node.Left = newNode.Right;
            newNode.Right = node;

            return newNode;
        }

        private void SwapColors(Node<T> node)
        {
            node.Color = Color.Red;
            node.Left.Color = Color.Black;
            node.Right.Color = Color.Black;
        }

        private bool IsRed(Node<T> node)
        {
            if (node == null)
            {
                return false;
            }

            return node.Color == Color.Red;
        }

        public void Traverse(Action<T> action)
        {
            this.Traverse(action, this.root);
        }

        private void Traverse(Action<T> action, Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            Traverse(action, node.Left);
            action(node.Value);
            Traverse(action, node.Right);
        }
    }
}
