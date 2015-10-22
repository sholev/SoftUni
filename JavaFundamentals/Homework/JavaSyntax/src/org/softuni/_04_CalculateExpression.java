package org.softuni;

import java.util.Scanner;

public class _04_CalculateExpression {

    public static void main(String[] args) {

        System.out.println("Enter A, B and C separated by space.");
        Scanner in = new Scanner(System.in);
        System.out.print("A B C = ");
        Double A = in.nextDouble();
        Double B = in.nextDouble();
        Double C = in.nextDouble();

        Double F1 = Math.pow((Math.pow(A, 2) + Math.pow(B, 2)) / (Math.pow(A, 2) - Math.pow(B, 2)), (A + B + C) / Math.sqrt(C));
        Double F2 = Math.pow(Math.pow(A, 2) + Math.pow(B, 2) - Math.pow(C, 3), A - B);

        Double DIFF = Math.abs(((A + B + C) / 3) - ((F1 + F2) / 2));

        System.out.printf("F1 result: %.2f; F2 result: %.2f; Diff: %.2f", F1, F2, DIFF);
    }
}
