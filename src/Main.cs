using System.Security.Cryptography;

namespace Blackjack;

class MainProgram
{
    GameManager? gameManager;

    private List<int> cards = new List<int>();
    static void Main(string[] args)
    {
        MainProgram mainProgram = new MainProgram();

        mainProgram.main();
    }

    private void main()
    {
        CardsManager cardmanager = new CardsManager();
        gameManager = new GameManager(cardmanager);

        cards.Add(gameManager.ChooseCard());
        cards.Add(gameManager.ChooseCard());

        Console.WriteLine($"You have two cards. They are {cards[0]} and {cards[1]}");

        askForHitStay();
    }

    private void askForHitStay()
    {
        Console.WriteLine("Do you 'hit' or 'stay'?");

        string? answer = Console.ReadLine();
        switch (answer)
        {
            case "hit":
                hit();
                break;

            case "stay":
                stay();
                break;

            default:
                Console.WriteLine("Not a valid answer, try again");
                askForHitStay();
                break;
        }
    }

    private void hit()
    {
        Console.WriteLine("You chose to hit");

        int newCard = gameManager.ChooseCard();
        cards.Add(newCard);

        gameManager.AceHandler(cards);
        
        int card = cards[cards.Count - 1];

        if (card == 1 || card == 11)
        {
            Console.WriteLine($"Drew: ace");
        }
        else
        {
            Console.WriteLine($"Drew: {card}");
        }

        if (!(gameManager.CheckIfLost(cards) == true))
        {
            askForHitStay();
        }
        else
        {
            Console.WriteLine("BUST!");
        }
    }

    private void stay()
    {

        Console.WriteLine("Your final hand: " + string.Join(", ", cards));
        Console.WriteLine("Press enter to continue");

        Console.ReadLine();
        Console.WriteLine();

        Dealer dealer = new Dealer(gameManager);

        Console.WriteLine("Waiting for dealer's hand...");

        dealer.DealerDecision();
    }


}
