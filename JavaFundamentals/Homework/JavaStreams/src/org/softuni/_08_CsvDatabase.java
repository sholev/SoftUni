package org.softuni;

import java.io.*;
import java.util.*;
import java.util.stream.Collectors;

public class _08_CsvDatabase {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        TreeMap<Integer, String[]> studentsData = new TreeMap<>();
        TreeMap<Integer, TreeMap<String, ArrayList<Double>>> studentsGrades = new TreeMap<>();
        File fileStudents = new File("resources/students.txt");
        File fileGrades = new File("resources/grades.txt");

        if (fileStudents.exists() && fileGrades.exists()) {
            LoadCsvFiles(fileStudents, fileGrades, studentsData, studentsGrades);
        }

        System.out.println("Enter commands, or \"exit\" to exit.");
        String input = in.nextLine();
        while (!input.equals("exit")) {

            String[] inputArguments = input.split("\\s+");
            String command = inputArguments[0];
            // Maybe check the rest of the arguments too, but it is not in the condition.
            switch (command) {
                case "Search-by-full-name":
                    // Example: Search-by-full-name Georgi Ivanov
                    inputArguments[1] = FindId(inputArguments, studentsData);
                    SearchID(inputArguments, studentsData, studentsGrades);
                    break;
                case "Search-by-id":
                    // Example: Search-by-id 4
                    SearchID(inputArguments, studentsData, studentsGrades);
                    break;
                case "Delete-by-id":
                    // Example: Delete-by-id 5
                    studentsData.remove(Integer.parseInt(inputArguments[1]));
                    studentsGrades.remove(Integer.parseInt(inputArguments[1]));
                    StoreCsvFiles(fileStudents, fileGrades, studentsData, studentsGrades);
                    break;
                case "Update-by-id":
                    // Example: Update-by-id 1 Georgi Mamarchev 19 Sofia
                    UpdateById(inputArguments, studentsData, studentsGrades);
                    StoreCsvFiles(fileStudents, fileGrades, studentsData, studentsGrades);
                    break;
                case "Insert-student":
                    // Example:  Insert-student Georgi Mamarchev 19 Sofia
                    InsertStudent(inputArguments, studentsData, studentsGrades);
                    StoreCsvFiles(fileStudents, fileGrades, studentsData, studentsGrades);
                    break;
                case "Insert-grade-by-id":
                    // Example: Insert-grade-by-id 5 Math 4.00
                    InsertGrade(inputArguments, studentsGrades);
                    StoreCsvFiles(fileStudents, fileGrades, studentsData, studentsGrades);
                    break;
                default:
                    System.out.println("Bad input.");
                    break;
            }

            input = in.nextLine();
        }
        System.out.println("Goodbye.");
    }

    private static void UpdateById(
            String[] inputArguments,
            TreeMap<Integer, String[]> studentsData,
            TreeMap<Integer, TreeMap<String, ArrayList<Double>>> studentsGrades
    ) {
        String ID = inputArguments[1];
        String name = inputArguments[2];
        String surname = inputArguments[3];
        String age = inputArguments[4];
        String hometown = inputArguments[5];

        InsertStudent(new String[] {ID, name, surname, age, hometown}, studentsData, studentsGrades);
    }

    private static String FindId(
            String[] inputArguments,
            TreeMap<Integer, String[]> studentsData
    ) {
        String lookupName = inputArguments[1];
        String lookupSurname = inputArguments[2];

        for (Map.Entry<Integer, String[]> student : studentsData.entrySet()) {

            String studentName = student.getValue()[0];
            String studentSurname = student.getValue()[1];

            if (lookupName.equals(studentName) && lookupSurname.equals(studentSurname)) {
                return student.getKey().toString();
            }
        }
        return "-1";
    }

    private static void SearchID(
            String[] inputArguments,
            TreeMap<Integer, String[]> studentsData,
            TreeMap<Integer, TreeMap<String, ArrayList<Double>>> studentsGrades
    ) {
        int ID = Integer.parseInt(inputArguments[1]);

        if (studentsData.containsKey(ID)) {
            System.out.printf(
                    "%s %s (age: %s, town: %s)\r\n",
                    studentsData.get(ID)[0],
                    studentsData.get(ID)[1],
                    studentsData.get(ID)[2],
                    studentsData.get(ID)[3]
                    );
            for (Map.Entry<String, ArrayList<Double>> subject : studentsGrades.get(ID).entrySet()) {
                System.out.printf(
                        "# %s: %s\r\n",
                        subject.getKey(),
                        subject.getValue()
                                .stream()
                                .map(Object::toString)
                                .collect(Collectors.joining(", "))
                );
            }
        } else {
            System.out.println("Student does not exist.");
        }
    }

    private static void InsertGrade(
            String[] inputArguments,
            TreeMap<Integer, TreeMap<String, ArrayList<Double>>> studentsGrades
    ) {
        int ID = Integer.parseInt(inputArguments[1]);
        String subject = inputArguments[2];
        Double grade = Double.parseDouble(inputArguments[3]);

        if (studentsGrades.containsKey(ID)) {
            if (!studentsGrades.get(ID).containsKey(subject)) {
                studentsGrades.get(ID).put(subject, new ArrayList<>());
            }
            studentsGrades.get(ID).get(subject).add(grade);
        }
        else {
            System.out.println("Student does not exist.");
        }
    }

    private static void InsertStudent(
            String[] inputArguments,
            TreeMap<Integer, String[]> studentsData,
            TreeMap<Integer, TreeMap<String, ArrayList<Double>>> studentsGrades
    ) {
        String ID = inputArguments[0];
        String name = inputArguments[1];
        String surname = inputArguments[2];
        String age = inputArguments[3];
        String hometown = inputArguments[4]; // Bug: If the hometown contains a space, the later part will be omitted.
        int position;

        // If inserting after the last position.
        if (ID.equals("Insert-student")) {
            // Since there could be deleted entries the size of studentsData cannot be relied for the last position.
            // Going to get the last key only if the size is not 0, since last key could be null.
            position = (studentsData.size() == 0 ? 0 : studentsData.lastKey()) + 1;
        }
        // If inserting at a given position
        else {
            position = Integer.parseInt(ID);
        }

        studentsData.put(position, new String[]{name, surname, age, hometown});

        // This check might be redundant.
        if (!studentsGrades.containsKey(position)) {
            studentsGrades.put(position, new TreeMap<>());
        }
    }

    private static void LoadCsvFiles(
            File studentsFile,
            File gradesFile,
            TreeMap<Integer, String[]> studentsData,
            TreeMap<Integer, TreeMap<String, ArrayList<Double>>> studentsGrades
    ) {
        try (
                BufferedReader studentsDataReader = new BufferedReader(
                        new FileReader(studentsFile)
                );
                BufferedReader studentsGradesReader = new BufferedReader(
                        new FileReader(gradesFile)
                )
        ){
            String studentCSVrow;
            while ((studentCSVrow = studentsDataReader.readLine()) != null ) {
                InsertStudent(studentCSVrow.split(","), studentsData, studentsGrades);
            }
            String gradesCSVrow;
            String[] gradeSplit;
            while ((gradesCSVrow = studentsGradesReader.readLine()) != null) {
                // Format and split for gradesCSVrow:
                // "[ID],[Subject] [Grade],[Subject] [Grade] [Grade],..."
                // |<-->|<--------------->|<----------------------->|...
                gradeSplit = gradesCSVrow.split(",");
                String ID = gradeSplit[0];

                for (int i = 1; i < gradeSplit.length; i++) {
                    // Format and split for subjectSplit:
                    // "[Subject] [Grade] [Grade],..."
                    // |<------->|<----->|<----->|...
                    String[] subjectSplit = gradeSplit[i].split(" ");
                    String subject = subjectSplit[0];

                    for (int j = 1; j < subjectSplit.length; j++) {
                        String grade = subjectSplit[j];
                        InsertGrade(new String[] {"Placeholder", ID, subject, grade}, studentsGrades);
                    }
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private static void StoreCsvFiles(
            File studentsFile,
            File gradesFile,
            TreeMap<Integer, String[]> studentsData,
            TreeMap<Integer, TreeMap<String, ArrayList<Double>>> studentsGrades
    ) {
        try (
                PrintWriter studentDataWriter = new PrintWriter(
                        new FileWriter(studentsFile)
                );
                PrintWriter studentGradesWriter = new PrintWriter(
                        new FileWriter(gradesFile)
                )
        ) {
            for (Map.Entry<Integer, String[]> student : studentsData.entrySet()) {
                studentDataWriter.printf(
                        "%d,%s,%s,%s,%s\r\n",
                        student.getKey(),      // ID
                        student.getValue()[0], // Name
                        student.getValue()[1], // Surname
                        student.getValue()[2], // Age
                        student.getValue()[3]  // Hometown
                );
            }
            for (Map.Entry<Integer, TreeMap<String, ArrayList<Double>>> grades : studentsGrades.entrySet()) {
                studentGradesWriter.printf("%d", grades.getKey()); // ID

                for (Map.Entry<String, ArrayList<Double>> subjects : grades.getValue().entrySet()) {
                    studentGradesWriter.printf(
                            ",%s %s",
                            subjects.getKey(),  // Subject
                            subjects.getValue() // Subject grades
                                    .stream()
                                    .map(Object::toString)
                                    .collect(Collectors.joining(" "))
                    );
                }

                studentGradesWriter.println();
            }

        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
