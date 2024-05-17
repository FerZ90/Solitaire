using System.Collections.Generic;
using UnityEngine;

public interface IPile
{
    Vector3 GetNewCardPosition(CardView card);
    void PutCardviewOnDeck(CardView card);
    void AddLast(CardView card);
    CardView RemoveLast();
    List<CardView> GetNodeCards(CardView card);
    bool TryInsertCard(CardView card);
    bool Contains(CardView card);
}




