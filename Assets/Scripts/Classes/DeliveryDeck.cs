using UnityEngine;

public abstract class DeliveryDeck
{
    protected CardsStack<CardModel> cardsStack;
    protected Transform _deckTransform;
    public DeckType DeckType { get; set; }

    public DeliveryDeck(Transform deckTransform)
    {
        cardsStack = new CardsStack<CardModel>();
        _deckTransform = deckTransform;
    }

    public virtual void AddCardToDeck(CardModel card)
    {            
        cardsStack.PushItem(card);   
    }

    public virtual CardModel RemoveCardFromDeck()
    {
        return cardsStack.GetItem();
    }
 
}
