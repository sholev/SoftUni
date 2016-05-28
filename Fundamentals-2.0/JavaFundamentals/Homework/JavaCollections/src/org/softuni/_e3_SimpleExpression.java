package org.softuni;

import java.math.BigDecimal;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class _e3_SimpleExpression {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);
        String input = in.nextLine();
        List<String> operators = Arrays.stream(input.split("[^+-]+|[\\s]+")).collect(Collectors.toList());
        List<String> strNumbers = Arrays.stream(input.split("[\\s+-]+")).collect(Collectors.toList());
        operators.removeIf(s -> s.equals(""));
        strNumbers.removeIf(s -> s.equals(""));
        double[] numbers = strNumbers.stream().mapToDouble(Double::parseDouble).toArray();

        BigDecimal result = new BigDecimal(numbers[0]);
        for (int i = 1; i < numbers.length; i++) {
            if (operators.get(0).equals("+")) {
                result = result.add(BigDecimal.valueOf(numbers[i]));
            } else {
                result = result.subtract(BigDecimal.valueOf(numbers[i]));
            }
            operators.remove(0);
        }

        System.out.println(result);
    }
}
