public class UserDecksController : IUserDecksController
{
    private DeckModel _deckModel;
    public DeckModel DeckModel { get; private set; }

    public UserDecksController(DeckModel deckModel)
    {
        _deckModel = deckModel;
    }

    public void InsertIntoDeck(IDeck deck, CardView cardView)
    {  
        ChangeCardDeck(cardView, deck);
    }   

    public void InsertIntoFinishedDeck(CardView cardView)
    {
        //throw new System.NotImplementedException();
    }

    public void InsertIntoInGameDeck(CardView cardView)
    {
        //throw new System.NotImplementedException();
    }

    public void InsertIntoCroupierDeck(CardView cardView)
    {
        var croupierDeck = _deckModel.deliveryDeck;
        croupierDeck.AddLast(cardView);
    }

    public void InsertIntoDiscardDeck(CardView cardView)
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
                cardView.CardModel.deck.RemoveLast();

            cardView.CardModel.deck = newCardDeck;
            cardView.CardModel.deck.AddLast(cardView);
        }       
    }
 
}
   

