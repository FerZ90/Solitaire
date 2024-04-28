
public interface IUserDecksController
{
    DeckModel DeckModel { get; }
    public void InsertIntoCroupierDeck(CardView cardView);
    public void InsertIntoDiscardDeck(CardView cardView); 
    void InsertIntoFinishedDeck(CardView cardView);
    void InsertIntoInGameDeck(CardView cardView);
    void InsertIntoDeck(IDeck deck, CardView cardView);
}


