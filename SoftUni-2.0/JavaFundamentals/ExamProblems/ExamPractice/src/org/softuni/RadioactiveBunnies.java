package org.softuni;

import java.awt.Point;
import java.util.*;

// Advanced C# Exam 11 October 2015

public class RadioactiveBunnies {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);
        int[] lairSize = Arrays.stream(in.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .toArray();
        String[][] lair = new String[lairSize[0]][lairSize[1]];
        for (int i = 0; i < lairSize[0]; i++) {
            lair[i] = in.nextLine().split("");
        }
        List<String> playerMoves = new ArrayList<>();
        Collections.addAll(playerMoves, in.nextLine().split(""));
        Point playerLocation = getPlayerLocation(lair);
        Point lastPlayerLocation = new Point(-1, -1);
        boolean playerWon = false;
        boolean playerDead = false;

        while (!playerWon && !playerDead) {
            switch (playerMoves.get(0)) {
                case "U":
                    playerLocation.x--;
                    if (pointIsOutOfLair(playerLocation, lair)) {
                        playerWon = true;
                        lastPlayerLocation = new Point(playerLocation.x + 1, playerLocation.y);
                    } else if (lair[playerLocation.x][playerLocation.y].equals("B")) {
                        playerDead = true;
                        lastPlayerLocation = new Point(playerLocation.x, playerLocation.y);
                    } else {
                        lair[playerLocation.x][playerLocation.y] = "P";
                        lair[playerLocation.x + 1][playerLocation.y] = ".";
                    }
                    break;
                case "D":
                    playerLocation.x++;
                    if (pointIsOutOfLair(playerLocation, lair)) {
                        playerWon = true;
                        lastPlayerLocation = new Point(playerLocation.x - 1, playerLocation.y);
                    } else if (lair[playerLocation.x][playerLocation.y].equals("B")) {
                        playerDead = true;
                        lastPlayerLocation = new Point(playerLocation.x, playerLocation.y);
                    } else {
                        lair[playerLocation.x][playerLocation.y] = "P";
                        lair[playerLocation.x - 1][playerLocation.y] = ".";
                    }
                    break;
                case "L":
                    playerLocation.y--;
                    if (pointIsOutOfLair(playerLocation, lair)) {
                        playerWon = true;
                        lastPlayerLocation = new Point(playerLocation.x, playerLocation.y + 1);
                    } else if (lair[playerLocation.x][playerLocation.y].equals("B")) {
                        playerDead = true;
                        lastPlayerLocation = new Point(playerLocation.x, playerLocation.y);
                    } else {
                        lair[playerLocation.x][playerLocation.y] = "P";
                        lair[playerLocation.x][playerLocation.y + 1] = ".";
                    }
                    break;
                case "R":
                    playerLocation.y++;
                    if (pointIsOutOfLair(playerLocation, lair)) {
                        playerWon = true;
                        lastPlayerLocation = new Point(playerLocation.x, playerLocation.y - 1);
                    } else if (lair[playerLocation.x][playerLocation.y].equals("B")) {
                        playerDead = true;
                        lastPlayerLocation = new Point(playerLocation.x, playerLocation.y);
                    } else {
                        lair[playerLocation.x][playerLocation.y] = "P";
                        lair[playerLocation.x][playerLocation.y - 1] = ".";
                    }
                    break;
            }
            playerMoves.remove(0);

            List<Point> bunnies = new ArrayList<>();
            for (int row = 0; row < lair.length; row++) {
                for (int col = 0; col < lair[row].length; col++) {
                    if (lair[row][col].equals("B")) {
                        bunnies.add(new Point(row, col));
                    }
                }
            }
            for (Point bunnie : bunnies) {
                Point up = new Point(bunnie.x - 1, bunnie.y);
                Point down = new Point(bunnie.x + 1, bunnie.y);
                Point left = new Point(bunnie.x, bunnie.y - 1);
                Point right = new Point(bunnie.x, bunnie.y + 1);
                if (!pointIsOutOfLair(up, lair)) {
                    if (lair[up.x][up.y].equals("P")) {
                        playerDead = true;
                    }
                    lair[up.x][up.y] = "B";
                }
                if (!pointIsOutOfLair(down, lair)) {
                    if (lair[down.x][down.y].equals("P")) {
                        playerDead = true;
                    }
                    lair[down.x][down.y] = "B";
                }
                if (!pointIsOutOfLair(left, lair)) {
                    if (lair[left.x][left.y].equals("P")) {
                        playerDead = true;
                    }
                    lair[left.x][left.y] = "B";
                }
                if (!pointIsOutOfLair(right, lair)) {
                    if (lair[right.x][right.y].equals("P")) {
                        playerDead = true;
                    }
                    lair[right.x][right.y] = "B";
                }
            }
        }
        if (lastPlayerLocation.x == -1 || lastPlayerLocation.y == -1) {
            lastPlayerLocation = playerLocation;
        }
        if (playerWon) {
            if (lair[lastPlayerLocation.x][lastPlayerLocation.y].equals("P")) {
                lair[lastPlayerLocation.x][lastPlayerLocation.y] = ".";
            }
            printField(lair);
            System.out.printf("won: %d %d", lastPlayerLocation.x, lastPlayerLocation.y);
        } else if (playerDead) {
            printField(lair);
            System.out.printf("dead: %d %d", lastPlayerLocation.x, lastPlayerLocation.y);
        }
    }

    private static void printField(String[][] lair) {
        for (String[] row : lair) {
            for (String col : row) {
                System.out.print(col);
            }
            System.out.println();
        }
    }

    private static boolean pointIsOutOfLair(Point location, String[][] lair) {
        return location.x < 0 || location.y < 0 ||
                location.x >= lair.length || location.y >= lair[0].length;
    }

    private static Point getPlayerLocation(String[][] lair) {
        for (int row = 0; row < lair.length; row++) {
            for (int col = 0; col < lair[row].length; col++) {
                if (lair[row][col].equals("P")) {
                    return new Point(row, col);
                }
            }
        }
        return new Point(-1, -1);
    }
}
