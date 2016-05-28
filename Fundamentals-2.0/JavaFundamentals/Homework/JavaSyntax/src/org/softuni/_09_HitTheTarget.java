package org.softuni;

import java.util.Scanner;

public class _09_HitTheTarget {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);
        System.out.print("Enter target number: ");
        int target = in.nextInt();

        for (int i = 1; i <= 20; i++) {
            for (int j = 1; j <= 20; j++) {
                if (i + j == target) {
                    System.out.printf("%d + %d = %d\r\n", i, j, target);
                }
                else if (i - j == target) {
                    System.out.printf("%d - %d = %d\r\n", i, j, target);
                }
            }
        }
    }
}
