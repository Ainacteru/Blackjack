public class Card
{
    public string Suit { get; set; }     // Spade, Heart, Clubs, Diamonds
    public string Rank { get; set; }     // Ace, 2, 3, ..., 10, Jack, Queen, King
    public int Value { get; set; }        // 1-11 depending on Blackjack value

    public Card(string rank, string suit)
    {
        this.Rank = rank;
        this.Suit = suit;

        if (Rank == "Ace")
        {
            Value = 1;
        }
        else if (Rank == "Jack" || Rank == "Queen" || Rank == "King")
        {
            Value = 10;
        }
        else
        {
            Value = int.Parse(Rank);
        }
    }

    public int GetValue()
    {
        return Value;
    }

    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}