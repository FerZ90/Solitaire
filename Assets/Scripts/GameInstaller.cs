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
        _gameScore = new GameScore(null, deckIspectorData);

        var cardsObjectsCreatorListener = new CardsObjectCreatorListener();
        var cardAnimatorListener = new CardAnimatorListener();

        _cardAnimator = new CardAnimator(cardAnimatorListener);
        _cardTranslator = new CardTranslator(_cardAnimator);
        _croupier = new Croupier(_cardTranslator, deckIspectorData);
        _cardsInputHandler = new UserInputHandler(_croupier, draggingCardsParent);

        cardsObjectsCreatorListener.AddListeners(_croupier, _cardsInputHandler);
        cardAnimatorListener.AddListeners(_cardTranslator, blocker);

        _gameScore = new GameScore(null, deckIspectorData);
        doubleTapInput.Setup(_croupier);
        cardsObjectCreator.Setup(cardsObjectsCreatorListener);
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        deckIspectorData.PrepareDecks(_croupier, _cardsInputHandler);
        cardsObjectCreator.CreateCards();
    }

}
