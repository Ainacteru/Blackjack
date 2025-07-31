public class CardsManager
{
    private List<int> cards = new List<int>();

    public CardsManager()
    {
        SetupCards(cards);
    }

    public void SetupCards(List<int> cards)
    {
        for (int rank = 0; rank < 13; rank++)
        {
            for (int suit = 0; suit < 4; suit++)
            {
                if (rank >= 10) // black jack face cards are all 10s
                {
                    cards.Add(10);
                }
                else { 
                    cards.Add(rank + 1);
                }
            }
        }

        foreach (var card in cards)
        {
            Console.WriteLine(card);
        }     
    }

    public List<int> GetCards()
    {
        return cards;
    }

    public int GetRandomCard()
    {
        var random = new Random();
        int card = random.Next(cards.Count);

        return cards[card];
    }

}
