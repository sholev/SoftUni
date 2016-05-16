package org.softuni;

import java.util.Arrays;
import java.util.Scanner;

public class _08_OddAndEvenPairs {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);
        System.out.print("Enter array numbers separated by space: ");
        // http://stackoverflow.com/questions/6881458/converting-a-string-array-into-an-int-array-in-java
        int[] integers = Arrays.stream(in.nextLine().split("\\s+")).mapToInt(Integer::parseInt).toArray();

        if (integers.length % 2 == 0) {
            for (int i = 0; i < integers.length - 1; i += 2) {
                if (integers[i] % 2 == 0 && integers[i + 1] % 2 == 0) {
                    System.out.printf("%d, %d -> both are even\r\n", integers[i], integers[i + 1]);
                } else if (integers[i] % 2 == 1 && integers[i + 1] % 2 == 1) {
                    System.out.printf("%d, %d -> both are odd\r\n", integers[i], integers[i + 1]);
                } else {
                    System.out.printf("%d, %d -> different\r\n", integers[i], integers[i + 1]);
                }
            }
        }
        else {
            System.out.println("Invalid array length");
        }
    }
}
