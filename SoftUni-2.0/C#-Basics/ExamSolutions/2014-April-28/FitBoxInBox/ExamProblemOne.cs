using System;

namespace FitBoxInBox
{
    class ExamProblemOne
    {
        class Box
        {
            public int width = 0;
            public int height = 0;            
            public int depth = 0;

            private int temp = 0;
            private bool flipper = true;

            public void Flip()
            {
                if (flipper)
                {
                    temp = height;
                    height = depth;
                    depth = temp;

                    flipper = !flipper;
                }
                else
                {
                    temp = width;
                    width = depth;
                    depth = temp;

                    flipper = !flipper;
                }
            }

            public void PrintBox()
            {
                Console.Write("({0}, {1}, {2})", width, height, depth);
            }

            public int GetBoxVolume()
            {
                return height * width * depth;
            }

            public bool DoesFitInside (Box B)
            {
                if (width < B.width && height < B.height && depth < B.depth)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        static void Main(string[] args)
        {
            Box firstBox = new Box();
            Box secondBox = new Box();

            firstBox.width = int.Parse(Console.ReadLine());
            firstBox.height = int.Parse(Console.ReadLine());
            firstBox.depth = int.Parse(Console.ReadLine());

            secondBox.width = int.Parse(Console.ReadLine());
            secondBox.height = int.Parse(Console.ReadLine());
            secondBox.depth = int.Parse(Console.ReadLine());

            if (firstBox.GetBoxVolume() < secondBox.GetBoxVolume())
            {
                for (int i = 0; i < 6; i++)
                {
                    if (firstBox.DoesFitInside(secondBox))
                    {
                        firstBox.PrintBox();
                        Console.Write(" < ");
                        secondBox.PrintBox();
                        Console.WriteLine();
                    }                    
                    secondBox.Flip();
                }
            }
            else if (firstBox.GetBoxVolume() > secondBox.GetBoxVolume())
            {
                for (int i = 0; i < 6; i++)
                {
                    if (secondBox.DoesFitInside(firstBox))
                    {
                        secondBox.PrintBox();
                        Console.Write(" < ");
                        firstBox.PrintBox();
                        Console.WriteLine();
                    }
                    firstBox.Flip();
                }
            }
        }
    }
}
