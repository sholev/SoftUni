namespace SystemSplit
{
    using System;

    using SystemSplit.Data;
    using SystemSplit.Factory;

    class Startup
    {
        private static readonly ComponentFactory Factory = new ComponentFactory();
        private static readonly ComponentRepository Repository = new ComponentRepository();

        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "System Split")
            {
                var parameters = input.Split(new[] { ' ', '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);

                var command = parameters[0];
                var output = ReadCommand(parameters, command);
                if (output != null)
                {
                    Console.WriteLine(output);
                }
            }

            var finalOutput = Repository.SystemSplit();
            Console.WriteLine(finalOutput);
        }

        private static string ReadCommand(string[] parameters, string command)
        {
            string output = null;
            switch (command)
            {
                case "RegisterPowerHardware":
                    var name = parameters[1];
                    var capacity = long.Parse(parameters[2]);
                    var memory = long.Parse(parameters[3]);

                    var powerHardware = Factory.RegisterPowerHardware(name, capacity, memory);
                    Repository.RegisterHardware(powerHardware);
                    break;

                case "RegisterHeavyHardware":
                    name = parameters[1];
                    capacity = long.Parse(parameters[2]);
                    memory = long.Parse(parameters[3]);

                    var heavyHardware = Factory.RegisterHeavyHardware(name, capacity, memory);
                    Repository.RegisterHardware(heavyHardware);
                    break;

                case "RegisterLightSoftware":
                    var hardwareName = parameters[1];
                    name = parameters[2];
                    capacity = long.Parse(parameters[3]);
                    memory = long.Parse(parameters[4]);

                    var lightSoftware = Factory.RegisterLightSoftware(name, capacity, memory);
                    Repository.RegisterSoftware(hardwareName, lightSoftware);
                    break;

                case "RegisterExpressSoftware":
                    hardwareName = parameters[1];
                    name = parameters[2];
                    capacity = long.Parse(parameters[3]);
                    memory = long.Parse(parameters[4]);

                    var expressSoftware = Factory.RegisterExpressSoftware(name, capacity, memory);
                    Repository.RegisterSoftware(hardwareName, expressSoftware);
                    break;

                case "ReleaseSoftwareComponent":
                    hardwareName = parameters[1];
                    var softwareName = parameters[2];

                    Repository.ReleaseSoftware(hardwareName, softwareName);
                    break;

                case "Dump":
                    hardwareName = parameters[1];

                    Repository.Dump(hardwareName);
                    break;

                case "Restore":
                    hardwareName = parameters[1];

                    Repository.Restore(hardwareName);
                    break;

                case "Destroy":
                    hardwareName = parameters[1];

                    Repository.Destroy(hardwareName);
                    break;

                case "Analyze":
                    output = Repository.Analyze();
                    break;

                case "DumpAnalyze":
                    output = Repository.DumpAnalyze();
                    break;

                default:
                    throw new ArgumentException();
            }

            return output;
        }
    }
}
