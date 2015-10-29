package org.softuni;

import java.math.BigInteger;
import java.util.Scanner;

public class _16_CalculateFactorialN {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);
        BigInteger number = BigInteger.valueOf(in.nextLong());
        System.out.println(factorial(number));
    }

    private static BigInteger factorial(BigInteger n) {

        BigInteger bigOne = BigInteger.valueOf(1);
        if (n.compareTo(bigOne) == -1) {
            return bigOne;
        }
        return n.multiply(factorial(n.subtract(bigOne)));
    }
}
