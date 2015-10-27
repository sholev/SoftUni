package org.softuni;

import java.io.*;
import java.util.*;

public class _05_SaveArrayListOfDoubles {

    public static void main(String[] args) {

        try (
                ObjectOutputStream objectWriter = new ObjectOutputStream(
                        new FileOutputStream("resources/doubles.list")
                );
                ObjectInputStream objectReader = new ObjectInputStream(
                        new FileInputStream("resources/doubles.list")
                )
        ) {
            List<Double> doubies = Arrays.asList(5.5, 3.4, 34.34, 44332211.123, 101.1337);
            objectWriter.writeObject(doubies);

            System.out.println(objectReader.readObject().toString());

        } catch (IOException | ClassNotFoundException e) {
            System.out.println(e.toString());
        }
    }
}
