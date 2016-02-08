namespace AC_TestingSystem.Core
{
    using System;

    using AC_TestingSystem.Data;
    using AC_TestingSystem.Interfaces;
    using AC_TestingSystem.Models;
    using AC_TestingSystem.Work;

    public class Engine
    {
        private readonly Controller controller;

        private readonly IUserInterface userInterface;

        private readonly Repository repository;
        
        public Engine(IUserInterface userInterface)
        {
            this.repository = new Repository();
            this.controller = new Controller(this, this.repository);
            this.userInterface = userInterface;
        }

        public Command Command { get; private set; }

        public void Run()
        {
            while (true)
            {
                string input = this.userInterface.ReadLine();
                string output;

                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }

                input = input.Trim();
                try
                {
                    this.Command = new Command(input);
                    output = this.controller.ExecuteCommand();
                }
                catch (Exception ex)
                {
                    output = ex.Message;
                }

                this.userInterface.WriteLine(output);
            }
        }

        public void ValidateParametersCount(Command command, int count)
        {
            if (command.Parameters.Length != count)
            {
                throw new InvalidOperationException(Constants.InvalidCommand);
            }
        }
    }
}
