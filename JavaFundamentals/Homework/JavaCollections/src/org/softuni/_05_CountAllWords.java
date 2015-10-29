package org.softuni;

import java.util.Scanner;

public class _05_CountAllWords {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        String[] words = in.nextLine().split("\\W+");
        System.out.println(words.length);
    }
}
