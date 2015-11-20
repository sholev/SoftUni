using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague
{
    internal class LeagueManager
    {
        public static void HandleInput(string input)
        {
            var inputParameters = input.Split(
                " ".ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);

            switch (inputParameters[0])
            {
                case "AddTeam":
                    string teamName = inputParameters[1];
                    string teamNickname = inputParameters[2];
                    DateTime teamDate = DateTime.Parse(inputParameters[3]);
                    League.AddTeam(teamName, teamNickname, teamDate);
                    break;

                case "AddMatch":
                    int id = Int32.Parse(inputParameters[1]);
                    Team homeTeam = League.getTeamByName(inputParameters[2]);
                    Team awayTeam = League.getTeamByName(inputParameters[3]);
                    Score score = new Score(Int32.Parse(inputParameters[4]), Int32.Parse(inputParameters[5]));

                    League.AddMatch(id, homeTeam, awayTeam, score);
                    break;

                case "AddPlayerToTeam":
                    string playerName = inputParameters[1];
                    string playerSurname = inputParameters[2];
                    DateTime playerDate = DateTime.Parse(inputParameters[3]);
                    decimal salary = Decimal.Parse(inputParameters[4]);

                    Team addPlayerHere = League.getTeamByName(inputParameters[5]);
                    addPlayerHere.AddPlayer(
                        new Player(playerName, playerSurname, playerDate, salary, addPlayerHere));
                    break;

                case "ListTeams":
                    foreach (var team in League.Teams)
                    {
                        Console.WriteLine(team);
                    }
                    break;

                case "ListMatches":
                    foreach (var match in League.Matches)
                    {
                        Console.WriteLine(match);
                    }
                    break;

                default:
                    break;
            }
        }
    }
}