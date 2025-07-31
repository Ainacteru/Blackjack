using System;
using System.Data.Common;

public class GameManager
{
    //private List<int> cards = new List<int>();

    CardsManager cardsManager;

    public GameManager(CardsManager cardsManager)
    {
        this.cardsManager = cardsManager;
    }

    public int ChooseCard()
    {
        int randomCard = cardsManager.GetRandomCard();


        return randomCard;

    }

    public bool? CheckIfLost(List<int> cards)
    {
        int sum = GetSum(cards);

        if (sum < 21)
        {
            //Console.WriteLine("null");
            return null;
        }
        else if (sum > 21)
        {
            //Console.WriteLine("true");
            return true;
        }
        else
        {
            //Console.WriteLine("false");
            return false;
        }
    }

    public int GetSum(List<int> cards)
    {
        int cardsSum = 0;
        foreach (var card in cards)
        {
            cardsSum += card;
        }
        //Console.WriteLine(cardsSum); 
        return cardsSum;
    }

    public void AceHandler(List<int> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            if ((cards[i] == 1) && (GetSum(cards) < 21))
            {
                cards[i] = 11;
                return;
            }

            if ((cards[i] == 11) && (GetSum(cards) > 21))
            {
                cards[i] = 1;
                return;
            }
        }
    }
}
