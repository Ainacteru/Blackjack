public class CardsManager
{
    private static List<Card> deck = new List<Card>();

    public CardsManager()
    {
        deck = GenerateDeck();
        ShuffleDeck();
    }

    public List<Card> GenerateDeck()
    {
        string[] suits = { "Spades", "Hearts", "Clubs", "Diamonds" };
        string[] ranks = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

        for (int i = 0; i < deck.Count; i++)
        {
            deck.Remove(deck[0]);
        }

        List<Card> newDeck = new List<Card>();

        foreach (var suit in suits)
        {
            foreach (var rank in ranks)
            {
                newDeck.Add(new Card(rank, suit));
            }
        }

        return newDeck;
    }

    public void ShuffleDeck()
    {
        Card[] deckArray = deck.ToArray();

        Random.Shared.Shuffle(deckArray); // random.shared.shuffle only works for arrays so convert to array and back to list

        deck = deckArray.ToList();
    }


    public Card DrawCard()
    {
        Card nextCard = deck[0];
        deck.Remove(deck[0]);

        return nextCard;

    }

    public List<Card> GetDeck()
    {
        return deck;
    }



}
