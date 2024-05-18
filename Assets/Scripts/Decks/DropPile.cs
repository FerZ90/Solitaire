using UnityEngine.EventSystems;

public class DropPile : Pile, IDropHandler
{
    private IDropPileListener _listener;
    public void Setup(IDropPileListener listener)
    {
        _listener = listener;
    }

    public void OnDrop(PointerEventData eventData)
    {
        _listener.OnDrop(this, eventData);
    }
}

public interface IDropPileListener
{
    void OnDrop(IPile pile, PointerEventData eventData);
}
