using System.Collections.Generic;

public interface IStack<T>
{
    List<T> Elements { get; }
    void AddFirst(T item);
    bool AddLast(T item);
    int GetItemIndex(T item);
    List<T> GetNodeItems(T item);
    bool RemoveItem(T item);
    T RemoveLast();
    T GetLast();
}