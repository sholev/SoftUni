package org.softuni;

import java.util.*;
import java.util.stream.Collectors;

public class _04_LongestIncreasingSequence {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        int[] intArray = Arrays.stream(in.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();
        ArrayList<Integer> longestSequence = new ArrayList<>();
        ArrayList<Integer> temporarySequence = new ArrayList<>();
        temporarySequence.add(intArray[0]);
        longestSequence.add(intArray[0]);
        System.out.printf("%s ", intArray[0]);

        for (int i = 1; i < intArray.length; i++) {
            // If previous number is smaller add to sequence and print on the same row.
            if (intArray[i - 1] < intArray[i]) {
                temporarySequence.add(intArray[i]);
                System.out.printf("%s ", intArray[i]);
            }
            if (temporarySequence.size() > longestSequence.size()) {
                longestSequence = temporarySequence;
            }
            // If previous number is bigger or equal, reset the sequence and print on a new row.
            if (intArray[i - 1] >= intArray[i]) {
                temporarySequence = new ArrayList<>();
                temporarySequence.add(intArray[i]);
                System.out.printf("\r\n%s ", intArray[i]);
            }
        }
        // I wish string join worked with number arrays...
        System.out.printf("\r\nLongest: %s", longestSequence.stream().map(Object::toString).collect(Collectors.joining(" ")));
    }
}
