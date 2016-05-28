using System;
using System.Collections.Generic;

namespace Point3D
{
    [Serializable]
    class Path
    {
        private List<Point> points;

        public List<Point> Points
        {
            get { return points; }
            set { points = value; }
        }

        public Path()
        {
            this.Points = new List<Point>();
        }

        public Path(params Point[] points)
        {
            this.Points = new List<Point>();

            foreach (var p in points)
            {
                this.AddPoint(p);
            }
        }

        public void AddPoint(Point point)
        {
            this.Points.Add(point);
        }
    }
}
