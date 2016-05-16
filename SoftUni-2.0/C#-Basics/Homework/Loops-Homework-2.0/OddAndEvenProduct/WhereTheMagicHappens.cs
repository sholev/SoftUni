using System;

namespace OddAndEvenProduct
{
    class WhereTheMagicHappens
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a single line of integers separated by \" \". Or \"exit\" to exit.");

            while (true)
            {
                Console.Write("Input: ");
                string[] sArray = Console.ReadLine().Split(' ');
                int[] iArray = new int[sArray.Length];
                int oddProduct = 1;
                int evenProduct = 1;

                if (sArray[0].ToLower() == "exit")
                {
                    return;
                }
                else
                {
                    try
                    {
                        for (int i = 0; i < iArray.Length; i++)
                        {
                            iArray[i] = int.Parse(sArray[i]);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Bad input.");
                        continue;
                    }

                    for (int i = 0; i < iArray.Length; i++)
                    {
                        if (i % 2 == 0)
                        {
                            oddProduct *= iArray[i];
                        }
                        else
                        {
                            evenProduct *= iArray[i];
                        }
                    }

                    if (oddProduct == evenProduct)
                    {
                        Console.WriteLine("yes\r\nproduct = {0}", oddProduct);
                    }
                    else
                    {
                        Console.WriteLine("no\r\nodd_product = {0}\r\neven_product = {1}",
                            oddProduct, evenProduct);
                    }
                }

                Console.WriteLine(new string('-', 10));
            }
        }
    }
}
