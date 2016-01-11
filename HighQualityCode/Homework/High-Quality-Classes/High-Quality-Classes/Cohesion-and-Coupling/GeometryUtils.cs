namespace CohesionAndCoupling
{
    using System;

    public class GeometryUtils : IGeometryUtils
    {
        public double CalcDistance2D(Point2D a, Point2D b)
        {
            double distance = Math.Sqrt(
                ((b.X - a.X) * (b.X - a.X)) + 
                ((b.Y - a.Y) * (b.Y - a.Y)));

            return distance;
        }

        public double CalcDistance3D(Point3D a, Point3D b)
        {
            double distance = Math.Sqrt(
                ((b.X - a.X) * (b.X - a.X)) +
                ((b.Y - a.Y) * (b.Y - a.Y)) +
                ((b.Z - a.Z) * (b.Z - a.Z)));

            return distance;
        }
    }
}
