package org.softuni;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _11_StartsEndsWithUpperCase {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);
        System.out.print("Input words: ");
        String input = in.nextLine();

        List<String> matchingWords = new ArrayList<>();
        Matcher wordFinder = Pattern.compile("\\b[A-Z][A-Za-z]*[A-Z]\\b").matcher(input);
        while(wordFinder.find()) {
            matchingWords.add(wordFinder.group());
        }
        System.out.println(String.join(" ", matchingWords));
    }
}
