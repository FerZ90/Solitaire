using System.Collections.Generic;

public interface ICardsObjectCreator
{
    void CreateCards();
    void Reset();

    public Observer<List<CardView>> CardsObjectCreatorObserver { get; }
}
