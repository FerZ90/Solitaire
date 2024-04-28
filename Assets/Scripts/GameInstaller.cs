using System.Collections;
using UnityEngine;

public class GameInstaller : MonoBehaviour
{
    [SerializeField] private CardsCreatorInspectorData cardsCreatorInspectorData;
    [SerializeField] private DeckModel deckIspectorData;
    [SerializeField] private GameObject draggingCardsParent;

    private Croupier _croupier;
    private UserDecksController _decksController;
    private CardsObjectCreator _cardsObjectCreator;
    private UserInputHandler _cardsInputHandler;

    private void Awake()
    {
        _decksController = new UserDecksController(deckIspectorData);
        _croupier = new Croupier(_decksController);
        _cardsInputHandler = new UserInputHandler(_decksController, draggingCardsParent);
        _cardsObjectCreator = new CardsObjectCreator(cardsCreatorInspectorData, new CardsCreatorData(), _croupier);
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        deckIspectorData.PrepareDecks(_cardsInputHandler);
        _cardsObjectCreator.CreateCards(_cardsInputHandler); 
    }  

}
