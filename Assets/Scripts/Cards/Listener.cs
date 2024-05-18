using System.Collections.Generic;

public class Listener<T>
{
    protected List<T> _listeners;
    public void AddListener(T listener)
    {
        _listeners.Add(listener);
    }

    public void RemoveListener(T listener)
    {
        _listeners.Remove(listener);
    }

    public void AddListeners(params T[] listeners)
    {
        foreach (var listener in listeners)
            _listeners.Add(listener);
    }
}
