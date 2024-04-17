
public class DecksController : IDecksController, IUserInputHandlerListener
{
    private DecksData _gameDecks;
    public DecksData GameDecks => _gameDecks;

    public void PrepareDecks(DecksData data)
    {
        _gameDecks = data;

        _gameDecks.deliveryDeck.Initialize(this);
        _gameDecks.discardDeck.Initialize(this);   

        foreach (var gameDeck in _gameDecks.inGameDecks)
        {         
            gameDeck.Initialize(this);
        }

        foreach (var finishedDeck in _gameDecks.finishedDecks)
        {       
            finishedDeck.Initialize(this);
        }
    }

    public void InsertIntoDeck(IDeck deck, CardView cardView)
    {
        ChangeCardDeck(cardView, deck);
    }

    public void InsertIntoCroupierDeck(CardView cardView)
    {
        var croupierDeck = _gameDecks.deliveryDeck;
        ChangeCardDeck(cardView, croupierDeck);
    }

    public void InsertIntoDiscardDeck(CardView cardView)
    {
        //throw new System.NotImplementedException();
    }

    public void InsertIntoFinishedDeck(CardView cardView)
    {
        //throw new System.NotImplementedException();
    }

    public void InsertIntoInGameDeck(CardView cardView)
    {
        //throw new System.NotImplementedException();
    }

    private async void ChangeCardDeck(CardView cardView, IDeck newDeck)
    {
        if (cardView.CardModel.deck != null)
            cardView.CardModel.deck.RemoveCardFromDeck(cardView);

        if (newDeck != null)
            cardView.CardModel.deck = newDeck;

        await cardView.CardModel.deck.AddCardToDeck(cardView);
    }
}
   

