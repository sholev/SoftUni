using System;

class EmployeeData
{
    static void Main()
    {
        string firstName = "Amanda";
        string lastName = "Jonson";
        sbyte age = 27;
        char gender = 'f';
        ulong personalID = 8306112507;
        uint employeeNum = 27563571;

        Console.WriteLine("First name: {0}\nLast name: {1}\nAge: {2}\nGender: {3}\nPersonal ID: {4}\nUnique Employee number: {5}",
            firstName, lastName, age, gender, personalID, employeeNum);
    }
}