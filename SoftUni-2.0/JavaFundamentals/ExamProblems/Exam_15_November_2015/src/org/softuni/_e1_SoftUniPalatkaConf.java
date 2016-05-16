package org.softuni;

import java.util.Scanner;

public class _e1_SoftUniPalatkaConf {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        int numberOfPeople = Integer.parseInt(in.nextLine());
        int numberOfLines = Integer.parseInt(in.nextLine());
        int availablePlaces = 0;
        int availableFood = 0;

        for (int i = 0; i < numberOfLines; i++) {
            String[] inParams = in.nextLine().trim().split("\\s+");
            String roomFoodOrTent = inParams[0];
            int quantity = Integer.parseInt(inParams[1]);
            String type = inParams[2];

            switch (roomFoodOrTent) {
                case "rooms":
                    switch (type) {
                        case "single":
                            availablePlaces += quantity;
                            break;
                        case "double":
                            availablePlaces += quantity * 2;
                            break;
                        case "triple":
                            availablePlaces += quantity * 3;
                            break;
                    }
                    break;
                case "tents":
                    switch (type) {
                        case "normal":
                            availablePlaces += quantity * 2;
                            break;
                        case "firstClass":
                            availablePlaces += quantity * 3;
                            break;
                    }
                    break;
                case "food":
                    if (type.equals("musaka")) {
                        availableFood += quantity * 2;
                    }
                    break;
            }
        }

        if (availablePlaces >= numberOfPeople) {
            System.out.println("Everyone is happy and sleeping well. Beds left: " +
                    (availablePlaces - numberOfPeople));
        } else {
            System.out.println("Some people are freezing cold. Beds needed: " +
                    (numberOfPeople - availablePlaces));
        }

        if (availableFood >= numberOfPeople) {
            System.out.println("Nobody left hungry. Meals left: " +
                    (availableFood - numberOfPeople));
        } else {
            System.out.println("People are starving. Meals needed: " +
                    (numberOfPeople - availableFood));
        }
    }
}
