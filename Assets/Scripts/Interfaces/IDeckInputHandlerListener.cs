using UnityEngine.EventSystems;

public interface IDeckInputHandlerListener
{
    public void OnDropCardInDeck(IDeck deck, PointerEventData eventData);
}

