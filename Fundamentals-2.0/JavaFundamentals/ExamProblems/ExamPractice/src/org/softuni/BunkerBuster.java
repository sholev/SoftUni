package org.softuni;

import java.util.Scanner;

// Advanced C# Exam 19 July 2015

public class BunkerBuster {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        int[] size = new int[] {in.nextInt(), in.nextInt()};
        long[][] bunker = new long[size[0]][size[1]];
        for (int i = 0; i < size[0]; i++) {
            for (int j = 0; j < size[1]; j++) {
                bunker[i][j] = in.nextLong();
            }
        }
        in.nextLine();
        String bomb = in.nextLine();
        while (!bomb.equals("cease fire!")) {
            String[] parameters = bomb.split("\\s+");
            int damage = parameters[2].charAt(0);
            int row = Integer.parseInt(parameters[0]);
            int col = Integer.parseInt(parameters[1]);
            int adjacentDamage = (int)Math.ceil(damage / 2D);

            for (int i = row - 1; i <= row + 1; i++) {
                for (int j = col - 1; j <= col + 1; j++) {
                    if (i >= 0 && i < size[0] && j >= 0 && j < size[1]) {
                        if (i == row && j == col) {
                            bunker[i][j] -= damage;
                        } else {
                            bunker[i][j] -= adjacentDamage;
                        }
                    }
                }
            }
            bomb = in.nextLine();
        }
        int destroyedCells = 0;
        for (int row = 0; row < size[0]; row++) {
            for (int col = 0; col < size[1]; col++) {
                if (bunker[row][col] <= 0) {
                    destroyedCells++;
                }
            }
        }
        double bunkerDamage = ((double)destroyedCells / (size[0] * size[1])) * 100d;

        System.out.printf("Destroyed bunkers: %d \r\nDamage done: %.1f %%",
                destroyedCells, bunkerDamage);
    }
}
