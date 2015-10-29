package org.softuni;

import java.util.Arrays;
import java.util.Scanner;

public class _02_SequencesOfEqualStrings {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        String[] strings = in.nextLine().split(" ");
        String previousString = strings[0];
        System.out.printf("%s ", previousString);
        for (int i = 1; i < strings.length; i++) {
            if (previousString.equals(strings[i])) {
                System.out.printf("%s ", strings[i]);
            } else {
                System.out.printf("\r\n%s ", strings[i]);
            }
            previousString = strings[i];
        }
    }
}
