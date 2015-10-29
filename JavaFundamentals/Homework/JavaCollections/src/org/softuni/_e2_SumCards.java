package org.softuni;

import java.util.ArrayList;
import java.util.Scanner;

// After finishing this I've realized that there is no need for lists,
// but it passes the judge, so I won't bother changing it. :D

public class _e2_SumCards {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        ArrayList<ArrayList<Integer>> sumHelper = new ArrayList<>();
        ArrayList<Integer> sumTemp = new ArrayList<>();
        String[] cardFaces = in.nextLine().split("[^0-9AQJK]+");

        sumTemp.add(getCardValue(cardFaces[0]));
        for (int i = 1; i < cardFaces.length; i++) {
            if (cardFaces[i].equals(cardFaces[i - 1])) {
                sumTemp.add(getCardValue(cardFaces[i]));
            }
            else {
                sumHelper.add(sumTemp);
                sumTemp = new ArrayList<>();
                sumTemp.add(getCardValue(cardFaces[i]));
            }
        }
        sumHelper.add(sumTemp);
        Integer result = 0;
        for (ArrayList<Integer> entry : sumHelper) {
            if (entry.size() == 1) {
                result += entry.get(0);
            }
            else {
                result += entry.stream().mapToInt(Integer::intValue).sum() * 2;
            }
        }
        System.out.println(result);
    }

    public static int getCardValue (String card) {
        int value;
        try {
            value = Integer.parseInt(card);
        } catch (NumberFormatException e) {
            if (card.equals("J")) {
                value = 12;
            } else if (card.equals("Q")) {
                value = 13;
            } else if (card.equals("K")) {
                value = 14;
            } else {
                value = 15;
            }
        }
        return value;
    }
}
