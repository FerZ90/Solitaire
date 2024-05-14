using System.Collections;
using UnityEngine;

public class GameInstaller : MonoBehaviour
{
    [SerializeField] private DeckModel deckIspectorData;
    [SerializeField] private Blocker blocker;
    [SerializeField] private DoubleTap doubleTapInput;
    [SerializeField] private CardsObjectCreator cardsObjectCreator;
    [SerializeField] private GameObject draggingCardsParent;

    private GameScore _gameScore;
    private Croupier _croupier;
    private UserInputHandler _cardsInputHandler;

    private void Awake()
    {
        _gameScore = new GameScore(deckIspectorData);
        _croupier = new Croupier(cardsObjectCreator, doubleTapInput, deckIspectorData);
        _cardsInputHandler = new UserInputHandler(cardsObjectCreator, _croupier, draggingCardsParent);
        blocker.Setup(deckIspectorData);
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        deckIspectorData.PrepareDecks(_cardsInputHandler);
        cardsObjectCreator.CreateCards();
    }  

}
