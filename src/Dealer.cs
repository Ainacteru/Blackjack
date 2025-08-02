using System.Diagnostics;

public class Dealer
{
    GameManager gameManager;
    Player dealer;

    List<Card> hand = new List<Card>();
    public Dealer(GameManager gameManager)
    {
        this.gameManager = gameManager;
        dealer = new Player(gameManager);
    }
    public void DealerPlay()
    {
        //has to draw cards until it is more or equal to 17
        dealer.DrawCard(hand);
        dealer.DrawCard(hand);

        Console.WriteLine($"Dealer starts with cards '{hand[0]}' and '{hand[1]}'");
        Thread.Sleep(2000);
        Console.WriteLine();

        gameManager.AceHandler(hand);

        while (gameManager.GetSum(hand) < 17)
        {
            dealer.DrawCard(hand);
            gameManager.AceHandler(hand);

            Console.WriteLine($"Dealer drew '{hand[hand.Count - 1]}'");
            Thread.Sleep(1000);
        }

        if (!gameManager.CheckIfBust(hand))
        {
            Console.WriteLine();
            Console.WriteLine("Dealer's final hand has: " + string.Join(", ", hand));
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Dealer's final hand has: " + string.Join(", ", hand));
            Console.WriteLine("Dealer Bust!");
            Console.WriteLine();
        }
    }

    public int GetSum()
    {
        int handSum = gameManager.GetSum(hand);

        //Console.WriteLine($" dealer sum is {handSum}");
        return handSum;
    }

    public void ResetHand()
    {
        //Console.WriteLine("Resetting dealer's hand, dealer's hand has", string.Join(", ", hand));
        dealer.ResetHand(hand);
        //Console.WriteLine("Reset dealer's hand, dealer's hand has", string.Join(", ", hand));
    }
        
}