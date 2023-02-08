namespace AVL
{
    public interface IAvlTree<T>
    {
        void Delete(T key);

        void Insert(T element);
    }
}
