namespace SinglyLinkedList
{
    internal interface IListInterface<T> where T : Person
    {
        void Add(T item, int index);

        void Remove(int index);

        void RemoveAll();

        bool IsEmpty();

        int Size();
    }
}
