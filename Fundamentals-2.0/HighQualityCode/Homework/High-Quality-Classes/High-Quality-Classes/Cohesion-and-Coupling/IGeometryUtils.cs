namespace CohesionAndCoupling
{
    public interface IGeometryUtils
    {
        double CalcDistance2D(Point2D a, Point2D b);

        double CalcDistance3D(Point3D a, Point3D b);
    }
}