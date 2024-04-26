using System.Collections.Generic;

public class CardsObjectCreator : ICardsObjectCreator
{  
    private CardsCreatorInspectorData _model;   
    private ICardsCreatorData _cardsCreator;
    private ICardsObjectCreatorListener _listener;


    private readonly List<CardView> _cardsViews = new List<CardView>();

    public CardsObjectCreator(CardsCreatorInspectorData cardsObjectCreatorModel, ICardsCreatorData cardsCreator, ICardsObjectCreatorListener listener)
    {
        _cardsViews = new List<CardView>();
        _model = cardsObjectCreatorModel;
        _cardsCreator = cardsCreator;
        _listener = listener;
    }

    public void CreateCards(ICardInputHandlerListener inputCardsListener)
    {    
        var deck = _cardsCreator.CreateDeck();

        foreach (var deckCard in deck)
        {
            var currentCard = UnityEngine.Object.Instantiate(_model.cardPrefab, _model.cardsInitialPoint);
            currentCard.transform.position = _model.cardsInitialPoint.position;

            var cardModel = new CardModel(deckCard);   
            currentCard.Setup(cardModel, inputCardsListener);
            _cardsViews.Add(currentCard);        
        
        }

        _listener?.OnCreateCardsViews(_cardsViews);
    }

    public void Reset()
    {
        foreach (var cardViews in _cardsViews)
        {
            UnityEngine.Object.Destroy(cardViews.gameObject);
        }

        _cardsViews.Clear();
    }

  
}

public interface ICardsObjectCreatorListener
{
    void OnCreateCardsViews(List<CardView> cardViews);
}


