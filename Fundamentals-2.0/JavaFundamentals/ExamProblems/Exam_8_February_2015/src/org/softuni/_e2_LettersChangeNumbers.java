package org.softuni;

import java.util.Scanner;

public class _e2_LettersChangeNumbers {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        String[] input = in.nextLine().split("\\s+");
        double sum = 0;

        for (String element : input) {
            sum += NakovsGameResult(element);
        }
        System.out.printf("%.2f", sum);
    }

    private static double NakovsGameResult(String element) {
        char frontLetter = element.charAt(0);
        char backLetter = element.charAt(element.length() - 1);
        int frontLetterPosition = (int)frontLetter % 32;
        int backLetterPosition = (int)backLetter % 32;
        double number = Double.parseDouble(element.substring(1, element.length() - 1));
        if (Character.isUpperCase(frontLetter)) {
            number /= frontLetterPosition;
        } else {
            number *= frontLetterPosition;
        }
        if (Character.isUpperCase(backLetter)) {
            number -= backLetterPosition;
        } else {
            number += backLetterPosition;
        }
        return number;
    }
}
