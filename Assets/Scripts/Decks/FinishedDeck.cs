
public class FinishedDeck : Deck
{
    private readonly bool _isComplete;
    public bool IsComplete => _isComplete;

    public override void AddLast(CardView card)
    {
        base.AddLast(card);
        card.SetReverse(true);
    }

}
