package org.softuni;

import java.io.*;

public class _04_CopyJpgFile {

    public static void main(String[] args) {

        try (
                FileInputStream byteReader = new FileInputStream("resources/picture.jpg");
                FileOutputStream byteWriter = new FileOutputStream("resources/my-copied-picture.jpg")
        ) {
            int i;
            byte[] buffer = new byte[4096];
            while ((i = byteReader.read(buffer)) != -1) {
                byteWriter.write(buffer);
            }

        } catch (IOException e) {
            System.out.println(e.toString());
        }
    }
}
