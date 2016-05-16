package org.softuni;

import java.util.Scanner;
import java.util.stream.Stream;

public class _15_RecursiveBinarySearch {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        int target = Integer.parseInt(in.nextLine().split("\\s+")[0]);
        int[] array = Stream.of(in.nextLine().split("\\s+")).mapToInt(Integer::parseInt).toArray();

        System.out.println(binarySearch(array, target));
    }

    public static int binarySearch(int[] array, int target) {

        return binarySearch(array, 0, array.length-1, target);
    }

    public static int binarySearch(int[] array, int start, int end, int target) {
        int middle = (start + end) / 2;
        if (end < start) {
            return -1;
        }

        if (target == array[middle]) {
            return middle;
        } else if (target < array[middle]) {
            return binarySearch(array, start, middle - 1, target);
        } else {
            return binarySearch(array, middle + 1, end, target);
        }
    }
}
