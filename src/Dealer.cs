
namespace Blackjack;

public class Dealer
{
    private List<int> cards = new List<int>();
    GameManager gameManager;
    public Dealer(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public void DealerDecision()
    {
        cards.Add(gameManager.ChooseCard());
        cards.Add(gameManager.ChooseCard());

        Console.WriteLine("Starting hand: " + string.Join(", ", cards));
        int sum = GetSum();

        while (sum < 17)
        {
            int newCard = gameManager.ChooseCard();
            cards.Add(newCard);
            gameManager.AceHandler(cards);

            if (newCard == 1 || newCard == 11)
            {
                Console.WriteLine($"Drew: ace");
            }
            else
            {
                Console.WriteLine($"Drew: {newCard}");
            }

            sum = GetSum();

            if (sum > 21)
            {
                Console.WriteLine("Dealer bust!");
                break;
            }
        }

        Console.WriteLine("Final dealer hand: " + string.Join(", ", cards));
        Console.WriteLine("Final sum: " + GetSum());
    }
    
    private int GetSum()
    {
        int cardsSum = 0;
        foreach (var card in cards)
        {
            cardsSum += card;
        }
        //Console.WriteLine($"sum: {cardsSum}"); 
        return cardsSum;
    }
}