
public class DiscardDeck : Pile
{
    public override void AddLast(CardView card, MovementType movementType)
    {
        base.AddLast(card, movementType);
        card.SetReverse(false);
    }
}

