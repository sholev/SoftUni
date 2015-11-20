using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague
{
    public class Team
    {
        // Fields
        private string name;
        private string nickname;
        private DateTime dateFounded;
        private List<Player> players;


        //  Properties
        public List<Player> Players
        {
            get { return this.players; }
        }

        public DateTime DateFounded
        {
            get { return this.dateFounded; }
            set
            {
                Validation.ValidateYear(
                    value,
                    Constants.MinAllowedFoundationYear,
                    "Foundation year should not be before " 
                    + Constants.MinAllowedFoundationYear);
                this.dateFounded = value;
            }
        }

        public string Nickname
        {
            get { return this.nickname; }
            set
            {
                Validation.ValidateName(value, 5, "The name should be at least 5 characters.");
                this.nickname = value;
            }
        }
        
        public string Name
        {
            get { return this.name; }
            set
            {
                Validation.ValidateName(value, 5, "The name should be at least 5 characters.");
                this.name = value;
            }
        }

        // Constructors
        public Team(string name, string nickname, DateTime dateFounded)
        {
            this.Name = name;
            this.Nickname = nickname;
            this.DateFounded = dateFounded;
            this.players = new List<Player>();
        }

        // Methods
        public void AddPlayer(Player player)
        {
            if (CheckIfPlayerExists(player))
            {
                throw new InvalidOperationException("Player already exists on that team.");
            }
            this.players.Add(player);
        }

        private bool CheckIfPlayerExists(Player player)
        {
            return this.players.Any(p => p.Name == player.Name && 
                                         p.Surname == player.Surname);
        }

        public override string ToString()
        {
            return String.Format($"Team: {name}; Nickname: {nickname} "
                + $"Founded: {DateFounded.ToShortDateString()} Current players: {(players == null ? 0 : players.Count)}");
        }
    }
}
