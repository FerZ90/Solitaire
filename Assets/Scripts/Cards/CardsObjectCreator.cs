using System.Collections.Generic;

public class CardsObjectCreator : ICardsObjectCreator, ISubjectType<List<CardView>>
{  
    private CardsCreatorInspectorData _model;   
    private ICardsCreatorData _cardsCreator;

    private readonly List<CardView> _cardsViews = new List<CardView>();
    public Observer<List<CardView>> Observer { get; set; } = new Observer<List<CardView>>();

    public CardsObjectCreator(CardsCreatorInspectorData cardsObjectCreatorModel, ICardsCreatorData cardsCreator)
    {
        _cardsViews = new List<CardView>();
        _model = cardsObjectCreatorModel;
        _cardsCreator = cardsCreator;
    }

    ~CardsObjectCreator() 
    {
        Observer.Dispose();
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

        Observer.Notify(_cardsViews);
    }

    public void Reset()
    {
        foreach (var cardViews in _cardsViews)
            UnityEngine.Object.Destroy(cardViews.gameObject);

        _cardsViews.Clear();
    }
   
}



