using UnityEngine.EventSystems;

public struct CardViewObserverModel
{
    public CardInputState inputState;
    public PointerEventData eventData;
    public CardView card;

    public CardViewObserverModel(CardInputState inputState, PointerEventData eventData, CardView card)
    {
        this.inputState = inputState;
        this.eventData = eventData;
        this.card = card;
    }
}



