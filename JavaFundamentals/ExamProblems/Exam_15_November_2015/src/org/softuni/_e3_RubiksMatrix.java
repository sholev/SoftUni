package org.softuni;

import java.util.Arrays;
import java.util.Scanner;

public class _e3_RubiksMatrix {

    public static void main(String[] args) {

        Scanner in = new Scanner (System.in);
        String[] dimensions = in.nextLine().trim().split("\\s+");
        int rows = Integer.parseInt(dimensions[0]);
        int cols = Integer.parseInt(dimensions[1]);
        int inputLines = Integer.parseInt(in.nextLine());
        int[][] matrix = new int[rows][cols];
        fillMatrix(matrix);
        //printMatrix(matrix);
        for (int i = 0; i < inputLines; i++) {
            String[] cmdParams = in.nextLine().trim().split("\\s+");
            int position = Integer.parseInt(cmdParams[0]);
            String moveDirection = cmdParams[1];
            int numberOfMoves = Integer.parseInt(cmdParams[2]);
            switch (moveDirection) {
                case "up":
                    for (int move = 0; move < numberOfMoves % rows; move++) {
                        int temp = matrix[0][position];
                        for (int row = 0; row < rows - 1; row++) {
                            matrix[row][position] = matrix[row + 1][position];
                        }
                        matrix[rows - 1][position] = temp;
                    }
                    break;
                case "down":
                    for (int move = 0; move < numberOfMoves % rows; move++) {
                        int temp = matrix[rows - 1][position];
                        for (int row = rows - 1; row > 0; row--) {
                            matrix[row][position] = matrix[row - 1][position];
                        }
                        matrix[0][position] = temp;
                    }
                    break;
                case "left":
                    for (int move = 0; move < numberOfMoves % cols; move++) {
                        int temp = matrix[position][0];
                        for (int col = 0; col < cols - 1; col++) {
                            matrix[position][col] = matrix[position][col + 1];
                        }
                        matrix[position][cols - 1] = temp;
                    }
                    break;
                case "right":
                    for (int move = 0; move < numberOfMoves % cols; move++) {
                        int temp = matrix[position][cols - 1];
                        for (int col = cols - 1; col > 0; col--) {
                            matrix[position][col] = matrix[position][col - 1];
                        }
                        matrix[position][0] = temp;
                    }
                    break;

            }

        }
        //printMatrix(matrix);

        int counter = 1;
        for (int row = 0; row < rows; row++) {
            for (int col = 0; col < cols; col++) {
                if (matrix[row][col] != counter) {
                    findAndSwap(matrix, row, col, counter);
                    //printMatrix(matrix);
                } else {
                    System.out.println("No swap required");
                }
                counter++;
            }
        }
    }

    private static void findAndSwap(int[][] matrix, int row, int col, int matchingElement) {
        for (int i = 0; i < matrix.length; i++) {
            for (int j = 0; j < matrix[i].length; j++) {
                if (matrix[i][j] == matchingElement) {
                    int temp = matrix[row][col];
                    matrix[row][col] = matrix[i][j];
                    matrix[i][j] = temp;
                    System.out.printf("Swap (%d, %d) with (%d, %d)\r\n", row, col, i, j);
                    return;
                }
            }
        }
    }

    private static void fillMatrix(int[][] matrix) {
        int counter = 0;
        for (int i = 0; i < matrix.length; i++) {
            for (int j = 0; j < matrix[i].length; j++) {
                matrix[i][j] = ++counter;
            }
        }
    }

    private static void printMatrix(int[][] matrix) {
        for (int i = 0; i < matrix.length; i++) {
            for (int j = 0; j < matrix[i].length; j++) {
                System.out.print(matrix[i][j]);
            }
            System.out.println();
        }
    }
}
