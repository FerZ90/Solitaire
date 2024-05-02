using UnityEngine.EventSystems;

public class DeliveryDeck : Pile, IDeliveryPile
{
    private IDeliveryDeckListener _listener;

    public void Setup(IDeliveryDeckListener listener)
    {
        _listener = listener;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var lastCard = GetLast();   
        _listener?.OnCroupierClick(eventData, lastCard);
    }

    public override void AddLast(CardView card)
    {
        base.AddLast(card);
        card.SetReverse(true);        
    }

}
