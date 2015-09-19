using System;

class CheckPlayCard
{
    static void Main()
    {
        Console.WriteLine("Enter \"exit\" to exit.");
        Console.WriteLine(new String('-', 10));

        while (true)
        {
            Console.Write("Enter play card: ");
            string playCard = Console.ReadLine();

            switch (playCard)
            {
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "10":
                case "J":
                case "Q":
                case "K":
                case "A":
                    Console.WriteLine("yes");
                    break;
                case "exit":
                    return;
                default:
                    Console.WriteLine("no");
                    break;
            }
            Console.WriteLine(new String('-', 10));
        }
    }
}
