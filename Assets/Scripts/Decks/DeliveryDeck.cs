using UnityEngine.EventSystems;

public class DeliveryDeck : Pile
{
    private IDeliveryDeckListener _listener;

    public void Setup(IDeliveryDeckListener listener)
    {
        _listener = listener;
    }

    public void OnPointerClick(PointerEventData _)
    {
        var lastCard = GetLast();
        _listener?.OnCroupierClick(lastCard);
    }

    public override void AddLast(CardView card)
    {
        base.AddLast(card);
        card.SetReverse(true);
    }

}
