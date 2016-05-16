using System;

namespace Point3D
{
    class Program
    {
        static void Main()
        {
            Path pointsPath = new Path();
            
            pointsPath.AddPoint(new Point(1.32, 2.22, 3.12));
            pointsPath.AddPoint(new Point(3.32, 2.22, 1.12));
            pointsPath.AddPoint(new Point(4.31, 5.22, 6.13));
            pointsPath.AddPoint(new Point(5.37, 4.28, 3.19));
            
            Console.WriteLine(Point.StartingPoint);
            Console.WriteLine(DistanceCalculator.CalcDistance(pointsPath.Points[0], pointsPath.Points[1]));
            foreach (var point in pointsPath.Points)
            {
                Console.WriteLine(point.ToString());
            }

            string fileLocation = "../../path";
            Storage.WriteToBinaryFile(fileLocation, pointsPath);

            Console.WriteLine("\r\nPoints from file:");
            Path pathFromFile = Storage.ReadFromBinaryFile<Path>(fileLocation);
            foreach (var point in pathFromFile.Points)
            {
                Console.WriteLine(point.ToString());
            }
        }
    }
}