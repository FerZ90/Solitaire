using System.Collections;
using UnityEngine;

public class GameInstaller : MonoBehaviour
{
    [SerializeField] private DeckModel deckIspectorData;
    [SerializeField] private Blocker blocker;
    [SerializeField] private DoubleTap doubleTapInput;
    [SerializeField] private CardsObjectCreator cardsObjectCreator;
    [SerializeField] private GameObject draggingCardsParent;

    private Croupier _croupier;
    private UserInputHandler _cardsInputHandler;

    private void Awake()
    {      
        _croupier = new Croupier(cardsObjectCreator, deckIspectorData);
        _cardsInputHandler = new UserInputHandler(cardsObjectCreator, _croupier, draggingCardsParent);
        doubleTapInput.Setup(_croupier);
        blocker.Setup(deckIspectorData);
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        deckIspectorData.PrepareDecks(_cardsInputHandler);
        cardsObjectCreator.CreateCards();
    }  

}
