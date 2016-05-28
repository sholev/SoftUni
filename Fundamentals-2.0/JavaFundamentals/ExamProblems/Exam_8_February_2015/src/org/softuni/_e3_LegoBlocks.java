package org.softuni;

import java.util.*;

public class _e3_LegoBlocks {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);
        int rows = Integer.parseInt(in.nextLine());
        String[][] firstArray = new String[rows][];
        String[][] secondArray = new String[rows][];

        for (int i = 0; i < rows; i++) {
            firstArray[i] = in.nextLine().trim().split("\\s+");
        }
        for (int i = 0; i < rows; i++) {
            secondArray[i] = in.nextLine().trim().split("\\s+");
        }
        if (arraysFit(firstArray, secondArray, rows)) {
            for (int i = 0; i < rows; i++) {
                List<String> reverse = Arrays.asList(secondArray[i]);
                Collections.reverse(reverse);
                System.out.printf("[%s, %s]\r\n",
                        String.join(", ", firstArray[i]),
                        String.join(", ", reverse)
                );
            }
        } else {
            System.out.printf("The total number of cells is: %s",
                    countElements(firstArray, rows) + countElements(secondArray, rows));
        }
    }

    private static int countElements(String[][] array, int rows) {
        int count = 0;
        for (int i = 0; i < rows; i++) {
            count += array[i].length;
        }
        return count;
    }

    private static boolean arraysFit(String[][] firstArray, String[][] secondArray, int rows) {
        int combinedWidth = firstArray[0].length + secondArray[0].length;
        for (int i = 0; i < rows; i++) {
            if (firstArray[i].length + secondArray[i].length != combinedWidth) {
                return false;
            }
        }
        return true;
    }
}
