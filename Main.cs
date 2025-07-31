using System.Security.Cryptography;

namespace Blackjack;

class MainProgram
{
    GameManager? gameManager;
    static void Main(string[] args)
    {
        MainProgram mainProgram = new MainProgram();

        mainProgram.main();
    }

    private void main()
    {
        CardsManager cardmanager = new CardsManager();
        gameManager = new GameManager(cardmanager);

        gameManager.ChooseCard();
        gameManager.ChooseCard();

        Console.WriteLine($"You have two cards. They are {gameManager.GetCard(0)} and {gameManager.GetCard(1)}");

        askForHitStay();
    }

    private void askForHitStay()
    {
        Console.WriteLine("Do you 'hit' or 'stay'?");

        string? answer = Console.ReadLine();
        switch (answer)
        {
            case "hit":
                Console.WriteLine("You chose to hit");
                break;
            case "stay":
                Console.WriteLine("You chose to stay");
                Console.WriteLine("Waiting for dealer's hand");
                break;
            default:
                Console.WriteLine("Not a valid answer, try again");
                break;
        }
    }

    private void hit()
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        gameManager.ChooseCard();
        int card = gameManager.GetCard(gameManager.GetCardsLength());

        Console.WriteLine($"Your card is {card}");


    }


}
