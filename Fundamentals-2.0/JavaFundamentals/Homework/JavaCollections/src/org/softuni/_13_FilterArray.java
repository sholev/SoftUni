package org.softuni;

import java.util.Arrays;
import java.util.Scanner;

public class _13_FilterArray {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);
        Arrays.stream(in.nextLine().split(" "))
                .filter(s -> s.length() > 3)
                .forEach(s -> System.out.printf("%s ", s));

    }
}
