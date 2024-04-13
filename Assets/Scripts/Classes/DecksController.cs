using System.Collections.Generic;

public class DecksController : IDecksController
{
    private Dictionary<int, IDeck> _gameDecks;

    public DecksController(DeckInspectorData data)
    {       
        InitializeDecks(data);
    }

    void InitializeDecks(DeckInspectorData data)
    {
        _gameDecks = new Dictionary<int, IDeck>();

        _gameDecks.Add(Globals.CroupierDeckID, new Deck(data.deliveryDeck));
        _gameDecks.Add(Globals.DiscardDeckID, new Deck(data.discardDeck));

        foreach (var deckTransform in data.inGameDecks)
            _gameDecks.Add(_gameDecks.Count + 1, new Deck(deckTransform));

        foreach (var deckTransform in data.finishedDecks)
            _gameDecks.Add(_gameDecks.Count + 1, new Deck(deckTransform));
    }

    public async void InsertIntoCroupierDeck(CardView cardView)
    {
        if (cardView.CardModel.deck != null)
            cardView.CardModel.deck.RemoveCardFromDeck(cardView);          

        cardView.CardModel.deck = _gameDecks[Globals.CroupierDeckID];
        await cardView.CardModel.deck.AddCardToDeck(cardView);
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

}

public interface IDecksController
{
    void InsertIntoCroupierDeck(CardView cardView);
    void InsertIntoDiscardDeck(CardView cardView);
    void InsertIntoFinishedDeck(CardView cardView);
    void InsertIntoInGameDeck(CardView cardView);
}
