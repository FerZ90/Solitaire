using System.Collections.Generic;
using System.Linq;

public class ListStack<T> : IStack<T>
{
    private List<T> _listStack;

    public ListStack()
    {
        _listStack = new List<T>();
    }

    public void AddFirst(T item)
    {
        _listStack.Insert(0, item);    
    }

    public bool AddLast(T item)
    {
        if (_listStack.Contains(item))
            return false;

        _listStack.Add(item);
        return true;
    }

    public int GetItemIndex(T item)
    {
        return _listStack.IndexOf(item);
    }

    public List<T> GetNodeItems(T item)
    {
        List<T> items = new List<T>();

        int itemIndex = _listStack.IndexOf(item);

        for (int i = itemIndex; i < _listStack.Count; i++)
        {
            items.Add(_listStack[i]);
        }

        return items;
    }

    public bool RemoveItem(T item)
    {
        if (!_listStack.Contains(item))
            return false;

        _listStack.Remove(item);
        return true;
    }

    public T RemoveLast()
    {
        var last = _listStack.Last();
        _listStack.Remove(last);
        return last;
    }
   
}
