using System;

namespace AATree
{
    public interface IAaTree<T>
    {
        void Insert(T element);

        void Traverse(Action<T> action);
    }
}
