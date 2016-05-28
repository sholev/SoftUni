package org.softuni;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _e2_SoftUniDefenseSystem {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        String input = in.nextLine();
        long litters = 0;
        String pattern = "([A-Z][a-z]+).*?([A-Z][a-z]*[A-Z]).*?(\\d+L)";
        Pattern lolwut = Pattern.compile(pattern);
        while(!input.equals("OK KoftiShans")) {
            Matcher lolthat = lolwut.matcher(input);

            while (lolthat.find()) {
                String name = lolthat.group(1);
                String drink = lolthat.group(2).toLowerCase();
                String alcoholString = lolthat.group(3);
                int alcoholQuantity = Integer.parseInt(alcoholString.substring(0, alcoholString.length() - 1));
                if (alcoholQuantity > 0) {
                    System.out.printf("%s brought %d liters of %s!\r\n", name, alcoholQuantity, drink);
                    litters += alcoholQuantity;
                }
            }
            input = in.nextLine();
        }

        System.out.printf("%.3f softuni liters", litters / 1000d);
    }
}