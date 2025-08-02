namespace Blackjack;

class MainProgram
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Blackjack...");
        Thread.Sleep(2500);

        DialogManager dialogManager = new DialogManager();

        dialogManager.Start();
    }
}
