package org.softuni;

import java.math.BigInteger;
import java.util.Arrays;
import java.util.Scanner;

// Advanced C# Exam 19 July 2015

public class ArraySlider {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);
        String[] stringArray = in.nextLine().trim().split("\\s+");
        BigInteger[] numberArray = new BigInteger[stringArray.length];
        for (int i = 0; i < stringArray.length; i++) {
            numberArray[i] = new BigInteger(stringArray[i]);
        }

        int position = 0;
        String input = in.nextLine();
        while (!input.equals("stop")) {
            String[] params = input.split("\\s+");
            int offset = Integer.parseInt(params[0]) % numberArray.length;
            String operator = params[1];
            int operand = Integer.parseInt(params[2]);

            if (position + offset < 0) {
                position = (numberArray.length - 1) + (position + offset) + 1;
            } else if (numberArray.length - 1 < position + offset) {
                position = (position + offset) - (numberArray.length - 1) - 1;
            } else {
                position += offset;
            }

            switch (operator) {
                case "+":
                    numberArray[position] = numberArray[position].add(BigInteger.valueOf(operand));
                    break;
                case "–":
                case "-":
                    numberArray[position] = numberArray[position].subtract(BigInteger.valueOf(operand));
                    if (numberArray[position].compareTo(BigInteger.ZERO) < 0) {
                        numberArray[position] = BigInteger.ZERO;
                    }
                    break;
                case "*":
                    numberArray[position] = numberArray[position].multiply(BigInteger.valueOf(operand));
                    break;
                case "/":
                    numberArray[position] = numberArray[position].divide(BigInteger.valueOf(operand));
                    break;
                case "&":
                    numberArray[position] = numberArray[position].and(BigInteger.valueOf(operand));
                    break;
                case "|":
                    numberArray[position] = numberArray[position].or(BigInteger.valueOf(operand));
                    break;
                case "^":
                    numberArray[position] = numberArray[position].xor(BigInteger.valueOf(operand));
                    break;
            }
            input = in.nextLine();
        }
        System.out.println(Arrays.toString(numberArray));
    }
}
