package org.softuni;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _e4_UserLogs {

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);
        TreeMap<String, LinkedHashMap<String, Integer>> data = new TreeMap<>();
        String input = in.nextLine();
        while (!input.equals("end")) {
            Matcher matches = Pattern
                    .compile("IP=([\\d.ABCDEFabcdef:]+)\\smessage='.*?'\\suser=(.+)")
                    .matcher(input);

            String IP = "";
            String user = "";
            if (matches.find()) {
                IP = matches.group(1);
                user = matches.group(2);
            } else {
                System.out.println("Didn't properly match.");
            }
            if (!data.containsKey(user)) {
                data.put(user, new LinkedHashMap<>());
            }
            if (!data.get(user).containsKey(IP)) {
                data.get(user).put(IP, 1);
            } else {
                data.get(user).put(IP, data.get(user).get(IP) + 1);
            }

            input = in.nextLine();
        }

        for (Map.Entry<String, LinkedHashMap<String, Integer>> user : data.entrySet()) {
            System.out.println(user.getKey() + ":");
            List<String> ips = new LinkedList<>();
            for (Map.Entry<String, Integer> IP : user.getValue().entrySet()) {
                ips.add(IP.getKey() + " => " + IP.getValue());
            }
            System.out.println(String.join(", ", ips) + ".");
        }
    }
}
