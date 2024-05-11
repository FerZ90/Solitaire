using System.Collections.Generic;

public class CardsObjectCreator : ICardsObjectCreator
{  
    private CardsCreatorInspectorData _model;   
    private ICardsCreatorData _cardsCreator;

    private readonly List<CardView> _cardsViews = new List<CardView>();

    private readonly Observer<List<CardView>> _cardsObjectCreatorObserver = new Observer<List<CardView>>();
    public Observer<List<CardView>> CardsObjectCreatorObserver => _cardsObjectCreatorObserver;

    public CardsObjectCreator(CardsCreatorInspectorData cardsObjectCreatorModel, ICardsCreatorData cardsCreator)
    {
        _cardsViews = new List<CardView>();
        _model = cardsObjectCreatorModel;
        _cardsCreator = cardsCreator;
    }

    public void CreateCards()
    {    
        var deck = _cardsCreator.CreateDeck();

        foreach (var deckCard in deck)
        {
            var currentCard = UnityEngine.Object.Instantiate(_model.cardPrefab, _model.cardsInitialPoint);
            currentCard.transform.position = _model.cardsInitialPoint.position;

            var cardModel = new CardModel(deckCard);   
            currentCard.Setup(cardModel);
            _cardsViews.Add(currentCard);        
        
        }

        _cardsObjectCreatorObserver.Notify(_cardsViews);
    }

    public void Reset()
    {
        foreach (var cardViews in _cardsViews)
            UnityEngine.Object.Destroy(cardViews.gameObject);

        _cardsViews.Clear();
    }
   
}



