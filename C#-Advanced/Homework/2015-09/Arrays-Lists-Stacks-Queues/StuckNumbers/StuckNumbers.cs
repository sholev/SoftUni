using System;

class StuckNumbers
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        
        string[] numbers = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        bool noResult = true;

        for (int n1 = 0; n1 < count; n1++)
        {
            for (int n2 = 0; n2 < count; n2++)
            {
                if (n1 != n2)
                {
                    for (int n3 = 0; n3 < count; n3++)
                    {
                        if (n3 != n1 && n3 != n2)
                        {
                            for (int n4 = 0; n4 < count; n4++)
                            {
                                if (n4 != n1 && n4 != n2 && n4 != n3 && 
                                    (numbers[n1] + numbers[n2] == numbers[n3] + numbers[n4]))
                                {
                                    Console.WriteLine("{0}|{1}=={2}|{3}",
                                        numbers[n1], numbers[n2], numbers[n3], numbers[n4]);

                                    noResult = false;
                                }
                            }
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
