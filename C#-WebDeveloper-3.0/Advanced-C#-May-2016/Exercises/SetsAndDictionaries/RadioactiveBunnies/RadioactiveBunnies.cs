namespace ProblemsWithMatrices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point Move(string direction)
        {
            Point currentPosition = new Point(this.X, this.Y);

            switch (direction)
            {
                case "U":
                    this.X--;
                    break;
                case "D":
                    this.X++;
                    break;
                case "L":
                    this.Y--;
                    break;
                case "R":
                    this.Y++;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return currentPosition;
        }
    }

    public class RadioactiveBunnies
    {
        public static void Main(string[] args)
        {
            var lairSize =
                Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            var lair = new string[lairSize[0]][];
            for (int i = 0; i < lairSize[0]; i++)
            {
                lair[i] = Console.ReadLine().ToCharArray().Select(c => c + "").ToArray();
            }

            var playerMoves = Console.ReadLine().ToCharArray().Select(c => c + "").ToList();

            Point playerLocation = GetPlayerLocation(lair);
            Point previousLocation = new Point(playerLocation.X, playerLocation.Y);
            bool playerWon = false;
            bool playerDead = false;

            while (!playerWon && !playerDead)
            {
                previousLocation = playerLocation.Move(playerMoves[0]);

                if (PointIsOutOfLair(playerLocation, lair))
                {
                    playerWon = true;
                }
                else if (lair[playerLocation.X][playerLocation.Y] == "B")
                {
                    playerDead = true;
                }
                else
                {
                    lair[playerLocation.X][playerLocation.Y] = "P";
                    lair[previousLocation.X][previousLocation.Y] = ".";
                }
                playerMoves.RemoveAt(0);

                var bunnies = new List<Point>();
                for (int row = 0; row < lair.Length; row++)
                {
                    for (int col = 0; col < lair[row].Length; col++)
                    {
                        if (lair[row][col] == "B")
                        {
                            bunnies.Add(new Point(row, col));
                        }
                    }
                }

                foreach (Point bunny in bunnies)
                {
                    Point up = new Point(bunny.X - 1, bunny.Y);
                    Point down = new Point(bunny.X + 1, bunny.Y);
                    Point left = new Point(bunny.X, bunny.Y - 1);
                    Point right = new Point(bunny.X, bunny.Y + 1);

                    var directions = new[] { up, down, left, right };

                    foreach (Point direction in directions)
                    {
                        if (!PointIsOutOfLair(direction, lair))
                        {
                            if (lair[direction.X][direction.Y] == "P")
                            {
                                playerDead = true;
                            }
                            lair[direction.X][direction.Y] = "B";
                        }
                    }
                }
            }

            if (playerWon)
            {
                if (lair[previousLocation.X][previousLocation.Y] == "P")
                {
                    lair[previousLocation.X][previousLocation.Y] = ".";
                }
                PrintField(lair);
                Console.WriteLine("won: {0} {1}", previousLocation.X, previousLocation.Y);
            }
            else if (playerDead)
            {
                PrintField(lair);
                Console.WriteLine("dead: {0} {1}", playerLocation.X, playerLocation.Y);
            }
        }

        private static void PrintField(string[][] lair)
        {
            foreach (string[] row in lair)
            {
                foreach (string col in row)
                {
                    Console.Write(col);
                }
                Console.WriteLine();
            }
        }

        private static bool PointIsOutOfLair(Point location, string[][] lair)
        {
            return location.X < 0 || location.Y < 0 || location.X >= lair.Length || location.Y >= lair[0].Length;
        }

        private static Point GetPlayerLocation(string[][] lair)
        {
            for (int row = 0; row < lair.Length; row++)
            {
                for (int col = 0; col < lair[row].Length; col++)
                {
                    if (lair[row][col].Equals("P"))
                    {
                        return new Point(row, col);
                    }
                }
            }
            return new Point(-1, -1);
        }
    }
}
