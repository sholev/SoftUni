package org.softuni;

import java.io.*;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.IntStream;
import java.util.zip.*;

public class _07_CreateZipArchive {

    public static void main(String[] args) {

        try (
                ZipOutputStream zipWriter = new ZipOutputStream(
                                new FileOutputStream("resources/text-files.zip")
                )
        ) {
            // http://stackoverflow.com/questions/5751335/using-file-listfiles-with-filenameextensionfilter
            // Instead of three hardcoded files, get all files with .txt extension in the resources:
            File[] files = new File("resources").listFiles(file -> file.getName().toLowerCase().endsWith(".txt"));

            for (File file: files) {
                zipWriter.putNextEntry(new ZipEntry(file.getName()));
                zipWriter.write(GetFileBytes(file));
                zipWriter.closeEntry();
            }

        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private static byte[] GetFileBytes(File file) {

        List<Byte> bytes = new ArrayList<>();

        try (
                FileInputStream fileReader = new FileInputStream(file)
        ) {
            int i;
            while ((i = fileReader.read()) != -1) {
                bytes.add((byte) i);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }

        // http://stackoverflow.com/questions/564392/converting-an-array-of-objects-to-an-array-of-their-primitive-types
        byte[] byteArray = new byte[bytes.size()];
        IntStream.range(0, bytes.size()).forEach(i -> byteArray[i] = bytes.get(i));
        return byteArray;
    }
}
