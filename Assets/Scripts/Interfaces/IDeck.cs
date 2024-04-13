using System.Threading.Tasks;

public interface IDeck
{
    Task AddCardToDeck(CardView card);
    void RemoveCardFromDeck(CardView card);
}
