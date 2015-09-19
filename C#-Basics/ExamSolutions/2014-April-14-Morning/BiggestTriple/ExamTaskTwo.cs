using System;
using System.Linq;

namespace BiggestTriple
{
    class ExamTaskTwo
    {
        static void Main(string[] args)
        {
            int[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            // tripletSums will be half the numbers.Lenth plus one more if there is leftover
            int[] tripletSums = new int[(numbers.Length / 3) + (numbers.Length % 3 == 0 ? 0 : 1)];

            int counter = 3; 
            int index = 0;   // tripletSums index

            for (int i = 0; i < numbers.Length; i++)
            {
                tripletSums[index] += numbers[i];
                counter--;

                if (counter == 0)   // if we've done three numbers
                {
                    index++;        // continue with the next sum
                    counter = 3;    // start counting three again
                }
            }

            // the index of the last number of the biggest triplet will be equal to the index of (tripletSums.Max() + 1) * 3
            int biggestTripletPosition = (Array.IndexOf(tripletSums, tripletSums.Max()) + 1) * 3;

            for (int i = 3; i > 0; i--)
            {
                // if there are less than 3 numbers we will get out of range,
                // so we check if we are in range
                if (biggestTripletPosition - i < numbers.Length)
                {
                    Console.Write("{0} ", numbers[biggestTripletPosition - i]);
                }
            }
        }
    }
}
