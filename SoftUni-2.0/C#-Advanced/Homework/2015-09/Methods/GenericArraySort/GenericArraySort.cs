using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GenericArraySort
{
    static void Main()
    {
        int[] numbers = { 1, 3, 4, 5, 1, 0, 5 };
        string[] strings = { "zaz", "cba", "baa", "azi" };
        DateTime[] dates =
        {
            new DateTime(2002, 3, 1),
            new DateTime(2015, 5, 6),
            new DateTime(2014, 1, 1)
        };

        SelectionSort(ref numbers);
        SelectionSort(ref strings);
        SelectionSort(ref dates);

        Console.WriteLine(string.Join(", ", numbers));
        Console.WriteLine(string.Join(", ", strings));
        Console.WriteLine(string.Join(", ", dates));
    }

    // https://en.wikipedia.org/wiki/Selection_sort#Implementation
    private static void SelectionSort(ref int[] a)
    {
        /* a[0] to a[n-1] is the array to sort */
        int i, j;
        int iMin;

        /* advance the position through the entire array */
        /*   (could do j < n-1 because single element is also min element) */
        for (j = 0; j < a.Length - 1; j++)
        {
            /* find the min element in the unsorted a[j .. n-1] */

            /* assume the min is the first element */
            iMin = j;
            /* test against elements after j to find the smallest */
            for (i = j + 1; i < a.Length; i++)
            {
                /* if this element is less, then it is the new minimum */
                if (a[i] < a[iMin])
                {
                    /* found new minimum; remember its index */
                    iMin = i;
                }
            }

            if (iMin != j)
            {
                int temp = a[j];
                a[j] = a[iMin];
                a[iMin] = temp;
            }
        }
    }

    private static void SelectionSort(ref string[] a)
    {
        int i, j;
        int iMin;
        
        for (j = 0; j < a.Length - 1; j++)
        {
            iMin = j;
            for (i = j + 1; i < a.Length; i++)
            {
                if (string.Compare(a[i], a[iMin]) == -1)
                {
                    iMin = i;
                }
            }

            if (iMin != j)
            {
                string temp = a[j];
                a[j] = a[iMin];
                a[iMin] = temp;
            }
        }
    }

    private static void SelectionSort(ref DateTime[] a)
    {
        int i, j;
        int iMin;

        for (j = 0; j < a.Length - 1; j++)
        {
            iMin = j;
            for (i = j + 1; i < a.Length; i++)
            {
                if (a[i] < a[iMin])
                {
                    iMin = i;
                }
            }

            if (iMin != j)
            {
                DateTime temp = a[j];
                a[j] = a[iMin];
                a[iMin] = temp;
            }
        }
    }
}
