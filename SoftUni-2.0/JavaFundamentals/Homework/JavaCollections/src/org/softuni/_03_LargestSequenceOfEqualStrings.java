package org.softuni;

import java.util.ArrayList;
import java.util.Scanner;

public class _03_LargestSequenceOfEqualStrings {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        String[] strings = in.nextLine().split(" ");
        ArrayList<String> longestSequence = new ArrayList<>();
        ArrayList<String> temporarySequence = new ArrayList<>();
        temporarySequence.add(strings[0]);
        longestSequence.add(strings[0]);

        for (int i = 1; i < strings.length; i++) {
            // If previous string is the same add to sequence.
            if (strings[i].equals(temporarySequence.get(0))) {
                temporarySequence.add(strings[i]);
            }
            if (temporarySequence.size() > longestSequence.size()) {
                longestSequence = temporarySequence;
            }
            // If previous string is not the same, reset the sequence.
            if (!strings[i].equals(temporarySequence.get(0))) {
                temporarySequence = new ArrayList<>();
                temporarySequence.add(strings[i]);
            }
        }

        System.out.println(String.join(" ", longestSequence));;
    }
}
