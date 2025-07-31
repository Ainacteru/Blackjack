using System;

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
    }

    public int GetCardsLength()
    {
        return cards.Count();
    }

}
