package org.softuni;

import java.util.LinkedHashMap;
import java.util.Scanner;

public class _12_CardFrequencies {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        // http://stackoverflow.com/questions/683518/java-class-that-implements-map-and-keeps-insertion-order
        LinkedHashMap<String, Double> cardFaceOccurrences = new LinkedHashMap<>();
        String[] cardFaces = in.nextLine().split("[^0-9AQJK]+");

        for (String card : cardFaces) {
            if (!cardFaceOccurrences.containsKey(card)) {
                cardFaceOccurrences.put(card, 1d);
            }
            else {
                cardFaceOccurrences.put(card, cardFaceOccurrences.get(card) + 1);
            }
        }

        Double numberOfCards = (double)cardFaces.length;

        cardFaceOccurrences.entrySet().stream()
                .forEach(e -> System.out.printf(
                                "%s -> %.2f%%\r\n",
                                e.getKey(),
                                (e.getValue() * 100d) / numberOfCards)
                );

    }
}
