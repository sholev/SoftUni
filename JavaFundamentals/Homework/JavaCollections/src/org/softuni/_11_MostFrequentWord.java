package org.softuni;

import java.util.Collections;
import java.util.HashMap;
import java.util.Scanner;

public class _11_MostFrequentWord {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        HashMap<String, Integer> wordOccurrences = new HashMap<>();
        String[] words = in.nextLine().toLowerCase().split("\\W+");

        for (String word : words) {
            if (!wordOccurrences.containsKey(word)) {
                wordOccurrences.put(word, 1);
            }
            else {
                wordOccurrences.put(word, wordOccurrences.get(word) + 1);
            }
        }

        Integer max = Collections.max(wordOccurrences.values());

        wordOccurrences.entrySet().stream()
                .filter(e -> e.getValue().equals(max))
                .forEach(e -> System.out.printf("%s -> %d\r\n", e.getKey(), e.getValue()));
    }
}
