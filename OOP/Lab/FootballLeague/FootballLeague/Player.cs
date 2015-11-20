using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FootballLeague.Validation;
using static FootballLeague.Constants;

namespace FootballLeague
{
    public class Player
    {
        // Fields
        private string name;
        private string surname;
        private DateTime dateOfBirth;
        private decimal salary;
        private Team team;
        
        // Properties
        public Team Team
        {
            get { return team; }
            set { team = value; }
        }
        
        public decimal Salary
        {
            get { return salary; }
            set
            {
                CheckIfNegative(value, "Salary cannot be negative");                
                salary = value;
            }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                ValidateYear(
                    value,
                    MinAllowedBirthYear,
                    "Date of birth cannot be earlier than " + MinAllowedBirthYear);
                dateOfBirth = value;
            }
        }

        public string Surname
        {
            get { return this.surname; }
            set
            {
                ValidateName(value, 3, "Second name should be at least 3 chars long.");
                this.surname = value;
            }
        }
        
        public string Name
        {
            get { return name; }
            set
            {
                ValidateName(value, 3, "First name should be at least 3 chars long.");
                this.name = value;
            }
        }

        // Constructors
        public Player(string name, string surname, DateTime dateOfBirth, decimal salary, Team team)
        {
            this.Name = name;
            this.Surname = surname;
            this.DateOfBirth = dateOfBirth;
            this.Salary = salary;
            this.Team = team;
        }

        // TODO: Override toString();
    }
}
