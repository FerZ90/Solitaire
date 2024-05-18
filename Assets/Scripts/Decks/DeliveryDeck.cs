using UnityEngine.EventSystems;

public class DeliveryDeck : Pile, IObservable<CardMovementObserverModel>, IPointerClickHandler
{
    public Observer<CardMovementObserverModel> Observer { get; set; } = new();

    public void OnPointerClick(PointerEventData eventData)
    {
        var lastCard = GetLast();
        Observer.Notify(new CardMovementObserverModel(this, lastCard, eventData));
    }

    public override void AddLast(CardView card)
    {
        base.AddLast(card);
        card.SetReverse(true);
    }

}

public struct CardMovementObserverModel
{
    public IPile deck;
    public CardView card;
    public PointerEventData pointerEventData;

    public CardMovementObserverModel(IPile deck, CardView card, PointerEventData pointerEventData)
    {
        this.deck = deck;
        this.card = card;
        this.pointerEventData = pointerEventData;
    }
}
