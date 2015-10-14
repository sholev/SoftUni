package org.softuni;

// In IntelliJ IDEA use Ctrl+Shift+F10 to run the current class.

import java.util.Scanner;

public class _08_GetAverage {
    public static void main(String[] args) {
        Scanner Console = new Scanner(System.in);
        System.out.print("A = ");
        Double A = Double.parseDouble(Console.nextLine());
        System.out.print("B = ");
        Double B = Double.parseDouble(Console.nextLine());
        System.out.print("C = ");
        Double C = Double.parseDouble(Console.nextLine());

        System.out.format("Average: %.2f", (A + B + C) / 3);
    }
}
