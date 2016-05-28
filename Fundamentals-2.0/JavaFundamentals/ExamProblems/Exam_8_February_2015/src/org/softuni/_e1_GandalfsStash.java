package org.softuni;

import java.util.HashMap;
import java.util.Scanner;

public class _e1_GandalfsStash {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        HashMap<String, Integer> foodMood = new HashMap<>();
        foodMood.put("cram", 2);
        foodMood.put("lembas", 3);
        foodMood.put("apple", 1);
        foodMood.put("melon", 1);
        foodMood.put("honeycake", 5);
        foodMood.put("mushrooms", -10);

        int mood = Integer.parseInt(in.nextLine());
        String[] foods = in.nextLine().toLowerCase().split("[\\W_]+");

        for (String food : foods) {

            if (foodMood.containsKey(food)) {
                mood += foodMood.get(food);
            } else {
                mood -= 1;
            }
        }
        System.out.println(mood);
        System.out.println(GetMoodWord(mood));
    }

    private static String GetMoodWord(int mood) {
        if (mood < -5) {
            return "Angry";
        } else if (mood < 0) {
            return "Sad";
        } else if (mood <= 15) {
            return "Happy";
        } else {
            return "Special JavaScript mood";
        }
    }
}
