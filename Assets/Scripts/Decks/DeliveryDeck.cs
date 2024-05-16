using UnityEngine.EventSystems;

public class DeliveryDeck : Pile
{
    public Observer<CardView> Observer { get; set; } = new();

    public void OnPointerClick(PointerEventData _)
    {
        var lastCard = GetLast();
        Observer.Notify(lastCard);
    }

    public override void AddLast(CardView card)
    {
        base.AddLast(card);
        card.SetReverse(true);
    }

}
