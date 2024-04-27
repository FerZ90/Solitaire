
using System.Diagnostics;

public class DecksController : IDecksController
{  
    private DecksData _gameDecks;
    public DecksData GameDecks => _gameDecks;

    public void PrepareDecks(DecksData data, IDeckInputHandlerListener listener)
    {
        _gameDecks = data;

        _gameDecks.deliveryDeck.Setup(listener);
        _gameDecks.discardDeck.Setup(listener);

        foreach (var gameDeck in _gameDecks.inGameDecks)
            gameDeck.Setup(listener);

        foreach (var finishedDeck in _gameDecks.finishedDecks)
            finishedDeck.Setup(listener);
    }

    public void InsertIntoDeck(IDeck deck, CardView cardView)
    {  
        ChangeCardDeck(cardView, deck);
    }

    public void InsertIntoCroupierDeck(CardView cardView)
    {
        var croupierDeck = _gameDecks.deliveryDeck;
        croupierDeck.AddLast(cardView);
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

    private void ChangeCardDeck(CardView cardView, IDeck newDeck)
    {    
        var newCardDeck = newDeck;

        if (newCardDeck == null)
            newCardDeck = cardView.CardModel.deck;

        cardView.CardModel.LogCard();

        if (cardView.CardModel.deck == newDeck)
        {
            cardView.CardModel.deck.ReturnCardToDeck(cardView);
        }
        else
        {

            if (cardView.CardModel.deck != null)
            {
                cardView.CardModel.deck.RemoveLast();
            }

            cardView.CardModel.deck = newCardDeck;
            cardView.CardModel.deck.AddLast(cardView);
        }       
    }
 
}
   

