using System.Collections.Generic;

public interface ICroupier
{
    void InsertIntoDeck(IDeck deck, CardView cardView);
    void DeliverCard(CardView cardView);

    void CompleteInGameDeck(List<CardView> completeDeck);
}

