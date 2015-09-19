using System;

class PlayWithIntDoubleString
{
    static void Main()
    {
        string choice = string.Empty;

        int integer = 0;
        double number = 0;
        string text = string.Empty;

        while (true)
        {
            Console.WriteLine(new string('-', 10));
            Console.Write("1 --> int\r\n2 --> double\r\n3 --> string\r\nAnything else for exit.\r\nPlease choose a type: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Please enter a int: ");
                    integer = int.Parse(Console.ReadLine());
                    Console.WriteLine(integer + 1);
                    break;

                case "2":
                    Console.Write("Please enter a double: ");
                    number = double.Parse(Console.ReadLine());
                    Console.WriteLine(number + 1.0);
                    break;

                case "3":
                    Console.Write("Please enter a string: ");
                    text = Console.ReadLine();
                    Console.WriteLine(text + '*');
                    break;

                default:
                    return;
            }
        }
    }
}