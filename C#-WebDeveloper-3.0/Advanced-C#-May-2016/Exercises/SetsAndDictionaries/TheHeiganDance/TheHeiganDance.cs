namespace ProblemsWithMatrices
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;

    public class Character
    {
        private double hp;

        private Point position;

        public bool IsDead => this.hp <= 0;

        public double Hp => this.hp;

        public double Damage { get; private set; }

        public double DamageForNextTurn { get; set; }

        public Point Position => this.position;

        public string KilledBy { get; set; }

        public Character(double hp, double damage)
        {
            this.KilledBy = null;
            this.hp = hp;
            this.Damage = damage;
        }

        public Character(double hp, double damage, Point position)
            : this(hp, damage)
        {
            this.position = position;
        }

        private void Move(string direction, Point spellPosition)
        {
            Point positionBeforeMove = this.position;

            switch (direction)
            {
                case "up":
                    this.position = new Point(this.position.X - 1, this.position.Y);
                    break;
                case "right":
                    this.position = new Point(this.position.X, this.position.Y + 1);
                    break;
                case "left":
                    this.position = new Point(this.position.X, this.position.Y - 1);
                    break;
                case "down":
                    this.position = new Point(this.position.X + 1, this.position.Y);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (this.IsInDamageArea(spellPosition) || this.IsAtWall())
            {
                this.position = positionBeforeMove;
            }
        }

        public void AttemptEvasion(string spell, Point spellPosition)
        {
            var directions = new Queue<string>(new[] { "up", "right", "down", "left" });

            while (directions.Count != 0 && (this.IsInDamageArea(spellPosition) || this.IsAtWall()))
            {
                this.Move(directions.Dequeue(), spellPosition);
            }

            if (this.IsInDamageArea(spellPosition))
            {
                switch (spell)
                {
                    case "Eruption":
                        this.TakeDamage(6000, spell);
                        break;
                    case "Cloud":
                        this.TakeDamage(3500, spell);
                        this.DamageForNextTurn = 3500;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void TakeDamage(double attackerDamage, string spell)
        {
            this.hp -= attackerDamage;

            if (this.KilledBy == null && this.hp <= 0)
            {
                this.KilledBy = spell;
            }
        }

        private bool IsAtWall()
        {
            return this.position.X < 0 || this.position.X > 14 || this.position.Y < 0 || this.position.Y > 14;
        }

        private bool IsInDamageArea(Point damagePosition)
        {
            return this.position.X >= damagePosition.X - 1 && this.position.X <= damagePosition.X + 1
                   && this.position.Y >= damagePosition.Y - 1 && this.position.Y <= damagePosition.Y + 1;
        }
    }

    class TheHeiganDance
    {
        static void Main(string[] args)
        {
            var playerDamage = double.Parse(Console.ReadLine());
            var player = new Character(18500, playerDamage, new Point(7, 7));
            var heigan = new Character(3000000, 0);

            while (!player.IsDead && !heigan.IsDead)
            {
                var parameters = Regex.Split(Console.ReadLine(), @"\s+");
                var spellName = parameters[0];
                var spellRow = int.Parse(parameters[1]);
                var spellCol = int.Parse(parameters[2]);

                if (player.DamageForNextTurn > 0)
                {
                    player.TakeDamage(player.DamageForNextTurn, "Cloud");
                    player.DamageForNextTurn = 0;
                }

                heigan.TakeDamage(player.Damage, "Player");
                if (heigan.IsDead || player.IsDead)
                {
                    break;
                }

                player.AttemptEvasion(spellName, new Point(spellRow, spellCol));
            }

            Console.WriteLine(heigan.IsDead ? "Heigan: Defeated!" : $"Heigan: {heigan.Hp:f2}");

            Console.WriteLine(
                player.IsDead
                    ? $"Player: Killed by {(player.KilledBy.Equals("Cloud") ? "Plague Cloud" : "Eruption")}"
                    : $"Player: {player.Hp}");

            Console.WriteLine($"Final position: {player.Position.X}, {player.Position.Y}");
        }
    }
}