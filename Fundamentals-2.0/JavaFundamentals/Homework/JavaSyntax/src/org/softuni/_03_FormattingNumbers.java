package org.softuni;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.Scanner;

public class _03_FormattingNumbers {

    public static void main(String[] args) {

        System.out.println("Enter A, B and C separated by space.");
        Scanner in = new Scanner(System.in);
        System.out.print("A B C = ");
        Integer A = in.nextInt();
        Double B = in.nextDouble();
        Double C = in.nextDouble();

        String hexadecimalA = String.format("%-10X", A);
        String binaryA = String.format("%10s", Integer.toString(A, 2)).replace(' ', '0');
        NumberFormat decimalFormatB = new DecimalFormat("0.00");
        NumberFormat decimalFormatC = new DecimalFormat("0.000");

        System.out.println(String.format("\r\nFormatting result: |%s|%s|%10s|%-10s|",
                hexadecimalA, binaryA, decimalFormatB.format(B), decimalFormatC.format(C)));
    }
}
