using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CardView : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] private TextMeshProUGUI cardValueTxt;
    [SerializeField] private TextMeshProUGUI cardSuitTxt;

    private CardModel _cardModel;
    private bool _reverse = true;
    private Image _image;
    private readonly Observer<CardviewObserverModel> _cardviewObserver = new Observer<CardviewObserverModel>();

    public CardModel CardModel => _cardModel;
    public bool Reverse => _reverse;
    public Observer<CardviewObserverModel> CardviewObserver => _cardviewObserver;


    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Setup(CardModel cardModel)
    {
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
        {
            _image.color = Color.green;
            cardValueTxt.text = null;
            cardSuitTxt.text = null;
        }
        else
        {
            if (_cardModel.cardSuitValue.suit == CardSuit.Diamonds || _cardModel.cardSuitValue.suit == CardSuit.Hearts)
                _image.color = Color.red;
            else
                _image.color = Color.black;

            cardValueTxt.text = _cardModel.cardSuitValue.value.ToString();
            cardSuitTxt.text = _cardModel.cardSuitValue.suit.ToString();
        }     
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        CardviewObserver?.Notify(new CardviewObserverModel(CardViewEventType.OnBeginDrag, eventData, this));   
    }

    public void OnDrag(PointerEventData eventData)
    {
        CardviewObserver?.Notify(new CardviewObserverModel(CardViewEventType.OnDrag, eventData, this));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        CardviewObserver?.Notify(new CardviewObserverModel(CardViewEventType.OnEndDrag, eventData, this));
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
        this.card = card;
        this.eventData = eventData;
        this.card = card;
    }
}

