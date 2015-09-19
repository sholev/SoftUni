using System;

namespace MatrixOfNumbers
{
    class EnterTheMatrix
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter anything but an integer to exit.");
            while (true)
            {
                int numberN = 0;

                try
                {
                    Console.Write("Enter N: ");
                    numberN = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    return;
                }

                if ((1 <= numberN && numberN <= 20))
                {
                    for (int i = 0; i < numberN; i++)
                    {
                        for (int l = 0; l < numberN; l++)
                        {
                            Console.Write("{0,3}", i + l + 1);
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Input should be: 1 <= N <= 20");
                }

                Console.WriteLine(new string('-', 10));
            }
        }
    }
}
