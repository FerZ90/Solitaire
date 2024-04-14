
public interface IDecksController
{
    void InitializeDecks(DeckInspectorData data);
    void InsertIntoCroupierDeck(CardView cardView);
    void InsertIntoDiscardDeck(CardView cardView);
    void InsertIntoFinishedDeck(CardView cardView);
    void InsertIntoInGameDeck(CardView cardView);
}
