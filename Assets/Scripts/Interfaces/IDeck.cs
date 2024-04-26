using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDeck
{
    //Task AddCardToDeck(CardView card);
    //void RemoveCardFromDeck(CardView card);
    //bool IsValidDragging(CardView card);
    //CardView GetLastCard(bool removeCard);
    //void ReturnCardToDeck(CardView card);
    void AddLast(CardView card);
    CardView RemoveLast();
    void Setup(ICardValidator cardValidator);
    List<CardView> GetNodeCards(CardView card);
    bool TryInsertCard(CardView card);
}


public interface ICardValidator
{
    public void Validate(CardView card);
}
