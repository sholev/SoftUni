using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class ExamTaskTwo
    {
        struct Team
        {
            public string name;
            public int score;
        }

        static void Main(string[] args)
        {
            decimal payment = decimal.Parse(Console.ReadLine());
            
            string game = Console.ReadLine();
            string[] gameSplit = new string[3];
            List<string> matches = new List<string>();
            List<string> teamNames = new List<string>();
            string temp = string.Empty;

            while (game != "End of the league.")
            {
                matches.Add(game);

                game = Console.ReadLine();
            }

            foreach (var item in matches)
            {
                gameSplit = item.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                temp = gameSplit[0];

                if (!teamNames.Contains(temp))
                {
                    teamNames.Add(temp);
                }

                temp = gameSplit[2];

                if (!teamNames.Contains(temp))
                {
                    teamNames.Add(temp);
                }
            }

            teamNames.Sort();

            List<Team> teamsAndScore = new List<Team>();
            Team tempTeam = new Team();

            for (int i = 0; i < teamNames.Count; i++)
            {
                tempTeam.name = teamNames[i];
                tempTeam.score = GetScore(tempTeam.name, matches);

                teamsAndScore.Add(tempTeam);
            }

            decimal paymentBGN = payment * 1.94m;
            decimal totalPrice = paymentBGN * matches.Count;

            Console.WriteLine("{0:F2}lv.", totalPrice);
            foreach (var item in teamsAndScore)
            {
                Console.WriteLine("{0} - {1} points.", AddSpacesToSentence(item.name, false), item.score);
            }
        }

        private static string AddSpacesToSentence(string text, bool preserveAcronyms)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                    if ((text[i - 1] != ' ' && !char.IsUpper(text[i - 1])) ||
                        (preserveAcronyms && char.IsUpper(text[i - 1]) &&
                         i < text.Length - 1 && !char.IsUpper(text[i + 1])))
                        newText.Append(' ');
                newText.Append(text[i]);
            }
            return newText.ToString();
        }

        //private static string FixName(string name)
        //{
        //    if (name == "ManchesterUnited")
        //    {
        //        return "Manchester United";
        //    }
        //    else if (name == "ManchesterCity")
        //    {
        //        return "Manchester City";
        //    }
        //    else
        //    {
        //        return name;
        //    }
        //}

        private static int GetScore(string name, List<string> matches)
        {
            int result = 0;

            string[] temp = new string[3];

            foreach (var item in matches)
            {
                temp = item.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (temp[0] == name)
                {
                    if (temp[1] == "1")
                    {
                        result += 3;
                    }
                    else if (temp[1] == "X")
                    {
                        result += 1;
                    }
                }
                else if (temp[2] == name)
                {
                    if (temp[1] == "2")
                    {
                        result += 3;
                    }
                    else if (temp[1] == "X")
                    {
                        result += 1;
                    }
                }
            }

            return result;
        }
    }
}
