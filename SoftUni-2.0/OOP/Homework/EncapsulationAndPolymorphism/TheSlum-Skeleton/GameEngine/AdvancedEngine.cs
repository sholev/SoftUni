namespace TheSlum.GameEngine
{
    using System;
    using System.Linq;

    public class AdvancedEngine : Engine
    {
        protected override void ExecuteCommand(string[] inputParams)
        {
            base.ExecuteCommand(inputParams);

            switch (inputParams[0])
            {
                case "create":
                    this.CreateCharacter(inputParams);
                    break;

                case "add":
                    this.AddItemTOCharacter(inputParams);
                    break;

                default:
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            string characterType = inputParams[1];
            string id = inputParams[2];
            int x = int.Parse(inputParams[3]);
            int y = int.Parse(inputParams[4]);
            string teamType = inputParams[5];
            Team team = (Team)Enum.Parse(typeof(Team), teamType);

            Character character = Characters.CharacterFactory.Create(characterType, id, team, x, y);
            characterList.Add(character);
        }

        protected void AddItemTOCharacter(string[] parameters)
        {
            string characterId = parameters[1];
            Character character = characterList.First(c => c.Id == characterId);
            Item item = Items.ItemFactory.Create(parameters[2], parameters[3]);
            character.AddToInventory(item);
        }
    }
}
