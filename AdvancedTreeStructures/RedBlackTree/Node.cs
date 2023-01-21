namespace RedBlackTree
{
    public class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
            this.Color = Color.Red;
        }

        public T Value { get; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public Color Color { get; set; }
    }
}
