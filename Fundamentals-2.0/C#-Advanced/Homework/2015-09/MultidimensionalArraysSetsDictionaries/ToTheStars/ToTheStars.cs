using System;

class ToTheStars
{
    struct ObjectInSpace
    {
        public string name;
        public decimal x;
        public decimal y;
    }
    static void Main()
    {
        string[] input = new string[3];

        ObjectInSpace[] stars = new ObjectInSpace[3];
        for (int i = 0; i < stars.Length; i++)
        {
            input = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            stars[i].name = input[0];
            stars[i].x = decimal.Parse(input[1]);
            stars[i].y = decimal.Parse(input[2]);
        }

        ObjectInSpace ship = new ObjectInSpace();
        input = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        ship.name = "SSVNormandy";
        ship.x = decimal.Parse(input[0]);
        ship.y = decimal.Parse(input[1]);

        decimal movement = 0;
        movement = decimal.Parse(Console.ReadLine());

        for (decimal i = 0; i <= movement; i++)
        {
            printShipLocation(ship, stars, i);
        }        
    }

    private static void printShipLocation(ObjectInSpace ship, ObjectInSpace[] stars, decimal i)
    {
        string shipLocation = "space";

        foreach (var star in stars)
        {
            if ((ship.x >= star.x - 1 && ship.x <= star.x + 1) &&
                (ship.y + i >= star.y - 1 && ship.y + i <= star.y + 1))
            {
                shipLocation = star.name.ToLower();
            }
        }

        Console.WriteLine(shipLocation);
    }
}
