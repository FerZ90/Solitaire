using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DecksController : IDecksController, ICardListener
{
    private Dictionary<int, IDeck> _gameDecks; 

    public void InitializeDecks(DeckInspectorData data)
    {
        _gameDecks = new Dictionary<int, IDeck>();

        _gameDecks.Add(1, data.deliveryDeck);
        _gameDecks.Add(2, data.discardDeck);

        foreach (var gameDeck in data.inGameDecks)
        {
            _gameDecks.Add(_gameDecks.Count + 1, gameDeck);
        }

        foreach (var finishedDeck in data.finishedDecks)
        {
            _gameDecks.Add(_gameDecks.Count + 1, finishedDeck);
        }  
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

    public void OnFinishDrag(IDeck newDeck, CardView card)
    {
        ChangeCardDeck(card, newDeck);

    }
 
}

