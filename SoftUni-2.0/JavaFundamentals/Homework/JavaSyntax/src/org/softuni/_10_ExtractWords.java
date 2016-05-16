package org.softuni;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _10_ExtractWords {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);
        System.out.print("Input: ");
        String input = in.nextLine();

        List<String> words = new ArrayList<String>();
        Matcher wordFinder = Pattern.compile("[A-Za-z]+").matcher(input);
        while (wordFinder.find()) {
            words.add(wordFinder.group());
        }
        System.out.println(String.join(" ", words));
    }
}
