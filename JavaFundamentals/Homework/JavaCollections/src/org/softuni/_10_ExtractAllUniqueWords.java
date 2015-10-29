package org.softuni;

import java.util.Arrays;
import java.util.Scanner;
import java.util.TreeSet;
import java.util.stream.Collectors;

public class _10_ExtractAllUniqueWords {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        TreeSet<String> uniqueWords = new TreeSet<>();
        uniqueWords.addAll(Arrays.asList(in.nextLine().toLowerCase().split("\\W+")));
        System.out.println(uniqueWords.stream().map(Object::toString).collect(Collectors.joining(" ")));
    }
}
