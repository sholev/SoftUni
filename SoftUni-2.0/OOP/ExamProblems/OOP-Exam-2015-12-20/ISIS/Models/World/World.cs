namespace ISIS.Models.World
{
    using System;
    using System.Collections.Generic;

    using ISIS.Enumerations;
    using ISIS.Interfaces;

    public class World : IWorld
    {
        public World(IInpputReader reader, IOutputWriter writer, IGroupFactory groupFactory)
        {
            this.Reader = reader;
            this.Writer = writer;
            this.GroupFactory = groupFactory;
        }

        // Using List.Find, that is why not IList 
        private List<IGroup> Groups { get; } = new List<IGroup>();

        private IInpputReader Reader { get; }

        private IOutputWriter Writer { get;  }

        private IGroupFactory GroupFactory { get; }

        public void Run()
        {
            string[] inputParameters = this.Reader.ReadInput()
                .Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            while (!inputParameters[1].Equals("apocalypse()"))
            {
                if (inputParameters[1].Contains("create"))
                {
                    string[] creationParameters = inputParameters[1]
                        .Split(",()".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    string groupName = inputParameters[0];
                    int groupHealth = int.Parse(creationParameters[1]);
                    int groupDamage = int.Parse(creationParameters[2]);
                    WarEffects groupWarEffect;
                    Enum.TryParse(creationParameters[3], out groupWarEffect);
                    AttackType groupAttackType;
                    Enum.TryParse(creationParameters[4], out groupAttackType);

                    this.AddGroup(this.GroupFactory.CreateGroup(groupName, groupHealth, groupDamage, groupWarEffect, groupAttackType));
                }
                else if (inputParameters[1].Contains("attack"))
                {
                    string attackerName = inputParameters[0];
                    string targetName = inputParameters[1].Substring(7);
                    targetName = targetName.Substring(0, targetName.Length - 1);

                    IGroup attacker = this.Groups.Find(g => g.Name.Equals(attackerName));
                    IGroup target = this.Groups.Find(g => g.Name.Equals(targetName));

                    attacker.AttackTarget(target);
                }
                else if (inputParameters[1].Contains("status"))
                {
                    this.Groups.Sort((g1, g2) => g2.Damage.CompareTo(g1.Damage));
                    this.Groups.Sort((g1, g2) => g2.HealthPoints.CompareTo(g1.HealthPoints));
                    foreach (IGroup group in this.Groups)
                    {
                        this.Writer.PrintOutput(group.ToString());
                    }
                }

                foreach (IGroup group in this.Groups)
                {
                    group.IncrementDays();
                }

                inputParameters = this.Reader.ReadInput()
                    .Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public void AddGroup(IGroup group)
        {
            this.Groups.Add(group);
        }
    }
}
