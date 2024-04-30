public static class UserDecksController
{
    public static void InsertIntoDeck(IDeck deck, CardView cardView)
    {
        ChangeCardDeck(deck, cardView);
    }

    private static void ChangeCardDeck(IDeck newDeck, CardView cardView)
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
   

