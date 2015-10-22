package org.softuni;

import java.util.Arrays;
import java.util.Scanner;

public class _13_FirstOddOrEvenElements {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);
        System.out.print("Enter array numbers separated by space: ");
        // http://stackoverflow.com/questions/6881458/converting-a-string-array-into-an-int-array-in-java
        int[] integers = Arrays.asList(in.nextLine().split("\\s+")).stream().mapToInt(Integer::parseInt).toArray();
        System.out.print("Enter command: ");
        String[] command = in.nextLine().split("\\s+");

        if (command[2].equals("odd")) {
            int[] oddIntegers = Arrays
                    .stream(integers)
                    .filter(number -> number % 2 == 1)
                    .limit(Integer.parseInt(command[1]))
                    .toArray();

            System.out.println(Arrays.toString(oddIntegers));
        }
        else {
            int[] evenIntegers = Arrays
                    .stream(integers)
                    .filter(number -> number % 2 == 0)
                    .limit(Integer.parseInt(command[1]))
                    .toArray();

            System.out.println(Arrays.toString(evenIntegers));
        }
    }
}
