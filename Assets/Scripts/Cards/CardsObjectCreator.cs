using System;
using System.Collections.Generic;

public class CardsObjectCreator : ICardsObjectCreator
{  
    private CardsCreatorInspectorData _model;   
    private ICardsCreatorData _cardsCreator;
    private ICardsCreatorListener _listener;

    public CardsObjectCreator(CardsCreatorInspectorData cardsObjectCreatorModel, ICardsCreatorData cardsCreator, ICardsCreatorListener listener)
    {
        _model = cardsObjectCreatorModel;
        _cardsCreator = cardsCreator;
        _listener = listener;
    }

    public void CreateCards()
    {
        var creatorData = _cardsCreator;
        creatorData.CreateDeck();

        List<CardView> cardsViews = new List<CardView>();

        foreach (var deckCard in creatorData.GameCards)
        {
            var currentCard = UnityEngine.Object.Instantiate(_model.cardPrefab, _model.cardsInitialPoint);
            currentCard.transform.position = _model.cardsInitialPoint.position;

            var cardModel = new CardModel(deckCard);   
            currentCard.Setup(cardModel, null, null);
            cardsViews.Add(currentCard);
        }

        _listener?.OnCardsCreated(cardsViews);
    }

  
}


