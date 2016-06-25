namespace RectangleIntersection
{
    public class Rectangle
    {
        public float X { get; private set; }

        public float Y { get; private set; }

        public float Width { get; private set; }

        public float Height { get; private set; }

        public float Top => this.Y;

        public float Bottom => this.Y + this.Height;

        public float Left => this.X;

        public float Right => this.X + this.Width;

        public Rectangle(float width, float height, float x, float y)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public bool Intersects(Rectangle other)
        {
            return (other.Left <= this.Right && this.Left <= other.Right)
                   && (other.Top <= this.Bottom && this.Top <= other.Bottom);
        }
    }
}