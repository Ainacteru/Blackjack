using System;
using System.Data.Common;

public class GameManager
{
    CardsManager cardsManager;

    public GameManager(CardsManager cardsManager)
    {
        this.cardsManager = cardsManager;
    }

    public Card DrawCard()
    {
        Card nextCard = cardsManager.DrawCard();

        return nextCard;
    }

    public int GetSum(List<Card> hand)
    {
        int cardsSum = 0;
        foreach (var card in hand)
        {
            cardsSum += card.GetValue();
        }
        //Console.WriteLine(cardsSum); 
        return cardsSum;
    }

    public void AceHandler(List<Card> hand)
    {
        if (GetSum(hand) > 21)
        {
            foreach (Card card in hand)
            {
                if (GetSum(hand) > 21)
                {
                    if (card.Value == 11)
                    {
                        card.Value = 1;
                    }
                }
                else
                {
                    if (card.Value == 1)
                    {
                        card.Value = 11;
                    }
                }
            }
        }
    }

    public bool CheckIfBust(List<Card> hand)
    {
        if (GetSum(hand) > 21)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
