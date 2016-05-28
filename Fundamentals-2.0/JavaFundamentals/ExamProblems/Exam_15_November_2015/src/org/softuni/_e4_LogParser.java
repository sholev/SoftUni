package org.softuni;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _e4_LogParser {

    static class Error {
        String type;
        String message;

        public Error(String type, String message) {
            this.type = type;
            this.message = message;
        }
    }
    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);
        String inputPattern = ".+?\\[\"(.+?)\"\\].+?\\[\"(.+?)\"\\].+?\\[\"(.+?)\"\\]";
        Pattern logPattern = Pattern.compile(inputPattern);
        Map<String, List<Error>> projectErrorLogs = new TreeMap<>();
        Map<String, Map<String, Integer>> projectErrorCounter = new LinkedHashMap<>();

        String input = in.nextLine();
        while (!input.equals("END")) {
            Matcher logMatcher = logPattern.matcher(input);
            while (logMatcher.find()) {
                String name = logMatcher.group(1);
                String erType = logMatcher.group(2);
                String erMessage = logMatcher.group(3);

                if (!projectErrorLogs.containsKey(name)) {
                    projectErrorLogs.put(name, new ArrayList<>());
                    projectErrorCounter.put(name, new LinkedHashMap<>());

                    projectErrorCounter.get(name).put("Total", 0);
                    projectErrorCounter.get(name).put("Critical", 0);
                    projectErrorCounter.get(name).put("Warning", 0);
                }
                projectErrorLogs.get(name).add(new Error(erType, erMessage));
                projectErrorCounter.get(name).put(erType, projectErrorCounter.get(name).get(erType) + 1);
                projectErrorCounter.get(name).put("Total", projectErrorCounter.get(name).get("Total") + 1);

            }

            input = in.nextLine();
        }

        projectErrorCounter.entrySet().stream()
                .sorted((e1, e2) -> e1.getKey().compareTo(e2.getKey()))
                .sorted((e1, e2) -> e2.getValue().get("Total").compareTo(e1.getValue().get("Total")))
                .forEachOrdered(project -> {
                    System.out.printf("\r\n\r\n%s:", project.getKey());

                    project.getValue().entrySet().stream()
                            //.sorted((e1, e2) -> e2.getKey().compareTo(e1.getKey()))
                            //.sorted((e1, e2) -> e2.getValue().compareTo(e1.getValue()))
                            .forEachOrdered(error ->
                                    System.out.printf("\r\n%s: %d", formatError(error.getKey()), error.getValue())
                            );

                    final int[] warningCounter = {0};
                    final int[] criticalCounter = {0};

                    System.out.print("\r\nCritical Messages:");
                    projectErrorLogs.get(project.getKey()).stream()
                            .sorted((e1, e2) -> e1.message.compareTo(e2.message))
                            .sorted((e1, e2) -> Integer.compare(e1.message.length(), e2.message.length()))
                            .filter(error -> error.type.equals("Critical"))
                            .forEachOrdered(errorMessage -> {
                                System.out.printf("\r\n--->%s", errorMessage.message);
                                criticalCounter[0]++;
                            });
                    if (criticalCounter[0] == 0) {
                        System.out.print("\r\n--->None");
                    }

                    System.out.print("\r\nWarning Messages:");
                    projectErrorLogs.get(project.getKey()).stream()
                            .sorted((e1, e2) -> e1.message.compareTo(e2.message))
                            .sorted((e1, e2) -> Integer.compare(e1.message.length(), e2.message.length()))
                            .filter(error -> error.type.equals("Warning"))
                            .forEachOrdered(errorMessage -> {
                                System.out.printf("\r\n--->%s", errorMessage.message);
                                warningCounter[0]++;
                            });
                    if (warningCounter[0] == 0) {
                        System.out.print("\r\n--->None");
                    }

                });
    }

    private static String formatError(String error) {
        switch (error) {
            case "Critical":
                return "Critical";
            case "Warning":
                return "Warnings";
            default:
                return "Total Errors";
        }
    }
}
