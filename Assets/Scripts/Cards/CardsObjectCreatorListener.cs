using System.Collections.Generic;
using System.Linq;

public class CardsObjectCreatorListener : ICardsObjectCreatorListener
{
    private List<ICardsObjectCreatorListener> _listeners;

    public CardsObjectCreatorListener(params ICardsObjectCreatorListener[] listeners)
    {
        _listeners = listeners.ToList();
    }

    public void AddListener(ICardsObjectCreatorListener listener)
    {
        _listeners.Add(listener);
    }

    public void RemoveListener(ICardsObjectCreatorListener listener)
    {
        _listeners.Remove(listener);
    }

    public void OnCreateCards(List<CardView> cardsViews)
    {
        foreach (var listener in _listeners)
            listener?.OnCreateCards(cardsViews);
    }
}
