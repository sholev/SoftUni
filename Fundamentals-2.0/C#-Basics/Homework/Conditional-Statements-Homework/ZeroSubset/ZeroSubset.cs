using System;

/* This prints the same subsets multiple times, in the condition
 * it is stated that it is not a problem. An example: "0 0 0 0 0"
 * Storing them and cleaning up before printing is a possible improvement.
 */

class ZeroSubset
{
    static void Main()
    {

        Console.WriteLine("Enter \"exit\" to exit.");

        while (true)
        {
            Console.Write("Enter 5 numbers in a single line separated by space:");
            string[] sNumbers = Console.ReadLine().Split(' ');

            if (string.Join(" ", sNumbers).Contains("exit"))
            {
                return;
            }
            else if (sNumbers.Length != 5)
            {
                Console.WriteLine("Wrong input.");
                Console.WriteLine(new string('-', 10));
                continue;
            }

            int[] iNumbers = new int[sNumbers.Length];
            bool subsetsExist = false;

            try
            {
                for (int i = 0; i < sNumbers.Length; i++)
                {
                    iNumbers[i] = int.Parse(sNumbers[i]);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong input.");
                continue;
            }

            if (iNumbers[0] + iNumbers[1] + iNumbers[2] + iNumbers[3] + iNumbers[4] == 0)
            {
                Console.WriteLine("{0} + {1} + {2} + {3} + {4} = 0", iNumbers[0], iNumbers[1], iNumbers[2], iNumbers[3], iNumbers[4]);
            }

            for (int i = 0; i < 5; i++) // What a mess. :(
            {
                for (int l = 0; l < 5; l++)
                {
                    if (i != l &&
                        iNumbers[i] + iNumbers[l] == 0)
                    {
                        Console.WriteLine("{0} + {1} = 0", iNumbers[i], iNumbers[l]);
                        subsetsExist = true;
                    }
                    for (int j = 0; j < 5; j++)
                    {
                        if (i != l && i != j && l != j &&
                            iNumbers[i] + iNumbers[l] + iNumbers[j] == 0)
                        {
                            Console.WriteLine("{0} + {1} + {2} = 0", iNumbers[i], iNumbers[l], iNumbers[j]);
                            subsetsExist = true;
                        }
                        for (int r = 0; r < 5; r++)
                        {
                            if (i != l && i != j && l != j && r != i && r != l && r != j &&
                                iNumbers[i] + iNumbers[l] + iNumbers[j] + iNumbers[r] == 0)
                            {
                                Console.WriteLine("{0} + {1} + {2} + {3} = 0", iNumbers[i], iNumbers[l], iNumbers[j], iNumbers[r]);
                                subsetsExist = true;
                            }
                        }
                    }
                }
            }

            if (!subsetsExist)
            {
                Console.WriteLine("no zero subsets");
            }

            Console.WriteLine(new string('-', 10));
        }
    }
}
