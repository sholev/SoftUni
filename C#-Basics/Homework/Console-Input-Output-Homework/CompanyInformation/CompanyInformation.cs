using System;

/* This could be a lot more straightforward with a class,
 * but I currently lack the time to go and read up about them in c#.
 */

class CompanyInformation
{
    static void Main()
    {
        string companyName, companyAddress, companyPhone, companyFax, webPage,
            managerName, managerSurname, managerAge, managerPhone = String.Empty;

        Console.Write("Company name: ");
        companyName = Console.ReadLine();
        Console.Write("Company address: ");
        companyAddress = Console.ReadLine();
        Console.Write("Company phune number: ");
        companyPhone = Console.ReadLine();
        Console.Write("Company fax number: ");
        companyFax = Console.ReadLine();
        Console.Write("Company website: ");
        webPage = Console.ReadLine();
        Console.Write("Manager name: ");
        managerName = Console.ReadLine();
        Console.Write("Manager surname: ");
        managerSurname = Console.ReadLine();
        Console.Write("Manager age: ");
        managerAge = Console.ReadLine();
        Console.Write("Manager phone: ");
        managerPhone = Console.ReadLine();

        Console.WriteLine("{0}\r\nAddress: {1}\r\nTel. {2}\r\nFax: {3}\r\nWebsite: {4}\r\nManager: {5} {6} (age: {7}, tel. {8})",
            companyName, companyAddress, companyPhone, companyFax, webPage, managerName, managerSurname, managerAge, managerPhone);
    }
}
