using System;

namespace AVLTree
{
    public interface IAvl<T>
    {
        void Insert(T item);

        void Traverse(Action<T> action);
    }
}
