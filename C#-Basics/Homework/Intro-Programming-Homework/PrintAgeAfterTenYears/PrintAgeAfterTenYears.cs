using System;

//Не взима в предвид навършени или не.

class PrintAgeAfterTenYears
{
    static void Main()
    {

        string sBday = Console.ReadLine();

        DateTime oBday = Convert.ToDateTime(sBday);
        DateTime oNow = DateTime.Today;
        
        Console.WriteLine("Now: " + (oNow.Year - oBday.Year));
        Console.WriteLine("After 10 years: " + (oNow.Year - oBday.Year + 10));
    }
}
