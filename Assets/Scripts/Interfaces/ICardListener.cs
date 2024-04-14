
using UnityEngine;

public interface ICardListener
{
    void OnFinishDrag(IDeck newDeck, CardView card);
}
