using System;

namespace KnightPath
{
    class Position
    {
        public int X;
        public int Y;
    }

    class ExamProblemFive
    {
        static void Main(string[] args)
        {
            int[,] board =
            {
                { 1, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            Position pos = new Position() { X = 0, Y = 0 };

            string movement = Console.ReadLine();           

            while (movement.ToLower() != "stop")
            {
                switch (movement)
                {
                    case "left up":
                        if (KnightIsInBounds(pos.X + 2, pos.Y - 1))
                        {
                            pos.X += 2;
                            pos.Y -= 1;

                            board[pos.Y, pos.X] = FlipBit(board[pos.Y, pos.X]);
                        }
                        break;

                    case "left down":
                        if (KnightIsInBounds(pos.X + 2, pos.Y + 1))
                        {
                            pos.X += 2;
                            pos.Y += 1; 

                            board[pos.Y, pos.X] = FlipBit(board[pos.Y, pos.X]);
                        }
                        break;

                    case "right up":
                        if (KnightIsInBounds(pos.X - 2, pos.Y - 1))
                        {
                            pos.X -= 2;
                            pos.Y -= 1;

                            board[pos.Y, pos.X] = FlipBit(board[pos.Y, pos.X]);
                        }
                        break;

                    case "right down":
                        if (KnightIsInBounds(pos.X - 2, pos.Y + 1))
                        {
                            pos.X -= 2;
                            pos.Y += 1;

                            board[pos.Y, pos.X] = FlipBit(board[pos.Y, pos.X]);
                        }
                        break;

                    case "up left":
                        if (KnightIsInBounds(pos.X + 1, pos.Y - 2))
                        {
                            pos.X += 1;
                            pos.Y -= 2;

                            board[pos.Y, pos.X] = FlipBit(board[pos.Y, pos.X]);
                        }
                        break;

                    case "up right":
                        if (KnightIsInBounds(pos.X - 1, pos.Y - 2))
                        {
                            pos.X -= 1;
                            pos.Y -= 2;

                            board[pos.Y, pos.X] = FlipBit(board[pos.Y, pos.X]);
                        }
                        break;

                    case "down left":
                        if (KnightIsInBounds(pos.X + 1, pos.Y + 2))
                        {
                            pos.X += 1;
                            pos.Y += 2;

                            board[pos.Y, pos.X] = FlipBit(board[pos.Y, pos.X]);
                        }
                        break;

                    case "down right":
                        if (KnightIsInBounds(pos.X - 1, pos.Y + 2))
                        {
                            pos.X -= 1;
                            pos.Y += 2;

                            board[pos.Y, pos.X] = FlipBit(board[pos.Y, pos.X]);
                        }
                        break;

                    default:
                        break;
                }

                //for (int row = 0; row < 8; row++)
                //{
                //    for (int col = 7; col >= 0; col--)
                //    {
                //        Console.Write("{0} ", board[row, col]);
                //    }
                //    Console.WriteLine();
                //}

                movement = Console.ReadLine();
            }

            // http://www.wikihow.com/Convert-from-Binary-to-Decimal#Using_Doubling_sub
            int temp = 0;
            bool boardEmpty = true;
            for (int row = 0; row < 8; row++)
            {
                for (int col = 7; col >= 0; col--)
                {
                    temp = (temp * 2) + board[row, col];
                }

                if (temp != 0)
                {
                    boardEmpty = false;
                    Console.WriteLine(temp);
                    temp = 0;
                }
            }

            if (boardEmpty)
            {
                Console.WriteLine("[Board is empty]");
            }
        }

        private static bool KnightIsInBounds(int X, int Y)
        {
            if (X > 7 || X < 0 || Y > 7 || Y < 0)
            {
                return false;
            }

            return true;
        }

        private static int FlipBit(int bit)
        {
            if (bit == 0)
            {
                bit = 1;
            }
            else
            {
                bit = 0;
            }

            return bit;
        }
    }
}
