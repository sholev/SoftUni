namespace CohesionAndCoupling
{
    public class Volume
    {
        public Volume(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        private double Width { get; set; }

        private double Height { get; set; }

        private double Depth { get; set; }

        public double CalcVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        public double CalcDiagonalXYZ(IGeometryUtils util)
        {
            Point3D diagonalStartPoint3D = new Point3D();
            Point3D diagonalEndPoint3D = new Point3D(this.Width, this.Height, this.Depth);

            double distance = util.CalcDistance3D(diagonalStartPoint3D, diagonalEndPoint3D);
            return distance;
        }

        public double CalcDiagonalXY(IGeometryUtils util)
        {
            Point2D diagonalStartPoint2D = new Point2D();
            Point2D diagonalEndPoint2D = new Point2D(this.Width, this.Height);

            double distance = util.CalcDistance2D(diagonalStartPoint2D, diagonalEndPoint2D);
            return distance;
        }

        public double CalcDiagonalXZ(IGeometryUtils util)
        {
            Point2D diagonalStartPoint2D = new Point2D();
            Point2D diagonalEndPoint2D = new Point2D(this.Width, this.Depth);

            double distance = util.CalcDistance2D(diagonalStartPoint2D, diagonalEndPoint2D);
            return distance;
        }

        public double CalcDiagonalYZ(IGeometryUtils util)
        {
            Point2D diagonalStartPoint2D = new Point2D();
            Point2D diagonalEndPoint2D = new Point2D(this.Height, this.Depth);

            double distance = util.CalcDistance2D(diagonalStartPoint2D, diagonalEndPoint2D);
            return distance;
        }
    }
}
