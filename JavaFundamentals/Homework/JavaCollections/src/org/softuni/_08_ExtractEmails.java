package org.softuni;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _08_ExtractEmails {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);
        String emailPattern = "(?<=\\s|^)([^\\W_][\\w.-]*[^\\W_])@([^\\W]+[\\w.-]+[^\\W]+)";
        String input = in.nextLine();

        Matcher emailFinder = Pattern.compile(emailPattern).matcher(input);

        while (emailFinder.find()) {
            System.out.println(emailFinder.group());
        }
    }
}
