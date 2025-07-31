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

        cards.Add(gameManager.ChooseCard());


        int card = cards[cards.Count - 1];

        Console.WriteLine("Your hand: " + string.Join(", ", cards));
        //Console.WriteLine("Final sum: " + gameManager.GetSum(cards));

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
        Dealer dealer = new Dealer(gameManager);

        Console.WriteLine("You chose to stay");
        Console.WriteLine("Waiting for dealer's hand...");

        dealer.DealerDecision();
    }


}
