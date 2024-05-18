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
        _cardAnimator.Observer.Subscribe(_cardTranslator);

        _gameScore = new GameScore(deckIspectorData);

        _croupier = new Croupier(deckIspectorData, _cardTranslator);
        cardsObjectCreator.Observer.Subscribe(_croupier);
        _cardsInputHandler = new UserInputHandler(draggingCardsParent);
        _cardsInputHandler.Observer.Subscribe(_croupier);
        cardsObjectCreator.Observer.Subscribe(_cardsInputHandler);
        _cardAnimator.Observer.Subscribe(blocker);
        doubleTapInput.Setup(_cardsInputHandler);


    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        deckIspectorData.PrepareDecks(_croupier);
        cardsObjectCreator.CreateCards();
    }

}
