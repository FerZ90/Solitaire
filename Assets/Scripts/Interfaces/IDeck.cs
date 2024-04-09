
using System.Collections.Generic;

public interface IDeck
{
    public List<CardModel> CurrentCards { get; set; }
    public void AddCardToDeck(Card card);
    public void RemoveCardFromDeck(Card card);   
}
