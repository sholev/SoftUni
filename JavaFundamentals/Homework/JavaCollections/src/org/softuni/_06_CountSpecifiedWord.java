package org.softuni;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class _06_CountSpecifiedWord {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        String input = in.nextLine().toLowerCase();
        String word = in.nextLine().toLowerCase();
        // Split by everything but the input word:
        String splitPattern = String.format("(?!%s\\b)\\W*\\b\\w*\\W*", word);
        // Convert to list for easy cleaning of empty entries, since the pattern has leftovers.
        ArrayList<String> leftovers = new ArrayList<>(Arrays.asList(input.split(splitPattern)));
        leftovers.removeIf(str -> str.equals(""));
        System.out.println(leftovers.size());
    }
}
