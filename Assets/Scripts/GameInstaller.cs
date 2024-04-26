using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameInstaller : MonoBehaviour, ICardsObjectCreatorListener
{
    [SerializeField] private CardsCreatorInspectorData cardsCreatorInspectorData;
    [SerializeField] private DecksData deckIspectorData;

    private Croupier _croupier;
    private DecksController _decksController;
    private CardsObjectCreator _cardsObjectCreator;
    private UserInputHandler _cardsInputHandler;

    private void Awake()
    {
        _decksController = new DecksController();
        _croupier = new Croupier(_decksController);
        _cardsInputHandler = new UserInputHandler(_decksController);
        _cardsObjectCreator = new CardsObjectCreator(cardsCreatorInspectorData, new CardsCreatorData(), this);
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        _decksController.PrepareDecks(deckIspectorData, _cardsInputHandler);
        _cardsObjectCreator.CreateCards(_cardsInputHandler); 
    }

    public async void OnCreateCardsViews(List<CardView> cardViews)
    {
        List<Task> allTasks = new List<Task>();

        foreach (var cardView in cardViews)
        {        
            _decksController.InsertIntoCroupierDeck(cardView);
            allTasks.Add(Task.Delay(100));
        }

        await Task.WhenAll(allTasks);

        _croupier.DealCards();
    }

}
