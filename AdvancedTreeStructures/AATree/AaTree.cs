using System;

namespace AATree
{
    public class AaTree<T> : IAaTree<T>
        where T : IComparable<T>
    {
        private Node<T> root;

        public Node<T> Root => this.root;

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        public void Traverse(Action<T> action)
        {
            this.Traverse(action, this.root);
        }

        private Node<T> Insert(T element, Node<T> node)
        {
            if (node == null)
            {
                node = new Node<T>(element);
            }
            else if (element.CompareTo(node.Element) < 0)
            {
                node.Left = this.Insert(element, node.Left);
            }
            else
            {
                node.Right = this.Insert(element, node.Right);
            }

            node = this.Skew(node);
            node = this.Split(node);

            return node;
        }

        //A skew is a right rotation
        private Node<T> Skew(Node<T> node)
        {
            if (node.Left == null || node.Left.Level != node.Level)
            {
                return node;
            }

            Node<T> newNode = node.Left;
            node.Left = newNode.Right;
            newNode.Right = node;

            node = newNode;

            return node;
        }

        //A split is a left rotation
        private Node<T> Split(Node<T> node)
        {
            if (node.Right == null || node.Right.Right == null || node.Right.Right.Level != node.Level)
            {
                return node;
            }

            Node<T> newNode = node.Right;
            node.Right = newNode.Left;
            newNode.Left = node;
            newNode.Level++;

            node = newNode;

            return node;
        }

        private void Traverse(Action<T> action, Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            Traverse(action, node.Left);
            action(node.Element);
            Traverse(action, node.Right);
        }
    }
}
