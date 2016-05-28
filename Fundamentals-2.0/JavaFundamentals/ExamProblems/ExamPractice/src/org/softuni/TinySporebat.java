package org.softuni;

// Java Fundamentals Retake - 26 October 2015

import java.util.Scanner;

public class TinySporebat {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);
        Integer health = 5800;
        Integer glowcaps = 0;

        String input = in.nextLine();
        while (!input.equals("Sporeggar")) {
            int length = input.length();
            for (int i = 0; i < length - 1; i++) {
                char currentChar = input.charAt(i);
                if (currentChar == 'L') {
                    health += 200;
                } else {
                    health -= currentChar;
                }

                if (health <= 0) {
                    System.out.println("Died. Glowcaps: " + glowcaps);
                    return;
                }
            }
            glowcaps += Character.getNumericValue(input.charAt(length - 1));
            input = in.nextLine();
        }
        System.out.println("Health left: " + health);
        if (glowcaps >= 30) {
            System.out.println("Bought the sporebat. Glowcaps left: " + (glowcaps - 30));
        } else {
            System.out.printf("Safe in Sporeggar, but another %d Glowcaps needed.\r\n", 30 - glowcaps);
        }
    }
}
