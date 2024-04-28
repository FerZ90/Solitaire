using UnityEngine.EventSystems;

public interface IDeckInputHandlerListener
{
    public void OnDropCardInDeck(IDeck deck, PointerEventData eventData);
    public void OnCroupierClick(PointerEventData eventData, CardView card);
}


