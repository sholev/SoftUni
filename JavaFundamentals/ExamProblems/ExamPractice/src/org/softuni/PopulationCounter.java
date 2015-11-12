package org.softuni;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

// Advanced C# Exam 19 July 2015

public class PopulationCounter {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);
        Map<String, Long> countries = new LinkedHashMap<>();
        LinkedHashMap<String, LinkedHashMap<String, Long>> cities = new LinkedHashMap<>();
        String input = in.nextLine();
        while (!input.equals("report")) {
            String[] parameters = input.split("[|]");
            String city = parameters[0];
            String country = parameters[1];
            long population = Long.parseLong(parameters[2]);

            if (!countries.containsKey(country)) {
                countries.put(country, 0L);
                cities.put(country, new LinkedHashMap<>());
            }
            countries.put(country, countries.get(country) + population);
            if (!cities.get(country).containsKey(city)) {
                cities.get(country).put(city, 0L);
            }
            cities.get(country).put(city, cities.get(country).get(city) + population);

            input = in.nextLine();
        }

        countries.entrySet().stream()
                .sorted((e1, e2) -> e2.getValue().compareTo(e1.getValue()))
                .forEachOrdered(country -> {
                    System.out.printf("%s (total population: %d)\r\n", country.getKey(), country.getValue());
                    cities.get(country.getKey()).entrySet().stream()
                            .sorted((e1, e2) -> e2.getValue().compareTo(e1.getValue()))
                            .forEachOrdered(city -> System.out.printf("=>%s: %d\r\n", city.getKey(), city.getValue()));
                });
    }
}
