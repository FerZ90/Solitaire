using System.Collections;
using UnityEngine;

public class GameInstaller : MonoBehaviour
{
    [SerializeField] private DeckModel deckIspectorData;
    [SerializeField] private Blocker blocker;
    [SerializeField] private DoubleTap doubleTapInput;
    [SerializeField] private CardsObjectCreator cardsObjectCreator;
    [SerializeField] private GameObject draggingCardsParent;

    private CardAnimator _cardAnimator;
    private GameScore _gameScore;
    private Croupier _croupier;
    private UserInputHandler _cardsInputHandler;

    private void Awake()
    {
        _cardAnimator = new CardAnimator(blocker);
        _gameScore = new GameScore(deckIspectorData);
        _croupier = new Croupier(deckIspectorData);
        _cardsInputHandler = new UserInputHandler(_croupier, draggingCardsParent);
        cardsObjectCreator.Setup(_croupier);
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        deckIspectorData.PrepareDecks(_cardsInputHandler);
        cardsObjectCreator.CreateCards(_cardsInputHandler);
    }

}
