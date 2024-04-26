
public interface IDecksController
{
    public DecksData GameDecks { get; }
    void PrepareDecks(DecksData data, IDeckInputHandlerListener _listener);
    void InsertIntoCroupierDeck(CardView cardView);
    void InsertIntoDiscardDeck(CardView cardView);
    void InsertIntoFinishedDeck(CardView cardView);
    void InsertIntoInGameDeck(CardView cardView);
    void InsertIntoDeck(IDeck deck, CardView cardView);
}

public class DeckModel
{
    public int Id { get; set; }
    public DeckType deckType;
    public IDeck deck;

    public DeckModel(int Id, DeckType deckType, IDeck deck)
    {
        this.Id = Id;
        this.deckType = deckType;
        this.deck = deck;
    } 
}

