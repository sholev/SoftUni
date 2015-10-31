package org.softuni;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;

public class DragonTrap {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        int matrixSize = Integer.parseInt(in.nextLine());
        char[][] inputMatrix = new char[matrixSize][];
        char[][] resultMatrix = inputMatrix;
        for (int row = 0; row < matrixSize; row++) {
            inputMatrix[row] = in.nextLine().toCharArray();
        }
        String commands = in.nextLine();
        while (!commands.toLowerCase().equals("end")) {
            int[] commandNumbers = Arrays.stream(commands.split("[\\s)(]+")).filter(s -> !s.equals("")).mapToInt(Integer::parseInt).toArray();
            int centerRow = commandNumbers[0];
            int centerCol = commandNumbers[1];
            int radius = commandNumbers[2];
            int rotations = commandNumbers[3];

            if (rotations != 0) {
                List<Character> validChars = getRotationChars(centerRow, centerCol, radius, inputMatrix);
                if (validChars.size() > 0) {
                    rotateList(validChars, rotations);
                    //System.out.println(validChars);
                    resultMatrix = putRotationChars(centerRow, centerCol, radius, validChars, inputMatrix);
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
        // Clockwise
        if (rotations < 0) {
            for (int i = 0; i < flips; i++) {
                temp = validChars.get(0);
                validChars.remove(0);
                validChars.add(temp);
            }
        }
        // Counterclockwise
        else if (rotations > 0) {
            for (int i = 0; i < flips; i++) {
                temp = validChars.get(lastElement);
                validChars.remove(lastElement);
                validChars.add(0, temp);
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
