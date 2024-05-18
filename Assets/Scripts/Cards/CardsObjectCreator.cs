using System.Collections.Generic;
using UnityEngine;

public class CardsObjectCreator : MonoBehaviour
{
    [SerializeField] private CardsCreatorInspectorData cardsCreatorInspectorData;
    [SerializeField] private CardTextureDistributor cardTextureDistributor;

    private ICardsCreatorData _cardsCreator;
    private List<CardView> _cardsViews = new List<CardView>();
    private ICardsObjectCreatorListener _listener;

    private void Awake()
    {
        _cardsViews = new List<CardView>();
        _cardsCreator = new DeckCreator();
    }

    public void Setup(ICardsObjectCreatorListener listener)
    {
        _listener = listener;
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
            currentCard.SetupModel(cardModel);
            _cardsViews.Add(currentCard);
        }

        _listener.OnCreateCards(_cardsViews);
    }

    public void Reset()
    {
        foreach (var cardViews in _cardsViews)
            Destroy(cardViews.gameObject);

        _cardsViews.Clear();
    }

}

public interface ICardsObjectCreatorListener
{
    void OnCreateCards(List<CardView> cardsViews);
}



