package org.softuni;

// Java Fundamentals Retake - 26 October 2015

import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class LegendaryFarming {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);
        Map<String, Integer> items = new TreeMap<>();
        Map<String, Integer> junk = new TreeMap<>();

        items.put("shards", 0);
        items.put("fragments", 0);
        items.put("motes", 0);

        while (true) {
            String[] input = in.nextLine().trim().toLowerCase().split("\\s+");

            for (int i = 0; i < input.length; i += 2) {
                String item = input[i + 1];
                Integer quantity = Integer.parseInt(input[i]);

                switch (item) {
                    case "shards":
                    case "fragments":
                    case "motes":
                            items.put(item, items.get(item) + quantity);
                        break;
                    default:
                        if (!junk.containsKey(item)) {
                            junk.put(item, quantity);
                        } else {
                            junk.put(item, junk.get(item) + quantity);
                        }
                        break;
                }

                if (farmingDone(items)) {
                    printMaps(items, junk);
                    return;
                }
            }
        }
    }

    private static void printMaps(Map<String, Integer> items, Map<String, Integer> junk) {
        items.entrySet().stream()
                .sorted((e1, e2) -> e2.getValue().compareTo(e1.getValue()))
                .forEach(e -> System.out.printf("%s: %d\r\n", e.getKey(), e.getValue()));

        junk.entrySet().forEach(e -> System.out.printf("%s: %d\r\n", e.getKey(), e.getValue()));
    }

    private static boolean farmingDone(Map<String, Integer> items) {

        for (Map.Entry<String, Integer> item : items.entrySet()) {
            if (item.getValue() >= 250) {
                items.put(item.getKey(), item.getValue() - 250);
                switch (item.getKey()) {
                    case "shards":
                        System.out.println("Shadowmourne obtained!");
                        break;
                    case "fragments":
                        System.out.println("Valanyr obtained!");
                        break;
                    case "motes":
                        System.out.println("Dragonwrath obtained!");
                        break;
                }
                return true;
            }
        }
        return false;
    }
}
