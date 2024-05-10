using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IPile
{
    Vector3 GetCardPosition(CardView card);
    void ReturnCardToDeck(CardView card);
    void AddLast(CardView card);
    CardView RemoveLast();
    List<CardView> GetNodeCards(CardView card);
    bool TryInsertCard(CardView card);
}

public interface IDropablePile : IDropHandler
{
    void Setup(IDropableListener listener);
}

public interface IDeliveryPile : IPointerClickHandler
{
    void Setup(IDeliveryDeckListener listener);
}



