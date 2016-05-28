package org.softuni;

import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;

public class _01_SumLines {

    public static void main(String[] args) {

        try (
                FileReader reader = new FileReader("resources/Lines.txt");
                FileWriter writer = new FileWriter("resources/SumLinesOutput.txt")
        ){
            int i;
            Integer sum = 0;
            while ((i = reader.read()) != -1) {
                if ((char) i != '\r' && (char) i != '\n'){
                    sum += i;
                }
                else if ((char) i == '\n') {
                    writer.write(sum.toString() + "\n");
                    sum = 0;
                }
            }
            writer.write(sum.toString() + "\n");

        } catch (IOException e) {
            System.out.println(e.toString());
        }
    }
}
