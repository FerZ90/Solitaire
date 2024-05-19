using System;
using System.Collections.Generic;

public class Listener<T> : IDisposable
{
    protected List<T> _listeners = new List<T>();

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

    public void Dispose()
    {
        for (int i = 0; i < _listeners.Count; i++)
            _listeners.Remove(_listeners[i]);

        _listeners.Clear();
    }
}
