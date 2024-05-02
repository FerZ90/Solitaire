
public class FinishedDeck : Pile
{
    private bool _isComplete;
    public bool IsComplete => _isComplete;

    public override void AddLast(CardView card)
    {
        if (_isComplete)
            return;

        base.AddLast(card);
        card.SetReverse(true);

        if (_cards.Elements.Count >= 13)
            _isComplete = true;
    }  

}
