namespace ProblemsWithMatrices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class ParkingSystem
    {
        static void Main(string[] args)
        {
            int[] dimensions = Regex.Split(Console.ReadLine(), @"\s+").Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            Dictionary<int, List<bool>> parking = new Dictionary<int, List<bool>>();

            string input = Console.ReadLine();
            while (input != "stop")
            {
                int[] parameters = Regex.Split(input, @"\s+").Select(int.Parse).ToArray();

                int entryRow = parameters[0];
                int destinationRow = parameters[1];
                int destinationCol = parameters[2];

                if (!parking.ContainsKey(destinationRow))
                {
                    parking[destinationRow] = new List<bool>();
                    for (int i = 0; i < cols; i++)
                    {
                        parking[destinationRow].Add(false);
                    }
                }

                bool parkingSpotFound = false;

                if (parking[destinationRow][destinationCol] == false)
                {
                    parkingSpotFound = true;
                }
                else
                {
                    for (int i = 1; i < cols; i++)
                    {
                        if ((destinationCol - i > 0)
                            && parking[destinationRow][destinationCol - i] == false)
                        {
                            destinationCol -= i;
                            parkingSpotFound = true;
                            break;
                        }

                        if ((destinationCol + i < cols) &&
                            parking[destinationRow][destinationCol + i] == false)
                        {
                            destinationCol += i;
                            parkingSpotFound = true;
                            break;
                        }
                    }
                }

                if (parkingSpotFound)
                {
                    parking[destinationRow][destinationCol] = true;
                    int distance = Math.Abs(entryRow - destinationRow) + destinationCol + 1;
                    Console.WriteLine(distance);
                }
                else
                {
                    Console.WriteLine($"Row {destinationRow} full");
                }

                input = Console.ReadLine();
            }
        }
    }
}