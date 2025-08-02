public class Player
{
    GameManager gameManager;

    List<Card> hand = new List<Card>();

    public Player(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public void DrawCard()
    {
        Card nextCard = gameManager.DrawCard();
        gameManager.AceHandler(hand);

        hand.Add(nextCard);
    }

    public void DrawCard(List<Card> hand)
    {
        Card nextCard = gameManager.DrawCard();

        hand.Add(nextCard);
    }

    public Card GetCardInHand(int index)
    {
        return hand[index];
    }

    public List<Card> GetHand()
    {
        return hand;
    }

    public int GetSum()
    {
        return gameManager.GetSum(hand);
    }

    public void ResetHand()
    {
        //Console.WriteLine("Resetting player's hand, player's hand has", string.Join(", ", hand));
        hand.Clear();
        //Console.WriteLine("Reset player's hand, player's hand has", string.Join(", ", hand));
    }

    public void ResetHand(List<Card> hand)
    {
        hand.Clear();
    }

}