package org.softuni;

import java.util.Scanner;

public class _e1_StuckNumbers {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        int intsLength = in.nextInt();
        int[] ints = new int[intsLength];
        for (int i = 0; i < intsLength; i++) {
            ints[i] = in.nextInt();
        }
        String stuckLeft;
        String stuckRight;
        boolean resultAbsent = true;
        for (int a = 0; a < intsLength; a++) {
            for (int b = 0; b < intsLength; b++) {
                if (a != b) {
                    for (int c = 0; c < intsLength; c++) {
                        if (c != a && c != b) {
                            for (int d = 0; d < intsLength; d++) {
                                if (d != a && d != b && d != c) {
                                    stuckLeft = "" + ints[a] + ints[b];
                                    stuckRight = "" + ints[c] + ints[d];
                                    if (stuckLeft.equals(stuckRight)) {
                                        System.out.printf("%d|%d==%d|%d\r\n",
                                                ints[a], ints[b], ints[c], ints[d]);
                                        if (resultAbsent) {
                                            resultAbsent = !resultAbsent;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        if (resultAbsent) {
            System.out.println("No");
        }
    }
}
