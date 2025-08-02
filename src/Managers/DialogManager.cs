namespace Blackjack;

public class DialogManager
{
    CardsManager cardsManager = new CardsManager();
    Dealer dealer;
    GameManager gameManager;

    Player player;

    public DialogManager()
    {
        gameManager = new GameManager(cardsManager);
        dealer = new Dealer(gameManager);
        player = new Player(gameManager);
    }

    public void Start()
    {
        Console.Clear();

        Console.WriteLine("Welcome to Blackjack, type enter to play!");
        Console.ReadLine();
        Console.Clear();

        player.DrawCard();
        player.DrawCard();

        Console.WriteLine($"Your two starting cards are the: '{player.GetCardInHand(0)}' and the '{player.GetCardInHand(1)}'");

        HitOrStay();
    }

    public void HitOrStay()
    {

        Console.WriteLine("Do you 'hit', 'stay', or 'list' your cards?");

        string? answer = Console.ReadLine();
        switch (answer)
        {
            case "hit":
                Console.WriteLine();

                hit();
                break;

            case "stay":
                Console.WriteLine();

                stay();
                break;

            case "list":
                Console.Clear();
                Console.WriteLine("Your hand has: " + string.Join(", ", player.GetHand()));

                HitOrStay();
                break;

            default:
                Console.WriteLine("Not a valid answer, try again");
                Console.WriteLine();

                HitOrStay();
                break;
        }
    }

    private void hit()
    {
        Console.Clear();
        player.DrawCard();

        Console.WriteLine($"You drew '{player.GetCardInHand(player.GetHand().Count - 1)}'");


        if (gameManager.CheckIfBust(player.GetHand()))
        {
            Console.WriteLine("You busted!");
            Console.WriteLine("Your hand had: " + string.Join(", ", player.GetHand()));
            Console.WriteLine($"lost with a sum of {gameManager.GetSum(player.GetHand())}");

            PlayAgain();
        }
        else
        {
            HitOrStay();
        }
    }

    private void stay()
    {
        Console.Clear();
        Console.WriteLine("Your final hand: " + string.Join(", ", player.GetHand()));
        Console.WriteLine("Press enter to continue");

        Console.ReadLine();
        Console.Clear();

        DealerTurn();
    }


    private void DealerTurn()
    {


        Console.WriteLine("Waiting for dealer's hand...");

        Thread.Sleep(1000);
        dealer.DealerPlay();

        Console.WriteLine("Your final hand: " + string.Join(", ", player.GetHand()));
        FinalOutcome(dealer, player);
    }

    private void FinalOutcome(Dealer dealer, Player player)
    {
        Console.WriteLine();
        if ((dealer.GetSum() < 22) && (dealer.GetSum() > player.GetSum()))
        {
            Console.WriteLine("Dealer Wins!");
        }
        else if (dealer.GetSum() == player.GetSum())
        {
            Console.WriteLine("Its a tie!");
        }
        else
        {
            Console.WriteLine("You Win!");
        }

        PlayAgain();
    }

    private void PlayAgain() {
        cardsManager.GenerateDeck();

        player.ResetHand();
        dealer.ResetHand();

        Console.WriteLine("Type enter to play again or 'exit' to quit");
        
        if (!(Console.ReadLine() == "exit"))
        {
            Start();
        }
    }
}
