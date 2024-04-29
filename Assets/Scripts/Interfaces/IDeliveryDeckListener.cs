using UnityEngine.EventSystems;

public interface IDeliveryDeckListener
{
    void OnCroupierClick(PointerEventData eventData, CardView card);
}