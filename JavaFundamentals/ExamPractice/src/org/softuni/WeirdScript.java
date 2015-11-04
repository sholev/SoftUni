package org.softuni;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class WeirdScript {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);
        StringBuilder text = new StringBuilder();

        char key = getKey(Integer.parseInt(in.nextLine()));
        String input = in.nextLine();
        while (!input.equals("End")) {
            text.append(input);
            input = in.nextLine();
        }

        String textWithPlaceholders = replaceKeys(text, key);
        String pattern = "(?<==>).*?(?=<=)";
        Matcher matchBuddy = Pattern.compile(pattern).matcher(textWithPlaceholders);
        while (matchBuddy.find()) {
            String match = matchBuddy.group();
            if (match.length() > 0) {
                System.out.println(match);
            }
        }
    }

    // input: "ajhdnnTremble,nnnnmortals,nnand8712783nnand despair!nn" key: 'n'
    // result: "ajhd=>Tremble,<==>mortals,<=and8712783=>and despair!<="
    private static String replaceKeys(StringBuilder input, Character key) {
        String keykey = key.toString() + key;
        int counter = 0;
        int index = 0;
        while ((index = input.indexOf(keykey, index)) != -1) {
            if (counter % 2 == 0) {
                input.setCharAt(index, '=');
                input.setCharAt(index + 1, '>');
            } else {
                input.setCharAt(index, '<');
                input.setCharAt(index + 1, '=');
            }
            index++;
            counter++;
        }
        return input.toString();
    }

    // Copy/pasta
    private static char getKey(int number) {
        int charCode = --number % 26;
        return (number / 26) % 2 == 0
                ? (char)('a' + charCode)
                : Character.toUpperCase((char)('a' + charCode));
    }
}
