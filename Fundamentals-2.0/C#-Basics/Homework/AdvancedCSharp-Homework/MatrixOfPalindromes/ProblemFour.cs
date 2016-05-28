using System;

namespace MatrixOfPalindromes
{
    class ProblemFour
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter anything but int to exit.");
            int rows = 0;
            int cols = 0;

            while (true)
            {
                try
                {
                    Console.WriteLine();
                    Console.Write("Rows: ");
                    rows = int.Parse(Console.ReadLine());
                    Console.Write("Columns: ");
                    cols = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    return;
                }

                Console.WriteLine();

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        Console.Write("{0}{1}{2}".PadLeft(10), (char)('a' + r), (char)('a' + c), (char)('a' + r));
                    }
                    Console.WriteLine();
                }
                
                Console.WriteLine(new string('-', 10));
            }
            
        }
    }
}
