namespace AC_TestingSystem
{
    using AC_TestingSystem.Core;
    using AC_TestingSystem.UI;

    public class Program
    {
        public static void Main()
        {
            var engine = new Engine(new ConsoleUserInterface());
            engine.Run();
        }
    }
}
