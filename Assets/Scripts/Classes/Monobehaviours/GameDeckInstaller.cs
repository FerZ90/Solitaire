using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class GameDeckInstaller : MonoBehaviour
{
    [SerializeField] private CardView cardPrefab;
    [SerializeField] private Transform cardsInitialPoint;
    [SerializeField] private DeckInspectorData deckInspectorData;
    [SerializeField] private GameConfig gameConfig;

    public event Action<CardModel, int> AddCardToDeckEvent;

    private IDeckCreator _deckCreator;
    private IDecksController _decksController;

    private void Awake()
    {
        _deckCreator = new DeckCreator();
        _decksController = new DecksController(deckInspectorData);
    }
 
    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        InitGame();
    }

    public void InitGame()
    {           
        CreateCards();
    }    

    private async void CreateCards()
    {   
        foreach (var deckCard in _deckCreator.GameCards)
        {
            var currentCard = Instantiate(cardPrefab, cardsInitialPoint);
            currentCard.transform.position = cardsInitialPoint.position;

            var cardModel = new CardModel(deckCard); 
            currentCard.Initialize(cardModel, null, null);

            _decksController.InsertIntoCroupierDeck(currentCard);

            await Task.Delay(gameConfig.delaybetweenCards);
        }

    }

}







