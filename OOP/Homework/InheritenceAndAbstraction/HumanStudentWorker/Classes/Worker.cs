using System;

namespace InheritenceAndAbstraction.Classes
{
    class Worker : Human
    {
        public const int WORK_DAYS_PER_WEEK = 5;

        private decimal weekSalary;
        private int workHours;

        public decimal PaymentPerHours { get; private set; }

        public int WorkHours
        {
            get { return this.workHours; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Work hours should not be negative");
                }
                if (value > 12)
                {
                    throw new ArgumentException("Work hours per day shouldn't be more than 12 hours");
                }
                this.workHours = value;
            }
        }
        
        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            set
            {
                if (value < 0M)
                {
                    throw new ArgumentException("Salary should not be negative");
                }
                this.weekSalary = value;
            }
        }

        public Worker(string name, string surname, decimal weekSalary, int workHours)
            : base(name, surname)
        {
            this.WeekSalary = weekSalary;
            this.WorkHours = workHours;
            this.PaymentPerHours = weekSalary / (workHours * WORK_DAYS_PER_WEEK);
        }

        public override string ToString()
        {
            return String.Format($"{base.ToString()} $/h: {this.PaymentPerHours:F2}");
        }
    }
}
