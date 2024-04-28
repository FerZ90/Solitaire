using System.Collections.Generic;

public interface IDeck
{
    //Task AddCardToDeck(CardView card);
    //void RemoveCardFromDeck(CardView card);
    //CardView GetLastCard(bool removeCard);
    void Setup(IDeckInputHandlerListener listener);
    bool IsValidDragging(CardView card);
    void ReturnCardToDeck(CardView card);
    void AddLast(CardView card);
    CardView RemoveLast();
    List<CardView> GetNodeCards(CardView card);
    bool TryInsertCard(CardView card);
}


public interface ICardValidator
{
    public void Validate(CardView card);
}
