using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameInstaller : MonoBehaviour, ICardsCreatorListener
{
    [SerializeField] private CardsCreatorInspectorData cardsCreatorInspectorData;
    [SerializeField] private DeckInspectorData deckIspectorData;

    private DecksController _decksController;
    private CardsObjectCreator _cardsObjectCreator;
    private CardInputHandler _cardsInputHandler;

    private void Awake()
    {
        _decksController = new DecksController();
        _cardsInputHandler = new CardInputHandler(_decksController);
        _cardsObjectCreator = new CardsObjectCreator(cardsCreatorInspectorData, new CardsCreatorData(), this);
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        _decksController.InitializeDecks(deckIspectorData);
        _cardsObjectCreator.CreateCards();
    }

    public async void OnCardsCreated(List<CardView> deck)
    {
        foreach (var card in deck)
        {
            card.SetListener(_cardsInputHandler);
            _decksController.InsertIntoCroupierDeck(card);
            await Task.Delay(100);
        }   
    }


}
