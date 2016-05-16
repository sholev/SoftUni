package org.softuni;

import java.util.*;
import java.util.stream.Collectors;

// Advanced C# Exam 11 October 2015

public class ArrayManipulator {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        List<Integer> inputArray = Arrays.asList(in.nextLine().split("\\D+")).stream()
                .filter(s -> !s.equals(""))
                .map(Integer::parseInt)
                .collect(Collectors.toList());

        String command = in.nextLine();
        while (!command.equals("end")) {
            String[] params = command.split("\\s+");

            switch (params[0]) {
                case "exchange":
                    int index = Integer.parseInt(params[1]);
                    if (index >= inputArray.size() || index < 0) {
                        System.out.println("Invalid index");
                    } else {
                        List<Integer> temp = new ArrayList<>();
                        temp.addAll(inputArray.subList(index + 1, inputArray.size()));
                        temp.addAll(inputArray.subList(0, index + 1));
                        inputArray.clear();
                        inputArray.addAll(temp);
                        //System.out.println(inputArray);
                    }
                    break;
                case "max":
                    int maxIndex;
                    if (params[1].equals("even")) {
                        List<Integer> evenNumbers = inputArray.stream()
                                .filter(n -> n % 2 == 0)
                                .collect(Collectors.toList());
                        try {
                            maxIndex = inputArray.lastIndexOf(Collections.max(evenNumbers));
                            System.out.println(maxIndex);
                        } catch (NoSuchElementException e) {
                            System.out.println("No matches");
                        }
                    } else {
                        List<Integer> oddNumbers = inputArray.stream()
                                .filter(n -> n % 2 != 0)
                                .collect(Collectors.toList());
                        try {
                            maxIndex = inputArray.lastIndexOf(Collections.max(oddNumbers));
                            System.out.println(maxIndex);
                        } catch (NoSuchElementException e) {
                            System.out.println("No matches");
                        }
                    }
                    break;
                case "min":
                    int minIndex;
                    if (params[1].equals("even")) {
                        List<Integer> evenNumbers = inputArray.stream()
                                .filter(n -> n % 2 == 0)
                                .collect(Collectors.toList());
                        try {
                            minIndex = inputArray.lastIndexOf(Collections.min(evenNumbers));
                            System.out.println(minIndex);
                        } catch (NoSuchElementException e) {
                            System.out.println("No matches");
                        }
                    } else {
                        List<Integer> oddNumbers = inputArray.stream()
                                .filter(n -> n % 2 != 0)
                                .collect(Collectors.toList());
                        try {
                            minIndex = inputArray.lastIndexOf(Collections.min(oddNumbers));
                            System.out.println(minIndex);
                        } catch (NoSuchElementException e) {
                            System.out.println("No matches");
                        }
                    }
                    break;
                case "first":
                    int count = Integer.parseInt(params[1]);
                    if (count > inputArray.size()) {
                        System.out.println("Invalid count");
                    } else {
                        if (params[2].equals("even")) {
                            List<Integer> evenNumbers = inputArray.stream()
                                    .filter(n -> n % 2 == 0)
                                    .limit(count)
                                    .collect(Collectors.toList());

                            System.out.println(evenNumbers);
                        } else {
                            List<Integer> oddNumbers = inputArray.stream()
                                    .filter(n -> n % 2 != 0)
                                    .limit(count)
                                    .collect(Collectors.toList());

                            System.out.println(oddNumbers);
                        }
                    }
                    break;
                case "last":
                    count = Integer.parseInt(params[1]);
                    if (count > inputArray.size()) {
                        System.out.println("Invalid count");
                    } else {
                        if (params[2].equals("even")) {
                            List<Integer> evenNumbers = inputArray.stream()
                                    .filter(n -> n % 2 == 0)
                                    .collect(Collectors.toList());

                            System.out.println(
                                    evenNumbers.subList(Math.max(evenNumbers.size() - count, 0), evenNumbers.size())
                            );
                        } else {
                            List<Integer> oddNumbers = inputArray.stream()
                                    .filter(n -> n % 2 != 0)
                                    .collect(Collectors.toList());

                            System.out.println(
                                    oddNumbers.subList(Math.max(oddNumbers.size() - count, 0), oddNumbers.size())
                            );
                        }
                    }
                    break;
            }

            command = in.nextLine();
        }
        System.out.println(inputArray);
    }
}
