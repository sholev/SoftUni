namespace Google
{
    public class Car
    {
        public string Model { get; set; }

        public string Speed { get; set; }

        public Car(string model, string speed)
        {
            this.Model = model;
            this.Speed = speed;
        }

        public override string ToString()
        {
            return $"{this.Model} {this.Speed}";
        }
    }
}