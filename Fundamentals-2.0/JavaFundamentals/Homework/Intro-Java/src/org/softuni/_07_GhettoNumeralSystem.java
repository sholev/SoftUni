package org.softuni;

// In IntelliJ IDEA use Ctrl+Shift+F10 to run the current class.

import java.util.Scanner;

public class _07_GhettoNumeralSystem {
    public static void main(String[] args) {
        String[] ghettoNumbers = { "Gee", "Bro", "Zuz", "Ma", "Duh",
                                   "Yo", "Dis", "Hood", "Jam", "Mack"
        };
        Scanner Console = new Scanner(System.in);
        String input = Console.nextLine();
        String output = "";

        for (int i = 0; i < input.length(); i++) {
            int number = Character.getNumericValue(input.charAt(i));
            output += ghettoNumbers[number];
        }
        System.out.print(output);
    }
}
