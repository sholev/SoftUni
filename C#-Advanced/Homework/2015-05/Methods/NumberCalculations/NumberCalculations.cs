using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NumberCalculations
{
    static void Main()
    {
        double[][] jaggedArrayD = new double[][]
        {
            new double[] { 1.5, 3.755, 4.1, 5.43, 1.06, 0.3, 5.6 },
            new double[] { 1.1, 2.54, 3.44, 4.0, 5.0, 6.005, 6.6 },
            new double[] { 1.1, 1.1, 1.1 },
        };

        decimal[][] jaggedArrayM = new decimal[][]
        {
            new decimal[] { 7.5m, 3.755m, 4.1m },
            new decimal[] { 1.1m, 2.54m, 3.44m, 4.0m, 5.0m, 6.005m },
            new decimal[] { 7.7m, 7.7m, 7.7m, 8.8m, 8.8m, 8.8m, 8.8m },
        };

        Console.WriteLine("Double:");
        Console.WriteLine();
        foreach (var arr in jaggedArrayD)
        {
            string strArr = string.Join(", ", arr);
            Console.WriteLine("{{ {0} }}:", strArr);
            Console.WriteLine("Minimum - {0}", GetMin(arr));
            Console.WriteLine("Maximum - {0}", GetMax(arr));
            Console.WriteLine("Average - {0}", GetAvg(arr));
            Console.WriteLine("Sum - {0}", GetSum(arr));
            Console.WriteLine("Product - {0}", GetPrd(arr));
            Console.WriteLine(new string('-', 20));
        }

        Console.WriteLine("Decimal:");
        Console.WriteLine();
        foreach (var arr in jaggedArrayM)
        {
            string strArr = string.Join(", ", arr);
            Console.WriteLine("{{ {0} }}:", strArr);
            Console.WriteLine("Minimum - {0}", GetMin(arr));
            Console.WriteLine("Maximum - {0}", GetMax(arr));
            Console.WriteLine("Average - {0}", GetAvg(arr));
            Console.WriteLine("Sum - {0}", GetSum(arr));
            Console.WriteLine("Product - {0}", GetPrd(arr));
            Console.WriteLine(new string('-', 20));
        }
    }

    private static double GetPrd(double[] arr)
    {
        double product = 1.0; ;

        for (int i = 0; i < arr.Length; i++)
        {
            product *= arr[i];
        }

        return product;
    }

    private static double GetSum(double[] arr)
    {
        double sum = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return sum;
    }

    private static double GetAvg(double[] arr)
    {
        double average = 0;

        average = GetSum(arr) / arr.Length;

        return average;
    }

    private static double GetMax(double[] arr)
    {
        double max = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            if (max < arr[i])
            {
                max = arr[i];
            }
        }

        return max;
    }

    private static double GetMin(double[] arr)
    {
        double min = arr[0];

        for (int i = 0; i < arr.Length; i++)
        {
            if (min > arr[i])
            {
                min = arr[i];
            }
        }

        return min;
    }

    private static decimal GetPrd(decimal[] arr)
    {
        decimal product = 1.0m; ;

        for (int i = 0; i < arr.Length; i++)
        {
            product *= arr[i];
        }

        return product;
    }

    private static decimal GetSum(decimal[] arr)
    {
        decimal sum = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return sum;
    }

    private static decimal GetAvg(decimal[] arr)
    {
        decimal average = 0;

        average = GetSum(arr) / arr.Length;

        return average;
    }

    private static decimal GetMax(decimal[] arr)
    {
        decimal max = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            if (max < arr[i])
            {
                max = arr[i];
            }
        }

        return max;
    }

    private static decimal GetMin(decimal[] arr)
    {
        decimal min = arr[0];

        for (int i = 0; i < arr.Length; i++)
        {
            if (min > arr[i])
            {
                min = arr[i];
            }
        }

        return min;
    }
}