package org.softuni;

// In IntelliJ IDEA use Ctrl+Shift+F10 to run the current class.

import java.util.Scanner;

public class _05_CharacterTriangle {
    public static void main(String[] args) {
        Scanner Console = new Scanner(System.in);
        int lines = Integer.parseInt(Console.nextLine());

        for (int i = 0; i < lines * 2; i++) {
            if (i <= lines) {
                for (char j = 'a'; j < 'a' + i; j++) {
                    System.out.print(j + " ");
                }
                System.out.println();
            }
            else {
                for (char j = 'a'; j <= 'a' + (lines * 2 - i) - 1; j++) {
                    System.out.print(j + " ");
                }
                System.out.println();
            }
        }
    }
}
