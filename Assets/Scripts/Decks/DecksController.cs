using System.Collections.Generic;

public class DecksController : IDecksController
{
    private Dictionary<int, IDeck> _gameDecks;

    public void InitializeDecks(DeckInspectorData data)
    {
        _gameDecks = new Dictionary<int, IDeck>();

        data.deliveryDeck.Initialize(this);
        data.discardDeck.Initialize(this);

        _gameDecks.Add(1, data.deliveryDeck);
        _gameDecks.Add(2, data.discardDeck);

        foreach (var gameDeck in data.inGameDecks)
        {
            _gameDecks.Add(_gameDecks.Count + 1, gameDeck);
            gameDeck.Initialize(this);
        }

        foreach (var finishedDeck in data.finishedDecks)
        {
            _gameDecks.Add(_gameDecks.Count + 1, finishedDeck);
            finishedDeck.Initialize(this);
        }
    }

    public void InsertIntoDeck(IDeck deck, CardView cardView)
    {
        ChangeCardDeck(cardView, deck);
    }

    public void InsertIntoCroupierDeck(CardView cardView)
    {
        var croupierDeck = _gameDecks[Globals.CroupierDeckID];
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
   

