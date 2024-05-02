
public class DiscardDeck : Pile
{
    public override void AddLast(CardView card)
    {
        base.AddLast(card);
        card.SetReverse(false);
    }
}

