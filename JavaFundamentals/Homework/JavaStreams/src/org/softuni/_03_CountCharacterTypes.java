package org.softuni;

import java.io.*;
import java.util.Arrays;

public class _03_CountCharacterTypes {

    public static void main(String[] args) {

        try (
                FileReader reader = new FileReader("resources/Words.txt");
                PrintWriter writer = new PrintWriter(
                        new FileWriter("resources/CountCharactersTypesOutput.txt"))
        ) {
            Character[] punctuation = {
                    '.', ',', '!', '?',
            };
            Character[] vowels = {
                    'a', 'e', 'i', 'o', 'u',
            };
            Character[] consonants = {
                    'b', 'c', 'd', 'f', 'g',
                    'h', 'j', 'k', 'l', 'm',
                    'n', 'p', 'q', 'r', 's',
                    't', 'v', 'w', 'x', 'z',

                    'y', // Not sure if this isn't a vowel, but in the problem condition it isn't.
            };

            int i;
            int countPunct = 0;
            int countVowel = 0;
            int countCons = 0;
            while ((i = reader.read()) != -1) {
                if (CharArrayContainsChar(punctuation, (char) i)) {
                    countPunct++;
                } else if (CharArrayContainsChar(vowels, (char) i)) {
                    countVowel++;
                } else if (CharArrayContainsChar(consonants, (char) i)) {
                    countCons++;
                }
            }

            writer.printf("Vowels: %d\r\n", countVowel);
            writer.printf("Consonants: %d\r\n", countCons);
            writer.printf("Punctuation: %d\r\n", countPunct);

        } catch (IOException e) {
            System.out.println(e.toString());
        }
    }

    private static boolean CharArrayContainsChar(Character[] charArr, char ch) {

        Character checkChar = ch;
        if (Arrays.stream(charArr).anyMatch(
                c -> c.toString().equals(checkChar.toString().toLowerCase())
        )) {
            return true;
        }

        return false;
    }
}
