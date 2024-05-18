using System.Collections.Generic;

public class CardsObjectCreatorListener : Listener<ICardsObjectCreatorListener>, ICardsObjectCreatorListener
{
    public void OnCreateCards(List<CardView> cardsViews)
    {
        foreach (var listener in _listeners)
            listener?.OnCreateCards(cardsViews);
    }
}
