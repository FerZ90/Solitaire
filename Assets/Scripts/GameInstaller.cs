using System.Collections;
using UnityEngine;

public class GameInstaller : MonoBehaviour
{
    [SerializeField] private DeckModel deckIspectorData;
    [SerializeField] private Blocker blocker;
    [SerializeField] private DoubleTap doubleTapInput;
    [SerializeField] private CardsObjectCreator cardsObjectCreator;
    [SerializeField] private GameObject draggingCardsParent;

    private CardTranslator _cardTranslator;
    private CardAnimator _cardAnimator;
    private GameScore _gameScore;
    private Croupier _croupier;
    private UserInputHandler _cardsInputHandler;

    private void Awake()
    {
        _cardAnimator = new CardAnimator();
        _cardTranslator = new CardTranslator(_cardAnimator);
        _gameScore = new GameScore(deckIspectorData);
        _croupier = new Croupier(cardsObjectCreator, deckIspectorData);
        _cardsInputHandler = new UserInputHandler(cardsObjectCreator, draggingCardsParent);
        blocker.Setup(_cardAnimator);
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        deckIspectorData.PrepareDecks();
        cardsObjectCreator.CreateCards();
    }

}
