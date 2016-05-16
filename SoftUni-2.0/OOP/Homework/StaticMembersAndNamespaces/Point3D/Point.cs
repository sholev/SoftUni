using System;

namespace Point3D
{
    [Serializable]
    public class Point
    {
        // Fields
        private static readonly Point startingPoint = new Point(0, 0, 0);

        // Properties
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        
        public static Point StartingPoint
        {
            get { return startingPoint; }
        }

        // Constructors
        public Point(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        // Methods
        public override string ToString()
        {
            return String.Format("P({0}; {1}; {2})", this.X, this.Y, this.Z);
        }
    }
}
