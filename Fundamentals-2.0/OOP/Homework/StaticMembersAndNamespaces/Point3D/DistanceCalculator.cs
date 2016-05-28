using System;

namespace Point3D
{
    public static class DistanceCalculator
    {
        public static double CalcDistance(Point A, Point B)
        {
            return Math.Sqrt(
                Math.Pow(A.X - B.X, 2) +
                Math.Pow(A.Y - B.Y, 2) +
                Math.Pow(A.Z - B.Z, 2));
        }
    }
}
