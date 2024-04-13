using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameDeckInstaller : MonoBehaviour
{
    [SerializeField] private CardView cardPrefab;
    [SerializeField] private Deck deliveryDeck;
    [SerializeField] private Deck discardDeck;
    [SerializeField] private List<Deck> inGameDecks;
    [SerializeField] private List<Deck> finishedDecks;

    private List<CardInfo> _gameDeck;

    //Testing propose
    private void Start()
    {
        InitGame();
    }

    public void InitGame()
    {
        InitializeDecks();
        CreateCards();
    }  

    private void InitializeDecks()
    {
        //CardAnimator animator = new CardAnimator(0.1f);
        deliveryDeck.Initialize();
        discardDeck.Initialize();
        foreach (var deck in inGameDecks)
            deck.Initialize();

        foreach (var deck in finishedDecks)
            deck.Initialize();
    }

    private async void CreateCards()
    {
        _gameDeck = DeckCreator.CreateDeck();

        var tasks = new List<Task>();

        foreach (var deckCard in _gameDeck)
        {
            var currentCard = Instantiate(cardPrefab, deliveryDeck.transform);
            currentCard.transform.position = Vector3.zero;

            var cardModel = new CardModel(deckCard);
            cardModel.reverse = true;
            currentCard.Initialize(cardModel, null, null);

            await Task.Delay(100);
            var cardAnimationTask = deliveryDeck.AddCardToDeck(currentCard);
            tasks.Add(cardAnimationTask);
        }

        await Task.WhenAll(tasks);

        foreach (var deckCard in deliveryDeck.DeckCards)
        {
            deckCard.CardModel.reverse = false;
            await Task.Delay(100);
            var cardAnimationTask = finishedDecks[2].AddCardToDeck(deckCard);
            tasks.Add(cardAnimationTask);
        }
    }


}
