namespace ISIS
{
    using ISIS.Factories;
    using ISIS.Interfaces;
    using ISIS.IO;
    using ISIS.Models.World;

    public class Program
    {
        public static void Main(string[] args)
        {
            IInpputReader reader = new ConsoleReader();
            IOutputWriter writer = new ConsoleWriter();

            IWarEffectFactory warEffectFactory = new WarEffectFactory();
            IAttackFactory attackFactory = new AttackFactory();
            IGroupFactory groupFactory = new GroupFactory(warEffectFactory, attackFactory);

            IWorld world = new World(reader, writer, groupFactory);
            world.Run();
        }
    }
}
