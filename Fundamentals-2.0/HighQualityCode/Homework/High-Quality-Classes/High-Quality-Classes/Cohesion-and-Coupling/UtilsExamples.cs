namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            IGeometryUtils geometryUtils = new GeometryUtils();
            IFileUtils fileUtils = new FileUtils();

            string[] fileNames = { "example", "example.pdf", "example.new.pdf" };

            foreach (string fileName in fileNames)
            {
                try
                {
                    Console.WriteLine(fileUtils.GetFileExtension(fileName));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (string fileName in fileNames)
            {
                try
                {
                    Console.WriteLine(fileUtils.GetFileNameWithoutExtension(fileName));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Point2D firstPoint2D = new Point2D(1, -2);
            Point2D secondPoint2D = new Point2D(3, 4);
            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                geometryUtils.CalcDistance2D(firstPoint2D, secondPoint2D));

            Point3D firstPoint3D = new Point3D(5, 2, -1);
            Point3D secondPoint3D = new Point3D(3, -6, 4);
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                geometryUtils.CalcDistance3D(firstPoint3D, secondPoint3D));


            double width = 3;
            double height = 4;
            double depth = 5;
            Volume volume = new Volume(width, height, depth);

            Console.WriteLine("Volume = {0:f2}", volume.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", volume.CalcDiagonalXYZ(geometryUtils));
            Console.WriteLine("Diagonal XY = {0:f2}", volume.CalcDiagonalXY(geometryUtils));
            Console.WriteLine("Diagonal XZ = {0:f2}", volume.CalcDiagonalXZ(geometryUtils));
            Console.WriteLine("Diagonal YZ = {0:f2}", volume.CalcDiagonalYZ(geometryUtils));
        }
    }
}
