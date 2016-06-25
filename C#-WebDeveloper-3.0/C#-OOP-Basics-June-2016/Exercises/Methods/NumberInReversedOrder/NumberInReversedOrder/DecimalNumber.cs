namespace NumberInReversedOrder
{
    using System.Linq;

    public class DecimalNumber
    {
        private string number;

        public DecimalNumber(string number)
        {
            this.number = number;
        }

        public string GetNumberReversed()
        {
            var result = string.Join("", this.number.Reverse());
            return result;
        }
    }
}