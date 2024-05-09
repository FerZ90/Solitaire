using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameInstaller : MonoBehaviour
{
    [SerializeField] DeckModel deckIspectorData;
    [SerializeField] private DoubleTap doubleTapInput;
    [SerializeField] private CardsCreatorInspectorData cardsCreatorInspectorData;
    [SerializeField] private GameObject draggingCardsParent;
    [SerializeField] private Image blockerImage;

    private Croupier _croupier;
    private CardsObjectCreator _cardsObjectCreator;
    private UserInputHandler _cardsInputHandler;
    private Blocker _uiBlocker;

    private void Awake()
    {
        _uiBlocker = new Blocker(blockerImage, deckIspectorData);
        _croupier = new Croupier(deckIspectorData);
        _cardsInputHandler = new UserInputHandler(_croupier, draggingCardsParent);
        _cardsObjectCreator = new CardsObjectCreator(cardsCreatorInspectorData, new CardsCreatorData(), _croupier);
        doubleTapInput.Setup(_croupier);
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        deckIspectorData.PrepareDecks(_cardsInputHandler);
        _cardsObjectCreator.CreateCards(_cardsInputHandler);
    }  

}
