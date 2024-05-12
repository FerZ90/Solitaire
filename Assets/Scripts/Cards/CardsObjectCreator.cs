using System.Collections.Generic;
using UnityEngine;

public class CardsObjectCreator : MonoBehaviour, ICardsObjectCreator, ISubjectType<List<CardView>>
{
    [SerializeField] private CardsCreatorInspectorData cardsCreatorInspectorData;
    [SerializeField] private CardTextureDistributor cardTextureDistributor;

    private ICardsCreatorData _cardsCreator;
    private List<CardView> _cardsViews = new List<CardView>();
    public Observer<List<CardView>> Observer { get; set; } = new Observer<List<CardView>>();

    private void Awake()
    {
        _cardsViews = new List<CardView>();
        _cardsCreator = new DeckCreator();
    }

    private void OnDestroy()
    {
        Observer.Dispose();
    } 

    public void CreateCards()
    {    
        var deck = _cardsCreator.CreateDeck();
        var cardBackgroundImg = cardTextureDistributor.GetRandomBackground();


        foreach (var deckCard in deck)
        {
            var currentCard = Instantiate(cardsCreatorInspectorData.cardPrefab, cardsCreatorInspectorData.cardsInitialPoint);
            currentCard.transform.position = cardsCreatorInspectorData.cardsInitialPoint.position;

            var cardImg = cardTextureDistributor.GetCardTexture(deckCard);        
            var cardModel = new CardModel(deckCard, cardImg, cardBackgroundImg);   
            currentCard.Setup(cardModel);
            _cardsViews.Add(currentCard);        
        
        }

        Observer.Notify(_cardsViews);
    }

    public void Reset()
    {
        foreach (var cardViews in _cardsViews)
            Destroy(cardViews.gameObject);

        _cardsViews.Clear();
    }
   
}



