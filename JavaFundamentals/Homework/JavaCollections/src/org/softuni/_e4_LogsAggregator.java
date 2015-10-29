package org.softuni;

import java.util.*;

public class _e4_LogsAggregator {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);

        TreeMap<String, Integer> userDurations = new TreeMap<>();
        HashMap<String, TreeSet<String>> userIPs = new HashMap<>();

        Integer inputLines = in.nextInt();
        in.nextLine();
        for (int i = 0; i < inputLines; i++) {
            String[] dataArguments = in.nextLine().split("\\s+");
            String IPAddress = dataArguments[0];
            String name = dataArguments[1];
            Integer duration = Integer.parseInt(dataArguments[2]);

            if (!userDurations.containsKey(name)) {
                userDurations.put(name, duration);
                userIPs.put(name, new TreeSet<>());
                userIPs.get(name).add(IPAddress);
            } else {
                userDurations.put(name, userDurations.get(name) + duration);
                userIPs.get(name).add(IPAddress);
            }
        }

        for (Map.Entry<String, Integer> user : userDurations.entrySet()) {
            String name = user.getKey();
            Integer duration = user.getValue();
            String IPAddress = userIPs.get(name).toString();
            System.out.printf("%s: %d %s\r\n", name, duration, IPAddress);
        }
    }
}
