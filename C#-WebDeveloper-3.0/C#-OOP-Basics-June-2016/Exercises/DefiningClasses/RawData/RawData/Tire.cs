namespace RawData
{
    public class Tire
    {
        public int Age { get; set; }

        public float Pressure { get; set; }

        public Tire(int age, float pressure)
        {
            this.Age = age;
            this.Pressure = pressure;
        }
    }
}