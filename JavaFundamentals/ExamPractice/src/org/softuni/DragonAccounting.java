package org.softuni;

// Java Fundamentals - 4 October 2015

import java.math.BigDecimal;
import java.util.LinkedList;
import java.util.List;
import java.util.Scanner;

public class DragonAccounting {

    private static class EmployeeBatch {
        long numberOfEmployees;
        BigDecimal salary;
        int totalEmploymentDays = 1;
        int monthWorkDays = 0;

        public EmployeeBatch(long numberOfEmployees, BigDecimal salary) {
            this.numberOfEmployees = numberOfEmployees;
            this.salary = salary;
        }

        public void incrementDays() {

            if (totalEmploymentDays > 0 && totalEmploymentDays % 365 == 0) {
                salary = salary.multiply(BigDecimal.valueOf(1.006));
            }
            totalEmploymentDays++;
            monthWorkDays++;
        }

        public BigDecimal paySalary() {
            BigDecimal payment = salary
                    .divide(BigDecimal.valueOf(30), 9, BigDecimal.ROUND_UP)
                    .setScale(7, BigDecimal.ROUND_DOWN)
                    .multiply(BigDecimal.valueOf(monthWorkDays))
                    .multiply(BigDecimal.valueOf(numberOfEmployees));
            monthWorkDays = 0;
            return payment;
        }

        public long fireEmployees(long numberToFire) {
            numberOfEmployees = numberOfEmployees - numberToFire;
            return numberOfEmployees;
        }
    }

    public static void main(String[] args) {

        Scanner in = new Scanner(System.in);
        List<EmployeeBatch> employees = new LinkedList<>();
        BigDecimal capital = new BigDecimal(in.nextLine());
        int daysPassed = 0;
        String input = in.nextLine();
        while (!input.toLowerCase().equals("end")) {
            String[] inputArguments = input.split(";");
            long hired = Long.parseLong(inputArguments[0]);
            long fired = Long.parseLong(inputArguments[1]);
            BigDecimal salary = new BigDecimal(inputArguments[2]);

            daysPassed++;
            // hire
            if (hired != 0) {
                employees.add(new EmployeeBatch(hired, salary));
            }
            // raise
            employees.forEach(EmployeeBatch::incrementDays);
            // pay
            if (daysPassed > 0 && daysPassed % 30 == 0) {
                for (EmployeeBatch employeeBatch : employees) {
                    capital = capital.subtract(employeeBatch.paySalary());
                }
            }
            // fire
            if (fired != 0 && employees.size() != 0) {

                long employeesLeft = employees.get(0).fireEmployees(fired);

                while (employeesLeft < 0 && employees.size() != 0) {
                    employees.remove(0);
                    employeesLeft = employees.get(0).fireEmployees(Math.abs(employeesLeft));
                }
                if (employeesLeft == 0 && employees.size() != 0) {
                    employees.remove(0);
                }
            }
            // additional events
            for (int i = 3; i < inputArguments.length; i++) {
                String[] additionalChanges = inputArguments[i].split(":");
                switch (additionalChanges[0]) {
                    case "Previous years deficit":
                    case "Machines":
                    case "Taxes":
                        capital = capital.subtract(new BigDecimal(additionalChanges[1]));
                        break;
                    case "Product development":
                    case "Unconditional funding":
                        capital = capital.add(new BigDecimal(additionalChanges[1]));
                        break;
                }
            }
            // check bankruptcy
            if (capital.compareTo(BigDecimal.ZERO) == -1) {
                System.out.println("BANKRUPTCY: " + capital.setScale(4, BigDecimal.ROUND_DOWN).abs());
                break;
            }
            input = in.nextLine();
        }

        if (capital.compareTo(BigDecimal.ZERO) != -1) {
            long employeesLeft = 0;
            for (EmployeeBatch employeeBatch : employees) {
                employeesLeft += employeeBatch.numberOfEmployees;
            }
            System.out.println(employeesLeft + " " + capital.setScale(4, BigDecimal.ROUND_DOWN));
        }
    }
}