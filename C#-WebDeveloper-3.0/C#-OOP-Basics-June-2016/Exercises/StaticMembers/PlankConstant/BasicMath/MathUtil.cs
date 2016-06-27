namespace BasicMath
{
    public static class MathUtil
    {
        public static double Sum(double a, double b)
        {
            return a + b;
        }

        public static double Subtract(double a, double b)
        {
            return a - b;
        }

        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static double Divide(double a, double b)
        {
            return a / b;
        }

        public static double Percentage(double total, double percentage)
        {
            return total * (percentage / 100);
        }
    }
}