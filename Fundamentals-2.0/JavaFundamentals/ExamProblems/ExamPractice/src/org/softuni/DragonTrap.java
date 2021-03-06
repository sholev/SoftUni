package org.softuni;

// Java Fundamentals - 4 October 2015

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class DragonTrap {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        int matrixSize = Integer.parseInt(in.nextLine());
        char[][] inputMatrix = new char[matrixSize][];
        char[][] resultMatrix = new char[matrixSize][];
        for (int row = 0; row < matrixSize; row++) {
            char[] temp = in.nextLine().toCharArray();
            inputMatrix[row] = temp;
            resultMatrix[row] = temp;
        }

        String commands = in.nextLine();
        while (!commands.toLowerCase().equals("end")) {
            String[] commandNumbers = commands.split("[\\s)(]+");
            int centerRow = Integer.parseInt(commandNumbers[1]);
            int centerCol = Integer.parseInt(commandNumbers[2]);
            int radius = Integer.parseInt(commandNumbers[3]);
            int rotations = Integer.parseInt(commandNumbers[4]);

            if (rotations != 0) {
                List<Character> validChars = getRotationChars(centerRow, centerCol, radius, resultMatrix);
                if (validChars.size() > 0) {
                    rotateList(validChars, rotations);
                    //System.out.println(validChars);
                    resultMatrix = putRotationChars(centerRow, centerCol, radius, validChars, resultMatrix);
                }
            }

            commands = in.nextLine();
        }
        for (int i = 0; i < matrixSize; i++) {
            System.out.println(resultMatrix[i]);
        }
        System.out.println("Symbols changed: " + countChangedSymbols(inputMatrix, resultMatrix));

    }

    private static int countChangedSymbols(char[][] inputMatrix, char[][] resultMatrix) {
        int counter = 0;
        for (int i = 0; i < resultMatrix.length; i++) {
            for (int j = 0; j < resultMatrix[i].length; j++) {
                if (resultMatrix[i][j] != inputMatrix[i][j]) {
                    counter++;
                }
            }
        }
        return counter;
    }

    private static void rotateList(List<Character> validChars, int rotations) {

        int flips = Math.abs(rotations) % validChars.size();
        Character temp;
        int lastElement = validChars.size() - 1;
        if (flips != 0) {
            // Clockwise
            if (rotations < 0) {
                for (int i = 0; i < flips; i++) {
                    temp = validChars.get(0);
                    validChars.remove(0);
                    validChars.add(temp);
                }
            }
            // Counterclockwise
            else {
                for (int i = 0; i < flips; i++) {
                    temp = validChars.get(lastElement);
                    validChars.remove(lastElement);
                    validChars.add(0, temp);
                }
            }
        }

    }

    private static char[][] putRotationChars(int centerRow, int centerCol, int radius, List<Character> validChars, char[][] inputMatrix) {
        char[][] resultMatrix = new char[inputMatrix.length][inputMatrix[0].length];
        for (int i = 0; i < resultMatrix.length; i++) {
            System.arraycopy(inputMatrix[i], 0, resultMatrix[i], 0, resultMatrix[i].length);
        }
        // Same logic as getRotationChars but instead of getting elements, it is putting them.
        for (int col = centerCol - radius; col < centerCol + radius ; col++) {
            int topRow = centerRow - radius;
            if (inBoundaries(resultMatrix, topRow, col)) {
                resultMatrix[topRow][col] = validChars.get(0);
                validChars.remove(0);
            }
        }
        for (int row = centerRow - radius; row < centerRow + radius; row++) {
            int rightCol = centerCol + radius;
            if (inBoundaries(resultMatrix, row, rightCol)) {
                resultMatrix[row][rightCol] = validChars.get(0);
                validChars.remove(0);
            }
        }
        for (int col = centerCol + radius; col > centerCol - radius ; col--) {
            int bottomRow = centerRow + radius;
            if (inBoundaries(resultMatrix, bottomRow, col)) {
                resultMatrix[bottomRow][col] = validChars.get(0);
                validChars.remove(0);
            }
        }
        for (int row = centerRow + radius; row > centerRow - radius; row--) {
            int rightCol = centerCol - radius;
            if (inBoundaries(resultMatrix, row, rightCol)) {
                resultMatrix[row][rightCol] = validChars.get(0);
                validChars.remove(0);
            }
        }
        return resultMatrix;
    }

    private static List<Character> getRotationChars(int centerRow, int centerCol, int radius, char[][] inputMatrix) {
        List<Character> returnChars = new ArrayList<>();

        /* > > > > .
           . . . . .
           . . O . .
           . . . . .
           . . . . .  */
        for (int col = centerCol - radius; col < centerCol + radius ; col++) {
            int topRow = centerRow - radius;
            if (inBoundaries(inputMatrix, topRow, col)) {
                returnChars.add(inputMatrix[topRow][col]);
            }
        }

        /* . . . . v
           . . . . v
           . . O . v
           . . . . v
           . . . . .  */
        for (int row = centerRow - radius; row < centerRow + radius; row++) {
            int rightCol = centerCol + radius;
            if (inBoundaries(inputMatrix, row, rightCol)) {
                returnChars.add(inputMatrix[row][rightCol]);
            }
        }

        /* . . . . .
           . . . . .
           . . O . .
           . . . . .
           . < < < < */
        for (int col = centerCol + radius; col > centerCol - radius ; col--) {
            int bottomRow = centerRow + radius;
            if (inBoundaries(inputMatrix, bottomRow, col)) {
                returnChars.add(inputMatrix[bottomRow][col]);
            }
        }

        /* . . . . .
           ^ . . . .
           ^ . O . .
           ^ . . . .
           ^ . . . . */
        for (int row = centerRow + radius; row > centerRow - radius; row--) {
            int rightCol = centerCol - radius;
            if (inBoundaries(inputMatrix, row, rightCol)) {
                returnChars.add(inputMatrix[row][rightCol]);
            }
        }

        return returnChars;
    }

    private static boolean inBoundaries(char[][] inputMatrix, int row, int col) {
        return     row >= 0
                && row < inputMatrix.length
                && col >= 0
                && col < inputMatrix[row].length;
    }
}