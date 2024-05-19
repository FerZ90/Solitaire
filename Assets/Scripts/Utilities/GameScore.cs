public class GameScore : InGameDeckListener
{
    private DeckModel _deckModel;
    private int score;
    private IGameScoreListener _listener;

    public GameScore(IGameScoreListener listener, DeckModel deckModel)
    {
        _listener = listener;
        _deckModel = deckModel;
        score = 0;
    }

    public void OnUserMovement()
    {
        score++;
        UnityEngine.Debug.Log($"Score: {score}");
    }

    private void CheckIfGameIfFinished()
    {
        foreach (var finishedDeck in _deckModel.finishedDecks)
        {
            if (!finishedDeck.IsComplete)
                return;
        }

        _listener?.GameOver(score);
    }
}

public interface IGameScoreListener
{
    void GameOver(int score);
}
