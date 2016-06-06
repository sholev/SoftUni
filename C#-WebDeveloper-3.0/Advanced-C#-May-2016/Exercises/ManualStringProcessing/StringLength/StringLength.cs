namespace ManualStringProcessing
{
    using System;
    using System.Text;

    class StringLength
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder output = new StringBuilder();
            output.Append(input);

            if (output.Length < 20)
            {
                output.Append(new string('*', 20 - output.Length));
            }
            else if (output.Length > 20)
            {
                output.Remove(20, output.Length - 20);
            }

            Console.WriteLine(output);
        }
    }
}
