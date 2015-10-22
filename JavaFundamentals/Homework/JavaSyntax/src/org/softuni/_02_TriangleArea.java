package org.softuni;

import java.awt.*;
import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.Scanner;

public class _02_TriangleArea {

    public static void main(String[] args) {

        System.out.println("Enter x and y separated by space.");
        Scanner in = new Scanner(System.in);
        System.out.print("A(x, y) = ");
        Point A = new Point(in.nextInt(), in.nextInt());
        System.out.print("B(x, y) = ");
        Point B = new Point(in.nextInt(), in.nextInt());
        System.out.print("C(x, y) = ");
        Point C = new Point(in.nextInt(), in.nextInt());

        double AB = Math.sqrt(Math.pow(B.x - A.x, 2) + Math.pow(B.y - A.y, 2));
        double BC = Math.sqrt(Math.pow(B.x - C.x, 2) + Math.pow(B.y - C.y, 2));
        double CA = Math.sqrt(Math.pow(C.x - A.x, 2) + Math.pow(C.y - A.y, 2));


        NumberFormat decimalFormat = new DecimalFormat("##.##");

        if ((AB + BC > CA) && (BC + CA > AB) && (AB + CA > BC)) {
            double hp = (AB + BC + CA) / 2; // Half perimeter.
            double area = Math.sqrt(hp * (hp - AB) * (hp - BC) * (hp - CA));

            System.out.printf("Triangle area: %s\r\n", decimalFormat.format(area));
        }
        else {
            System.out.println(0);
        }
    }
}
