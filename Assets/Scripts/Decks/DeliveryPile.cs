using UnityEngine.EventSystems;

public class DeliveryPile : Pile, IPointerClickHandler
{
    private IDeliveryPileListener _listener;

    public void Setup(IDeliveryPileListener listener)
    {
        _listener = listener;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var lastCard = GetLast();
        _listener.DeliverCard(lastCard);
    }

    public override void AddLast(CardView card, MovementType movementType)
    {
        base.AddLast(card, movementType);
        card.SetReverse(true);
    }

}

public interface IDeliveryPileListener
{
    void DeliverCard(CardView card);
}


