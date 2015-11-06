package org.softuni;

// Java Fundamentals Retake - 26 October 2015

import java.awt.Point;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class TheHeiganDance {

    static class Spell {
        String name;
        int longevity;
        int damagePerTurn;
        Point position;

        public Spell(String name, Point position) {
            this.name = name;
            this.position = position;

            if (name.equals("Cloud")) {
                longevity = 2;
                damagePerTurn = 3500;
            } else {
                longevity = 1;
                damagePerTurn = 6000;
            }
        }
    }

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);
        double heiganHealth = 3000000;
        int playerHealth = 18500;
        Point playerPosition = new Point(7, 7);
        double playerDamage = Double.parseDouble(in.nextLine());
        List<Spell> activeSpells = new ArrayList<>();
        boolean isPlayerDead = false;
        boolean isHeighanDead = false;
        String killerSpell = "";

        while (true) {
            heiganHealth -= playerDamage;
            if (heiganHealth <= 0) {
                isHeighanDead = true;
            }

            String[] params = in.nextLine().split("\\s+");
            String spellName = params[0];
            Point damagePosition = new Point(Integer.parseInt(params[1]), Integer.parseInt(params[2]));

            if (!isHeighanDead) {
                if(isInDamageArea(damagePosition, playerPosition)) {
                    playerPosition = movePlayer(playerPosition, "up", damagePosition);
                    if (isInDamageArea(damagePosition, playerPosition)) {
                        playerPosition = movePlayer(playerPosition, "right", damagePosition);
                        if (isInDamageArea(damagePosition, playerPosition)) {
                            playerPosition = movePlayer(playerPosition, "down", damagePosition);
                            if (isInDamageArea(damagePosition, playerPosition)) {
                                playerPosition = movePlayer(playerPosition, "left", damagePosition);
                                if (isInDamageArea(damagePosition, playerPosition)) {
                                    activeSpells.add(new Spell(spellName, damagePosition));
                                }
                            }
                        }
                    }
                }
            }

            if (!isPlayerDead) {
                for (Spell spell : activeSpells.stream().collect(Collectors.toList())) {
                    spell.longevity--;
                    int damage = spell.damagePerTurn;
                    playerHealth -= damage;
                    if (!isPlayerDead) {
                        if (playerHealth <= 0) {
                            killerSpell = spell.name;
                            isPlayerDead = true;
                        }
                    }
                    if (spell.longevity <= 0) {
                        activeSpells.remove(spell);
                    }
                }
            }

            if (isHeighanDead || isPlayerDead) {
                break;
            }
        }

        if (isHeighanDead) {
            System.out.println("Heigan: Defeated!");
        } else {
            System.out.printf("Heigan: %.2f\r\n", heiganHealth);
        }
        if (isPlayerDead) {
            System.out.println("Player: Killed by " + (killerSpell.equals("Eruption") ? "Eruption" : "Plague Cloud"));
        } else {
            System.out.println("Player: " + playerHealth);
        }
        System.out.println("Final position: " + playerPosition.x + ", " + playerPosition.y);

    }

    private static Point movePlayer(Point playerPosition, String direction, Point damagePosition) {
        Point newPosition = new Point();
        switch (direction) {
            case "up":
                newPosition = new Point(playerPosition.x - 1, playerPosition.y);
                break;
            case "right":
                newPosition = new Point(playerPosition.x, playerPosition.y + 1);
                break;
            case "down":
                newPosition = new Point(playerPosition.x + 1, playerPosition.y);
                break;
            case "left":
                newPosition = new Point(playerPosition.x, playerPosition.y - 1);
                break;
        }
        if (isAtWall(newPosition) || isInDamageArea(damagePosition, newPosition)) {
            return playerPosition;
        } else {
            return newPosition;
        }
    }

    static boolean isInDamageArea(Point damagePosition, Point playerPosition) {
        return playerPosition.x >= damagePosition.x - 1 && playerPosition.x <= damagePosition.x + 1
                && playerPosition.y >= damagePosition.y - 1 && playerPosition.y <= damagePosition.y + 1;
    }

    static boolean isAtWall (Point player) {
        return player.x < 0 || player.x > 15 || player.y < 0 || player.y > 15;
    }
}
