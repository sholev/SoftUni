package org.softuni;

// In IntelliJ IDEA use Ctrl+Shift+F10 to run the current class.

import java.util.Scanner;

public class _06_OneToNSum {
    public static void main(String[] args) {
        Scanner Console = new Scanner(System.in);
        int N = Integer.parseInt(Console.nextLine());
        int sum = 0;

        for (int i = 1; i <= N; i++) {
            sum += i;
        }
        System.out.println(sum);
    }
}
