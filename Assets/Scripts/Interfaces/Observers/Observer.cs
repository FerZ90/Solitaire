using System;
using System.Collections.Generic;

public class Observer<T> : IDisposable, ISubject<T>
{
    private readonly List<IObserver<T>> _observers;

    public Observer()
    {
        _observers = new List<IObserver<T>>();
    }

    public void Subscribe(IObserver<T> observer)
    {
        UnityEngine.Debug.Log("Subscribe Observer !!");

        if (!_observers.Contains(observer))
            _observers.Add(observer);
    }

    public void Unsubscribe(IObserver<T> observer)
    {
        if (_observers.Contains(observer))
            _observers.Remove(observer);
    }

    public void Notify(T parameter)
    {
        foreach (var observer in _observers)
            observer.UpdateEvent(parameter);
    }

    public void Dispose()
    {
        for (int i = 0; i < _observers.Count; i++)
            Unsubscribe(_observers[i]);

        _observers.Clear();
    }
}

public class ObserverModel
{

}

public class CardViewObserverModel : ObserverModel
{
    public CardView card;
    public bool finishAnimation;

    public CardViewObserverModel(CardView card, bool finishAnimation)
    {
        this.card = card;
        this.finishAnimation = finishAnimation;
    }

   
}

