namespace SinglyLinkedList
{
    // Ett generiskt gränssnitt som definierar grundläggande operationer för en lista
    // som innehåller objekt av typen Person eller dess subklasser.
    internal interface IListInterface<T>
    {
        void Add(T item, int index);

        void Remove(int index);

        void RemoveAll();

        bool IsEmpty();

        int Size();
    }
}
