package org.softuni;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.Scanner;

public class _01_RectangleArea {

    public static void main(String[] args) {

        Scanner input = new Scanner(System.in);
        System.out.print("Side A:");
        double sideA = input.nextDouble();
        System.out.print("Side B:");
        double sideB = input.nextDouble();

        NumberFormat decimalFormat = new DecimalFormat("##.###");
        System.out.printf("%s", decimalFormat.format(sideA * sideB));
    }
}
