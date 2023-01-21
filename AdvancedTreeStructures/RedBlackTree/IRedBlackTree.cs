using System;

namespace RedBlackTree
{
    public interface IRedBlackTree<T> 
        where T: IComparable
    {
        void Insert(T element);

        void Traverse(Action<T> action);
    }
}
