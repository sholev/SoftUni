package org.softuni;

import java.io.*;

class _02_AllCapitals {

    public static void main(String[] args) {

        try (
                BufferedReader reader = new BufferedReader(
                        new FileReader("resources/Lines.txt"));
                PrintWriter writer = new PrintWriter (
                        new FileWriter("resources/AllCapitalsOutput.txt"))
        ){
            String line;
            while ((line = reader.readLine()) != null) {
                writer.println(line.toUpperCase());
            }

        } catch (IOException e) {
            System.out.println(e.toString());
        }
    }
}
