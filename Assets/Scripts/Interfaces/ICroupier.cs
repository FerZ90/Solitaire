using System.Collections.Generic;

public interface ICroupier
{
    void InsertIntoDeck(IPile deck, CardView cardView);
    void DeliverCard(CardView cardView);
    void CompleteInGameDeck(List<CardView> completeDeck);
}

