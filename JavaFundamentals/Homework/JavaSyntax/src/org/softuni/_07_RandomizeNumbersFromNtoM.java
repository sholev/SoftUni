package org.softuni;

import java.util.Random;
import java.util.Scanner;

public class _07_RandomizeNumbersFromNtoM {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        Random RNG = new Random();

        System.out.print("N M = ");
        Integer N = in.nextInt();
        Integer M = in.nextInt();

        Integer min = Math.min(N, M);
        Integer max = Math.max(N, M);

        for (int i = 0; i <= Math.abs(N - M) ; i++) {
            System.out.printf("%d ", RNG.nextInt((max - min) + 1) + min);
        }
    }
}
