using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameInstaller : MonoBehaviour
{
    [SerializeField] private DeckModel deckIspectorData;
    [SerializeField] private Blocker blocker;
    [SerializeField] private DoubleTap doubleTapInput;
    [SerializeField] private CardsCreatorInspectorData cardsCreatorInspectorData;
    [SerializeField] private GameObject draggingCardsParent;

    private Croupier _croupier;
    private CardsObjectCreator _cardsObjectCreator;
    private UserInputHandler _cardsInputHandler;

    private void Awake()
    {
        _cardsObjectCreator = new CardsObjectCreator(cardsCreatorInspectorData, new DeckCreator());
        _croupier = new Croupier(_cardsObjectCreator, deckIspectorData);
        _cardsInputHandler = new UserInputHandler(_cardsObjectCreator, _croupier, draggingCardsParent);
        doubleTapInput.Setup(_croupier);
        blocker.Setup(deckIspectorData);
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        deckIspectorData.PrepareDecks(_cardsInputHandler);
        _cardsObjectCreator.CreateCards();
    }  

}
