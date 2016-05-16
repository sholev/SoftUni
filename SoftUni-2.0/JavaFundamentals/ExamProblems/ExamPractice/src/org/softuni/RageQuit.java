package org.softuni;

import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

// Advanced C# Exam 19 July 2015

public class RageQuit {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        String input = in.nextLine().toUpperCase();
        Matcher rageBuddy = Pattern.compile("(\\D+)(\\d+)").matcher(input);
        StringBuilder result = new StringBuilder();
        while (rageBuddy.find()) {
            String forRepeat = rageBuddy.group(1);
            int repetitions = Integer.parseInt(rageBuddy.group(2));
            for (int i = 0; i < repetitions; i++) {
                result.append(forRepeat);
            }
        }
        Set<Character> counter = new HashSet<>();
        for (char c : result.toString().toCharArray()) {
            counter.add(c);
        }
        System.out.println("Unique symbols used: " + counter.size());
        System.out.println(result.toString());
    }
}
