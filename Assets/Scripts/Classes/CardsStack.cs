using System.Collections.Generic;

public class CardsStack<T>
{
    private readonly Queue<T> _stack = new Queue<T>();
    public int CardCount => _stack.Count;

    public CardsStack()
    {
        _stack = new Queue<T>();
    }

    public T GetItem()
    {
        if (_stack.Count <= 0)
        {
            return default(T);
        }
        else
        {
            return _stack.Dequeue();
        }        
    }

    public void PushItem(T item)
    {
        if (!_stack.Contains(item))
        {
            _stack.Enqueue(item);
        }
    }
}
