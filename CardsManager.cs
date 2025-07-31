using System;

class CardsManager
{
    public static int[] cards = new int[13];

    public CardsManager()
    {
        SetupCards(cards);
    }

    public void SetupCards(int[] cards)
    {
        for (int i = 0; i < 13; i++)
        {
            cards[i] = i + 1;
        }
    }

    public int[] GetCards()
    {
        return cards;
    }

    public int GetRandomCard()
    {
        var random = new Random();
        int card = random.Next(cards.Length);

        return card;
    }

}
