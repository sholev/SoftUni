package org.softuni;

import java.io.*;

public class _06_SaveCustomObjectToFile {

    public static class Course implements Serializable {
        String name;
        Integer numberOfStudents;
    }

    public static void main(String[] args) {

        try (
                ObjectOutputStream objectWriter = new ObjectOutputStream(
                        new FileOutputStream("resources/course.save")
                );
                ObjectInputStream objectReader = new ObjectInputStream(
                        new FileInputStream("resources/course.save")
                )
        ) {
            Course java = new Course();
            java.name = "Java Fundamentals";
            java.numberOfStudents = 345;

            objectWriter.writeObject(java);
            //System.out.println(objectReader.readObject());
            PrintCourse((Course) objectReader.readObject());

        } catch (IOException | ClassNotFoundException e) {
            e.printStackTrace();
        }
    }

    private static void PrintCourse(Course course) {
        System.out.printf(
                "Course name: %s; Course attendees: %d.",
                course.name,
                course.numberOfStudents
        );
    }
}
