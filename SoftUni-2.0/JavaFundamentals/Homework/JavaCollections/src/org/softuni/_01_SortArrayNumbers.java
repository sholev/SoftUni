package org.softuni;

import java.util.Arrays;
import java.util.Scanner;

public class _01_SortArrayNumbers {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        int numberCount = in.nextInt();
        int[] numberArray = new int[numberCount];
        for (int i = 0; i < numberCount; i++) {
            numberArray[i] = in.nextInt();
        }
        Arrays.sort(numberArray);
        Arrays.stream(numberArray).forEachOrdered(number -> System.out.printf("%d ", number));
    }
}
