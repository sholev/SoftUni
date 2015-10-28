package org.softuni;

import java.util.*;
import java.util.regex.*;

// Java Fundamentals - 4 October 2015

public class DragonSharp {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        int lines = Integer.parseInt(in.nextLine());

        int error = -1;
        List<String> codeLines = new ArrayList<>();
        Pattern potatoFinder = Pattern.compile("(?<=\").+(?=\")");

        for (int i = 0; i < lines; i++) {
            String input = in.nextLine();
            codeLines.add(input);
            Matcher matchFriend = potatoFinder.matcher(input);
            String JACK;
            if (matchFriend.find()) {
                JACK = matchFriend.group();
            } else {
                JACK = "COULDN'T FIND JACK, BOSS";
            }
            if (    error == -1 &&
                    !input.endsWith(";") ||
                    JACK.equals("COULDN'T FIND JACK, BOSS")
                    ) {
                error = i + 1;
            }
        }

        if (error != -1) {
            System.out.println("Compile time error @ line " + error);
        } else {
            boolean lastIfIsTrue = false;
            for (String codeLine : codeLines) {
                String[] lineArguments = codeLine.split("\\s+");
                Matcher matchBuddy = potatoFinder.matcher(codeLine);

                String whatToSpam;
                if (matchBuddy.find()) {
                    whatToSpam = matchBuddy.group();
                } else {
                    whatToSpam = "COULDN'T FIND JACK, BOSS";
                }

                if (lineArguments[0].equals("if")) {
                    int[] numbers = Arrays.stream(lineArguments[1].split("[\\D]+"))
                            .filter(s -> !s.equals(""))
                            .mapToInt(Integer::parseInt).toArray();
                    String operator = lineArguments[1].split("[\\d()\\s]+")[1];

                    switch (operator) {
                        case "==":
                            lastIfIsTrue = numbers[0] == numbers[1];
                            break;
                        case "<":
                            lastIfIsTrue = numbers[0] < numbers[1];
                            break;
                        case ">":
                            lastIfIsTrue = numbers[0] > numbers[1];
                            break;
                    }

                    if (lastIfIsTrue) {
                        if (lineArguments[2].equals("loop")) {
                            for (int spam = 0; spam < Integer.parseInt(lineArguments[3]); spam++) {
                                System.out.println(whatToSpam);
                            }
                        } else if (lineArguments[2].equals("out")) {
                            System.out.println(whatToSpam);
                        }
                    }
                } else if (!lastIfIsTrue) {
                    if (lineArguments[1].equals("loop")) {
                        for (int spam = 0; spam < Integer.parseInt(lineArguments[2]); spam++) {
                            System.out.println(whatToSpam);
                        }
                    } else if (lineArguments[1].equals("out")) {
                        System.out.println(whatToSpam);
                    }

                    lastIfIsTrue = false;
                }
            }
        }
    }
}
