using System;

class SortArrayNumbersSelectionSort
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        decimal[] numbers = Array.ConvertAll(
            input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries),
            element => decimal.Parse(element));

        SelectionSort(ref numbers);

        Console.WriteLine(string.Join(" ", numbers));
    }

    // https://en.wikipedia.org/wiki/Selection_sort#Implementation
    private static void SelectionSort(ref decimal[] a)
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
                Swap(ref a[j], ref a[iMin]);
            }
        }
    }

    private static void Swap(ref decimal v1, ref decimal v2)
    {
        decimal temp = v1;
        v1 = v2;
        v2 = temp;
    }
}
