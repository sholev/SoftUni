namespace BasicMath
{
    using System;
    using System.Reflection;

    class Startup
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var parameters = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var methodName = parameters[0];
                var firstOperand = double.Parse(parameters[1]);
                var secondOperand = double.Parse(parameters[2]);

                Type basicMathClass = Assembly.GetExecutingAssembly().GetType("BasicMath.MathUtil");
                MethodInfo targetMethod = basicMathClass.GetMethod(methodName);
                var output = targetMethod.Invoke(null, new object[] { firstOperand, secondOperand });
                Console.WriteLine($"{output:f2}");
            }
        }
    }
}
