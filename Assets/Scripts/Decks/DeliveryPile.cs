using UnityEngine.EventSystems;

public class DeliveryPile : Pile, IPointerClickHandler
{
    private IClickPileListener _listener;

    public void Setup(IClickPileListener listener)
    {
        _listener = listener;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var lastCard = GetLast();
        _listener.OnPileClick(this, lastCard, eventData);
    }

    public override void AddLast(CardView card)
    {
        base.AddLast(card);
        card.SetReverse(true);
    }

}

public interface IClickPileListener
{
    void OnPileClick(IPile pile, CardView card, PointerEventData eventData);
}


