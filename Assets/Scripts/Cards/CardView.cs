using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CardView : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, IObservable<CardViewObserverModel>
{
    private CardModel _cardModel;
    private bool _reverse = true;
    private Image _image;
    public CardModel CardModel => _cardModel;
    public bool Reverse => _reverse;

    public Observer<CardViewObserverModel> Observer { get; set; } = new();


    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Setup(CardModel cardModel)
    {
        _cardModel = cardModel;
        _image.sprite = _cardModel.backgroundImg;
        UpdateCardInfo();
    }

    public void UpdateCard()
    {
        UpdateCardInfo();
    }

    private void UpdateCardInfo()
    {
        if (_reverse)
            _image.overrideSprite = null;
        else
            _image.overrideSprite = CardModel.cardImg;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Observer.Notify(new CardViewObserverModel(CardInputState.OnBeginDrag, eventData, this));
    }

    public void OnDrag(PointerEventData eventData)
    {
        Observer.Notify(new CardViewObserverModel(CardInputState.OnDrag, eventData, this));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Observer.Notify(new CardViewObserverModel(CardInputState.OnEndDrag, eventData, this));
    }

    public void SetReverse(bool reverse)
    {
        _reverse = reverse;
        UpdateCardInfo();
    }
}

public enum CardInputState
{
    OnBeginDrag,
    OnDrag,
    OnEndDrag
}



