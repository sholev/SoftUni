namespace ManualStringProcessing
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class FormattingNumbers
    {
        static void Main(string[] args)
        {
            var nums = Regex.Split(Console.ReadLine(), @"\s+");
            var a = int.Parse(nums[0]);
            var b = decimal.Parse(nums[1]);
            var c = decimal.Parse(nums[2]);

            var binary = Convert.ToString(a, 2);
            if (binary.Length > 10)
            {
                binary = binary.Substring(0, 10);
            }

            Console.WriteLine("|{0,-10:X}|{1}|{2,10:F2}|{3,-10:F3}|", (int)a, binary.PadLeft(10, '0'), b, c);
        }
    }
}
