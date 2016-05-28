package org.softuni;

import java.util.Scanner;

public class _06_BaseSevenToDecimal {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        System.out.print("Base-7: ");
        String baseSevenNumber = in.next("\\w+");
        int decimalNumber = Integer.parseInt(baseSevenNumber, 7);

        System.out.printf("Decimal: %d", decimalNumber);
    }
}
