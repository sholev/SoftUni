package org.softuni;

import java.util.Scanner;

public class _07_CountSubstringOccurrences {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        String input = in.nextLine().toLowerCase();
        String substring = in.nextLine().toLowerCase();
        int count = 0;
        int index = 0;

        while ((index = input.indexOf(substring, index)) != -1) {
            index++;
            count++;
        }

        System.out.println(count);
    }
}
