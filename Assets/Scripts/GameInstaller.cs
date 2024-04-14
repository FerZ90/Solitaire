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

    private void Awake()
    {   
        _decksController = new DecksController();
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
            card.SetListener(_decksController);
            _decksController.InsertIntoCroupierDeck(card);
            await Task.Delay(100);
        }   
    }


}
