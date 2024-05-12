using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CardView : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, ISubjectType<CardviewObserverModel>
{
    private CardModel _cardModel;
    private bool _reverse = true;
    private Image _image;
    public CardModel CardModel => _cardModel;
    public bool Reverse => _reverse;
    public Observer<CardviewObserverModel> Observer { get; set; } = new Observer<CardviewObserverModel>();

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void OnDestroy()
    {
        Observer.Dispose();
    }

    public void Setup(CardModel cardModel)
    {
        _image.sprite = cardModel.backgroundImg;
        _cardModel = cardModel;  
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
        Observer?.Notify(new CardviewObserverModel(CardViewEventType.OnBeginDrag, eventData, this));   
    }

    public void OnDrag(PointerEventData eventData)
    {
        Observer?.Notify(new CardviewObserverModel(CardViewEventType.OnDrag, eventData, this));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Observer?.Notify(new CardviewObserverModel(CardViewEventType.OnEndDrag, eventData, this));
    }

    public void SetReverse(bool reverse)
    {
        _reverse = reverse;   
        UpdateCardInfo();
    }   
}

public enum CardViewEventType
{
    OnBeginDrag,
    OnDrag,
    OnEndDrag
}

public class CardviewObserverModel
{
    public CardViewEventType eventType;
    public PointerEventData eventData;
    public CardView card;

    public CardviewObserverModel(CardViewEventType eventType, PointerEventData eventData, CardView card)
    {
        this.eventType = eventType;
        this.eventData = eventData;
        this.card = card;
    }
}

