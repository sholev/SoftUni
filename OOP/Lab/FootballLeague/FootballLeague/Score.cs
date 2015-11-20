using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague
{
    public class Score
    {

        // Fields
        private int homeTeamGoals;
        private int awayTeamGoals;

        // Properties
        public int AwayTeamGoals
        {
            get { return awayTeamGoals; }
            set
            {
                Validation.CheckIfNegative(value, "Goals shouldn't be negative.");
                this.awayTeamGoals = value;
            }
        }

        public int HomeTeamGoals
        {
            get { return this.homeTeamGoals; }
            set
            {
                Validation.CheckIfNegative(value, "Goals shouldn't be negative.");
                this.homeTeamGoals = value;
            }
        }

        // Constructors
        public Score(int awayTeamGoals, int homeTeamGoals)
        {
            this.AwayTeamGoals = awayTeamGoals;
            this.HomeTeamGoals = homeTeamGoals;
        }

        // Methods
        public override string ToString()
        {
            return String.Format($"{HomeTeamGoals}:{AwayTeamGoals}");
        }
    }
}
