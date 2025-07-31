using System;
using System.Data.Common;

class GameManager
{
    List<int> cards = new List<int>();

    CardsManager cardsManager;

    public GameManager(CardsManager cardsManager)
    {
        this.cardsManager = cardsManager;
    }

    public int GetCard(int index)
    {
        return cards[index];
    }

    public void ChooseCard()
    {
        int randomCard = cardsManager.GetRandomCard();

        cards.Add(randomCard);

        if (CheckIfLost(GetSum()) == true)
        {
            //bust!
        }
    }

    public int GetCardsLength()
    {
        return cards.Count();
    }

    public bool? CheckIfLost(int sum)
    {
        switch (sum)
        {
            case 21:
                return false;
            case 22:
                return true;
            default:
                return null;
        }
    }

    public int GetSum()
    {
        int cardsSum = 0;
        foreach (var card in cards)
        {
            cardsSum += card;
        }
        //Console.WriteLine(cardsSum); //
        return cardsSum;
    }
}
