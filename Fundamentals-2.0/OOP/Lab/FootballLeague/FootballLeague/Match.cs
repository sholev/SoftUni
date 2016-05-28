using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague
{
    public class Match
    {
        // Fields
        private Team homeTeam;
        private Team awayTeam;
        private Score score;
        private int id;

        // Properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Score Score
        {
            get { return score; }
            set { score = value; }
        }

        public Team AwayTeam
        {
            get { return awayTeam; }
            set { awayTeam = value; }
        }

        public Team HomeTeam
        {
            get { return homeTeam; }
            set { homeTeam = value; }
        }

        // Constructors
        public Match(int id, Team homeTeam, Team awayTeam, Score score)
        {
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.Score = score;
            this.ID = id;

        }

        // Methods
        public Team GetWinner()
        {
            if (this.IsDraw())
            {
                return null;
            }

            return this.Score.HomeTeamGoals > this.Score.AwayTeamGoals
                ? this.HomeTeam
                : this.AwayTeam;
        }

        private bool IsDraw()
        {
            return this.Score.AwayTeamGoals == this.Score.HomeTeamGoals;
        }

        public override string ToString()
        {
            return String.Format($"{id}: {HomeTeam.Name} - {AwayTeam.Name} Result: {score}");
        }
    }
}
