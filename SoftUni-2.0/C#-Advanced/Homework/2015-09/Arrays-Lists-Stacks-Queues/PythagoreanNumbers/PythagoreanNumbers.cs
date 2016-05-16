using System;

class PythagoreanNumbers
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        int[] numbers = new int[count];

        for (int i = 0; i < count; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        bool noResult = true;

        for (int n1 = 0; n1 < count; n1++)
        {
            for (int n2 = 0; n2 < count; n2++)
            {
                if (numbers[n2] >= numbers[n1])
                {
                    for (int n3 = 0; n3 < count; n3++)
                    {
                        if (numbers[n3] >= numbers[n2] &&
                            (numbers[n1] * numbers[n1] +
                            numbers[n2] * numbers[n2] ==
                            numbers[n3] * numbers[n3]))
                        {
                            Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}",
                                numbers[n1], numbers[n2], numbers[n3]);

                            noResult = false;
                        }
                    }
                }
            }
        }

        if (noResult)
        {
            Console.WriteLine("No");
        }
    }
}