package org.softuni;

import java.util.*;
import java.util.stream.Collectors;

public class _09_CombineListsOfLetters {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        // https://stackoverflow.com/questions/26905312/how-to-use-collect-call-in-java8
        ArrayList<Character> listOne = Arrays
                .stream(in.nextLine().split(" "))
                .map(c -> c.charAt(0))
                .collect(Collectors.toCollection(ArrayList::new));

        ArrayList<Character> listTwo = Arrays
                .stream(in.nextLine().split(" "))
                .map(c -> c.charAt(0))
                .collect(Collectors.toCollection(ArrayList::new));

        listTwo.removeAll(listOne);
        listOne.addAll(listTwo);

        // http://stackoverflow.com/questions/4021851/join-string-list-elements-with-a-delimiter-in-one-step
        System.out.println(listOne.stream().map(Object::toString).collect(Collectors.joining(" ")));
    }
}
