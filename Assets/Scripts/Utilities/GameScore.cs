public class GameScore : IObserver<PileObserverModel>, ISubjectType<int>
{
    private DeckModel _deckModel;
    private int score;
    public Observer<int> Observer { get; set; } = new Observer<int>();

    public GameScore(DeckModel deckModel)
    {
        _deckModel = deckModel;
        _deckModel.Observer.Subscribe(this);
        score = 0;
    }

    public void UpdateEvent(PileObserverModel parameter)
    {
        if (parameter.finishAnimation)
        {
            score++;
            CheckIfGameIfFinished();
        }

    }

    private void CheckIfGameIfFinished()
    {
        foreach (var finishedDeck in _deckModel.finishedDecks)
        {
            if (!finishedDeck.IsComplete)
                return;
        }

        Observer.Notify(score);
    }
}
