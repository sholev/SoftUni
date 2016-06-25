namespace LastDigitName
{
    public class Number
    {
        private readonly string[] digitWords =
            {
                "zero", "one", "two", "three", "four", "five",
                "six", "seven", "eight", "nine", "ten"
            };

        private string number;

        public Number(string number)
        {
            this.number = number;
        }

        public string GetLastDigit()
        {
            var lastDigit = (int)char.GetNumericValue(this.number, this.number.Length - 1);
            return this.digitWords[lastDigit];
        }
    }
}