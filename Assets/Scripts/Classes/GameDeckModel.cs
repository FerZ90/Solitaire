using System.Collections.Generic;

public class GameDeckModel
{
    public List<CardData> cards;
    public int score;
    public IDeck deliveryDeck;
    public IDeck discardDeck;
    public List<IDeck> inGameDecks;
    public List<IDeck> finishedDecks;
}
