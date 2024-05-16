using System;
using System.Collections.Generic;

public class EventDispatcher
{
    public static EventDispatcher Instance => _instance ??= new EventDispatcher();
    private static EventDispatcher _instance;

    private readonly Dictionary<Type, Action<object>> _events;

    public EventDispatcher()
    {
        _events = new Dictionary<Type, Action<object>>();
    }

    public void Subscribe<T>(IObserver<T> callback)
    {
        var type = typeof(T);

        if (_events.TryGetValue(type, out Action<object> thisEvent))
        {
            _events.Add(type, null);
        }

        _events[type] += Convert(callback);
    }

    public void Unsubscribe<T>(IObserver<T> callback)
    {
        var type = typeof(T);
        if (_events.ContainsKey(type))
        {
            _events[type] -= Convert(callback);
        }
    }

    public void Dispatch<T>(T signal)
    {
        var type = typeof(T);
        if (!_events.ContainsKey(type))
            return;
        _events[type](signal);
    }

    private Action<object> Convert<T>(IObserver<T> myActionT)
    {
        return null;
        //if (myActionT == null) return null;
        //else return new Action<object>(o => myActionT.UpdateEvent((T)o));
    }
}