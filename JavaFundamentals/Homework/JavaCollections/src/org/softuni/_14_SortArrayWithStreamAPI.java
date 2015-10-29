package org.softuni;

import java.util.*;
import java.util.stream.*;

public class _14_SortArrayWithStreamAPI {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        int[] intArray = Arrays.stream(in.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();
        //List<Integer> inputListArray = IntStream.of(intArray).boxed().collect(Collectors.toList());
        String sortOrder = in.nextLine();

        if (sortOrder.toLowerCase().equals("ascending")) {
            IntStream.of(intArray)
                    .sorted()
                    .forEach(n -> System.out.printf("%d ", n));
        } else {
            IntStream.of(intArray)
                    .mapToObj(Integer::valueOf)
                    .sorted(Collections.reverseOrder())
                    .forEach(n -> System.out.printf("%d ", n));
        }

        // This is for Lists:

//        if (sortOrder.toLowerCase().equals("ascending")) {
//            inputListArray.stream()
//                    .sorted((n1, n2) -> n1 - n2)
//                    .forEach(n -> System.out.printf("%d ", n));
//        } else {
//            inputListArray.stream()
//                    .sorted((n1, n2) -> n2 - n1)
//                    .forEach(n -> System.out.printf("%d ", n));
//        }
    }
}
