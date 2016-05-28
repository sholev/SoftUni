using System;

/* Copy/paste from the first problem with 
 * modifications to work on the current problem
 */

class CirclePerimeterArea
{
    static void Main()
    {
        double perimeter = 0d;
        double area = 0d;
        double temp = 0d;

        bool interrupt = false;

        object input = String.Empty;

        string row = new String('-', 37);
        string info = "Type \"exit\" to end the program.\n";
        string table = "\r\n| r         | perimeter | area      |\r\n";
        string soFar = info + row + table + row + "\r\n"; 
        
        do
        {
            for (int i = 0; i < 1; i++)
            {
                Console.Write(soFar + "| ");
                input = Console.ReadLine();

                if (input.ToString() == "exit")
                {
                    interrupt = true;
                    Console.Clear();
                    Console.Write(soFar);
                    return;
                }

                soFar += String.Format("| {0,-10}", input.ToString());

                if (Double.TryParse(input.ToString(), out temp))
                {
                    perimeter = 2 * Math.PI * temp;
                    area = Math.PI * Math.Pow(temp, 2);
                }
                Console.Clear();

            }

            soFar += String.Format("| {0,-10:F2}| {1,-10:F2}|\n{2}\n", perimeter, area, row);

        } while (!interrupt);
    }
}