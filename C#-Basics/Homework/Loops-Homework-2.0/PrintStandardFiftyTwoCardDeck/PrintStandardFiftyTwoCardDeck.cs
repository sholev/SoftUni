using System;

class PrintStandardFiftyTwoCardDeck
{
    static void Main()
    {
        for (int i = 2; i <= 14; i++)
        {
            for (int l = 1; l <= 4; l++)
            {
                Console.Write("{0}", GetCard(i, l).PadLeft(4));
            }
            Console.WriteLine();
        }
    }

    private static string GetCard(int card, int suit)
    {
        string cardAndSuit = string.Empty;

        switch (card)
        {
            case 2:
                cardAndSuit += "2";
                break;
            case 3:
                cardAndSuit += "3";
                break;
            case 4:
                cardAndSuit += "4";
                break;
            case 5:
                cardAndSuit += "5";
                break;
            case 6:
                cardAndSuit += "6";
                break;
            case 7:
                cardAndSuit += "7";
                break;
            case 8:
                cardAndSuit += "8";
                break;
            case 9:
                cardAndSuit += "9";
                break;
            case 10:
                cardAndSuit += "10";
                break;
            case 11:
                cardAndSuit += "J";
                break;
            case 12:
                cardAndSuit += "Q";
                break;
            case 13:
                cardAndSuit += "K";
                break;
            case 14:
                cardAndSuit += "A";
                break;
            default:
                break;
        }

        switch (suit)
        {
            case 1:
                cardAndSuit += "♣";
                break;
            case 2:
                cardAndSuit += "♦";
                break;
            case 3:
                cardAndSuit += "♥";
                break;
            case 4:
                cardAndSuit += "♠";
                break;
            default:
                break;
        }

        return cardAndSuit;
    }
}