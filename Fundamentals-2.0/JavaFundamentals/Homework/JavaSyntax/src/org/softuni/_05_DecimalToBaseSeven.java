package org.softuni;

import java.util.Scanner;

public class _05_DecimalToBaseSeven {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        System.out.print("Decimal: ");
        int decimalNumber = in.nextInt();
        String baseSevenNumber = Integer.toString(decimalNumber, 7);

        System.out.printf("Base-7: %s", baseSevenNumber);
    }
}
