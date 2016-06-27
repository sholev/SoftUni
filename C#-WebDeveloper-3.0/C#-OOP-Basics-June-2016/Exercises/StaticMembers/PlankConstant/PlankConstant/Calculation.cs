namespace PlankConstant
{
    public static class Calculation
    {
        private const double PlankConstant = 6.62606896e-34;

        private const double Pi = 3.14159;

        public static double GetPlankConstant()
        {
            return PlankConstant / (2 * Pi);
        }
    }
}