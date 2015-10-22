package org.softuni;

import java.util.Scanner;

public class _12_CharacterMultiplier {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);
        System.out.print("Enter strings separated by space: ");
        String stringOne = in.next("[\\S]+");
        String stringTwo = in.next("[\\S]+");

        int min = Math.min(stringOne.length(), stringTwo.length());
        int sum = 0;
        for (int i = 0; i < min; i++) {
            sum += stringOne.charAt(i) * stringTwo.charAt(i);
        }
        sum += stringOne.length() > stringTwo.length() ? RemainingCharCodes(min, stringOne) : RemainingCharCodes(min, stringTwo);

        System.out.printf("The sum is: %d", sum);
    }

    private static int RemainingCharCodes(int start, String str) {

        int sum = 0;
        for (int i = start; i < str.length(); i++) {
            sum += str.charAt(i);
        }
        return sum;
    }
}
