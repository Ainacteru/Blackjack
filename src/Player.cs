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

}