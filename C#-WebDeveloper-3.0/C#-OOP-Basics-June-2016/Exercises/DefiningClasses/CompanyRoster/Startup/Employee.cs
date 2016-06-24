namespace CompanyRoster
{
    public class Employee
    {
        public string Name { get; set; }

        public decimal Salary { get; set; }

        public string Position { get; set; }

        public string Department { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public Employee(
            string name,
            decimal salary,
            string position,
            string department,
            string email = null,
            int? age = null)
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
            this.Age = age ?? -1;
            this.Email = email ?? "n/a";
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Salary:f2} {this.Email} {this.Age}";
        }
    }
}