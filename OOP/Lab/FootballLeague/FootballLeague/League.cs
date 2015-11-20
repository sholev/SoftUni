using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague
{
    public static class League
    {
        // Fields
        private static List<Team> teams = new List<Team>();
        private static List<Match> matches = new List<Match>();

        // Properties
        public static List<Match> Matches
        {
            get { return matches; }
            private set { matches = value.ToList(); }
        }

        public static List<Team> Teams
        {
            get { return teams; }
            private set { teams = value.ToList(); }
        }

        // Methods
        public static Team getTeamByName(string name)
        {
            return teams.Find(t => t.Name.Equals(name));
        }

        public static void AddMatch(int id, Team homeTeam, Team awayTeam, Score score)
        {
            if (!matchExists(id))
            {
                Matches.Add(new Match(id, homeTeam, awayTeam, score));
            }
        }

        private static bool matchExists(int id)
        {
            return Matches.Any(m => m.ID.Equals(id));
        }

        public static void AddTeam(string name, string nickname, DateTime dateFounded)
        {
            if (!teamExists(name))
            {
                Teams.Add(new Team(name, nickname, dateFounded));
            }
        }

        private static bool teamExists(string name)
        {
            return Teams.Any(t => t.Name.Equals(name));
        }
    }
}
