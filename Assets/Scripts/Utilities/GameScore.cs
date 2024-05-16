public class GameScore
{
    private DeckModel _deckModel;
    private int score;

    public Observer<GameScoreObserverModel> Observer { get; set; } = new Observer<GameScoreObserverModel>();

    public GameScore(DeckModel deckModel)
    {
        _deckModel = deckModel;
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

        Observer.Notify(new GameScoreObserverModel(score));
    }
}

public class GameScoreObserverModel
{
    public int score;

    public GameScoreObserverModel(int score)
    {
        this.score = score;
    }
}
