namespace Blackjack;

public class DialogManager
{
    CardsManager cardsManager = new CardsManager();
    GameManager gameManager;

    Player player;

    public DialogManager()
    {
        gameManager = new GameManager(cardsManager);
        player = new Player(gameManager);
    }

    public void Start()
    {
        Console.Clear();

        Console.WriteLine("Welcome to Blackjack, type enter to play!");
        Console.ReadLine();

        player.DrawCard();
        player.DrawCard();

        Console.WriteLine($"Your two starting cards are the: '{player.GetCardInHand(0)}' and the '{player.GetCardInHand(1)}'");

        HitOrStay();
    }

    public void HitOrStay()
    {
        Console.WriteLine("Do you 'hit' or 'stay'?");

        string? answer = Console.ReadLine();
        switch (answer)
        {
            case "hit":
                Console.WriteLine();

                hit();
                break;

            case "stay":
                stay();
                break;

            case "list":
                Console.WriteLine("Your hand has: " + string.Join(", ", player.GetHand()));
                Console.WriteLine();

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
        player.DrawCard();

        Console.WriteLine($"You drew '{player.GetCardInHand(player.GetHand().Count - 1)}'");


        if (gameManager.CheckIfBust(player.GetHand()) == true)
        {
            Console.WriteLine("BUST!");
        }
        else
        {
            HitOrStay();
        }
    }

    private void stay()
    {
        Console.WriteLine("Your final hand: " + string.Join(", ", player.GetHand()));
        Console.WriteLine("Press enter to continue");

        Console.ReadLine();

        DealerTurn();
    }


    private void DealerTurn()
    {
        Dealer dealer = new Dealer(gameManager);

        Console.WriteLine("Waiting for dealer's hand...");

        dealer.DealerPlay();
    }
}

// GameManager gameManager = new GameManager();

    // private void main()
    // {
    //     CardsManager cardmanager = new CardsManager();
    //     gameManager = new GameManager(cardmanager);

    //     // int card1 =(gameManager.ChooseCard());
    //     // int card2 =(gameManager.ChooseCard());

    //     string card1 = "1";
    //     string card2 = "10";

    //     cards.Add(Int32.Parse(card1));
    //     cards.Add(Int32.Parse(card2));

    //     if (card1 == "1")
    //     {
    //         card1 = "Ace";
    //     }
    //     else if(card2 == "1")
    //     {
    //         card2 = "Ace";
    //     }

    //     gameManager.AceHandler(cards);

    //     Console.WriteLine($"You have two cards. They are {card1} and {card2}");


    //     askForHitStay();
    // }

    // private void askForHitStay()
    // {
    //     Console.WriteLine("Do you 'hit' or 'stay'?");

    //     string? answer = Console.ReadLine();
    //     switch (answer)
    //     {
    //         case "hit":
    //             hit();
    //             break;

    //         case "stay":
    //             stay();
    //             break;

    //         case "list":
    //             Console.WriteLine("Your hand has: " + string.Join(", ", cards));
    //             askForHitStay();
    //             break;

    //         default:
    //             Console.WriteLine("Not a valid answer, try again");
    //             askForHitStay();
    //             break;
    //     }
    // }

    // private void hit()
    // {
    //     Console.WriteLine("You chose to hit");

    //     int newCard = gameManager.ChooseCard();
    //     cards.Add(newCard);

    //     gameManager.AceHandler(cards);

    //     int card = cards[cards.Count - 1];

    //     if (card == 1 || card == 11)
    //     {
    //         Console.WriteLine($"Drew: ace");
    //     }
    //     else
    //     {
    //         Console.WriteLine($"Drew: {card}");
    //     }

    //     if (!(gameManager.CheckIfLost(cards) == true))
    //     {
    //         askForHitStay();
    //     }
    //     else
    //     {
    //         Console.WriteLine("BUST!");
    //     }
    // }

    // private void stay()
    // {

    //     Console.WriteLine("Your final hand: " + string.Join(", ", cards));
    //     Console.WriteLine("Press enter to continue");

    //     Console.ReadLine();
    //     Console.WriteLine();

    //     Dealer dealer = new Dealer(gameManager);

    //     Console.WriteLine("Waiting for dealer's hand...");

    //     dealer.DealerDecision();
    // }