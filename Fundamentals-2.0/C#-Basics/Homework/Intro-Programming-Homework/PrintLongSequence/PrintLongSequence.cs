using System;

//It could be just a loop, but for the sake of fun :)

class PrintLongSequence
{
    static void PrintRecursion(short n)
    {
        if (n > 1)
        {
            n--;
            PrintRecursion(n);
            Console.Write(',');

            if ((n % 2) == 1)
            {
                Console.Write((n * -1) - 2);
            }
            else
            {
                Console.Write(n + 2);
            }
        }
    }

    static void Main()
    {
        short sequenceLenght = 1000;

        Console.Write('2');
        PrintRecursion(sequenceLenght);
        Console.Write('\n');
    }
}
