package org.softuni;

import java.util.*;

public class DragonArmy {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        LinkedHashMap<String, TreeMap<String, Integer[]>> dragonData = new LinkedHashMap<>();
        LinkedHashMap<String, Double[]> dragonTypeStats = new LinkedHashMap<>();
        int numberOfDragons = Integer.parseInt(in.nextLine());
        for (int i = 0; i < numberOfDragons; i++) {
            String[] inParameters = in.nextLine().split("\\s+");
            String type = inParameters[0];
            String name = inParameters[1];
            int damage = inParameters[2].equals("null") ? 45 : Integer.parseInt(inParameters[2]);
            int health = inParameters[3].equals("null") ? 250 : Integer.parseInt(inParameters[3]);
            int armor = inParameters[4].equals("null") ? 10 : Integer.parseInt(inParameters[4]);

            if (!dragonData.containsKey(type)) {
                dragonData.put(type, new TreeMap<>());
                dragonTypeStats.put(type, new Double[] {0.0, 0.0, 0.0});
            }
            dragonData.get(type).put(name, new Integer[] {damage, health, armor});
        }

        for (Map.Entry<String, TreeMap<String, Integer[]>> type : dragonData.entrySet()) {
            System.out.printf("%s::(", type.getKey());
            for (Map.Entry<String, Integer[]> name : type.getValue().entrySet()) {
                dragonTypeStats.put(type.getKey(), addStats(dragonTypeStats.get(type.getKey()), name.getValue()));
            }
            Double[] typeStats = dragonTypeStats.get(type.getKey());
            int number = type.getValue().size();
            System.out.printf("%.2f/%.2f/%.2f)\r\n",
                    typeStats[0] / number,
                    typeStats[1] / number,
                    typeStats[2] / number);
            for (Map.Entry<String, Integer[]> name : type.getValue().entrySet()) {
                Integer[] dragonStats = name.getValue();
                System.out.printf("-%s -> damage: %d, health: %d, armor: %d\r\n",
                        name.getKey(),
                        dragonStats[0],
                        dragonStats[1],
                        dragonStats[2]);
            }
        }
    }

    private static Double[] addStats(Double[] inputStats, Integer[] addStats) {
        inputStats[0] += addStats[0];
        inputStats[1] += addStats[1];
        inputStats[2] += addStats[2];
        return new Double[] {inputStats[0], inputStats[1], inputStats[2]};
    }
}
