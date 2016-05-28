package org.softuni;

import java.util.Arrays;
import java.util.Scanner;

public class _14_MagicExchangeableWords {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);
        System.out.print("Enter two strings: ");
        String stringOne = in.next("\\S+");
        String stringTwo = in.next("\\S+");

        System.out.printf("They are exchangeable: %b", AreExchangeable(stringOne, stringTwo));
    }

    private static boolean AreExchangeable(String stringOne, String stringTwo) {

        // Split every character to a string array element.
        String[] sequenceOne = stringOne.split("");
        String[] sequenceTwo = stringTwo.split("");

        // If an element is not replaced (it is a single char), replace it.
        // Those could be a method instead of repeating them, but they aren't too long. :)
        for (int i = 0; i < sequenceOne.length; i++) {
            if (sequenceOne[i].length() == 1) {
                replaceElements(sequenceOne, sequenceOne[i], i);
            }
        }

        for (int i = 0; i < sequenceTwo.length; i++) {
            if (sequenceTwo[i].length() == 1) {
                replaceElements(sequenceTwo, sequenceTwo[i], i);
            }
        }

        // If the replaced arrays are the same, they are exchangeable.
        return Arrays.equals(sequenceOne, sequenceTwo);
    }

    // Replace all strings in the array, which are equal to the string to replace.
    private static void replaceElements(String[] Sequence, String strToReplace, int replacementNumber) {

        for (int i = 0; i < Sequence.length; i++) {
            if (Sequence[i].equals(strToReplace)) {
                Sequence[i] = "Replacement" + replacementNumber;
            }
        }
    }
}
