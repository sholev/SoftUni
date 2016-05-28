namespace PerformanceOfOperations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    public static class PerformanceTester
    {
        public static void Main(string[] args)
        {
            int numberOfTests = 1000;
            
            string[] operations =
                {
                    "int + int", "int - int", "++int", "int++", "int += 1", "int * int", "int / int",
                    "long + long", "long - long", "++long", "long++","long += 1", "long * long", "long / long",
                    "double + double", "double - double", "++double", "double++", "double += 1", "double * double", "double / double",
                    "decimal + decimal", "decimal - decimal", "++decimal", "decimal++", "decimal += 1", "decimal * decimal", "decimal / decimal"
                };
            Dictionary<string, double[]> operationsTestResults = operations.ToDictionary(
                test => test,
                test => new double[numberOfTests]);

            Console.WriteLine("Starting operation analysis...");
            foreach (KeyValuePair<string, double[]> operationTestResult in operationsTestResults)
            {
                PopulateOperationTest(operationTestResult, numberOfTests);
            }
            
            string[] methods =
                {
                    "Math.Sqrt(double)", "Math.Log(double)", "Math.Sin(double)",
                    "Math.Sqrt(decimal)", "Math.Log(decimal)", "Math.Sin(decimal)",
                };
            Dictionary<string, double[]> methodsTestResults = methods.ToDictionary(
                method => method,
                method => new double[numberOfTests]);

            Console.WriteLine("Starting method analysis...");
            foreach (KeyValuePair<string, double[]> methodsTestResult in methodsTestResults)
            {
                PopulateMethodTest(methodsTestResult, numberOfTests);
            }

            Console.WriteLine($"Analysis done, performed {numberOfTests * numberOfTests} tests for each case:");
            var combinedResults = operationsTestResults
                .Concat(methodsTestResults)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (KeyValuePair<string, double[]> combinedResult in combinedResults)
            {
                var averageMilliseconds = combinedResult.Value.Average();
                Console.WriteLine(
                    $"{combinedResult.Key,20} average time: {averageMilliseconds:F10} ms");
            }

            //WriteAnalysisTextTable(operationsTestResults, methodsTestResults, numberOfTests);
        }

        private static void WriteAnalysisTextTable(
            IEnumerable<KeyValuePair<string, double[]>> operationsTestResults,
            IEnumerable<KeyValuePair<string, double[]>> methodsTestResults,
            int numberOfTests)
        {
            throw new NotImplementedException();
            //Currently don't have time for doing this, it isn't mandatory but still. ;(

            using (StreamWriter file = new StreamWriter("..\\..\\OperationResults.txt"))
            {
                file.WriteLine(new string('_', 5 * 13 + 5));
                file.WriteLine($"| {$"n = {numberOfTests}",-12}| {"int",-12}| {"long",-12}| {"double",-12}| {"decimal",-12}|");

                foreach (KeyValuePair<string, double[]> operationsTestResult in operationsTestResults)
                {
                    string[] operationText = operationsTestResult.Key.Split(
                        " ".ToCharArray(),
                        StringSplitOptions.RemoveEmptyEntries);

                    //string operation = operationText[0];
                    //file.Write($"| {operation},-12");

                    foreach (double result in operationsTestResult.Value)
                    {
                        
                    }
                }

                file.WriteLine("test");
            }
        }

        private static void PopulateMethodTest(KeyValuePair<string, double[]> methodsTestResult, int numberOfTests)
        {

            for (int i = 0; i < methodsTestResult.Value.Length; i++)
            {
                if (methodsTestResult.Key.Contains("double"))
                {
                    methodsTestResult.Value[i] = TestMethod(1D, methodsTestResult.Key, numberOfTests);
                }
                else if (methodsTestResult.Key.Contains("decimal"))
                {
                    methodsTestResult.Value[i] = TestMethod(1M, methodsTestResult.Key, numberOfTests);
                }
            }
        }

        private static double TestMethod(double methodParameter, string method, int numberOfTests)
        {

            Stopwatch stopwatch = new Stopwatch();
            TimeSpan result = new TimeSpan();

            if (method.Contains("Sqrt"))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    Math.Sqrt(methodParameter);
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();
                }
            }
            else if (method.Contains("Log"))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    Math.Log(methodParameter);
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();
                }
            }
            else if (method.Contains("Sin"))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    Math.Sin(methodParameter);
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();
                }
            }
          
            return result.TotalMilliseconds / numberOfTests;
        }

        private static double TestMethod(decimal methodParameter, string method, int numberOfTests)
        {

            Stopwatch stopwatch = new Stopwatch();
            TimeSpan result = new TimeSpan();

            if (method.Contains("Sqrt"))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    Math.Sqrt((double)methodParameter);
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();
                }
            }
            else if (method.Contains("Log"))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    Math.Log((double)methodParameter);
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();
                }
            }
            else if (method.Contains("Sin"))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    Math.Sin((double)methodParameter);
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();
                }
            }

            return result.TotalMilliseconds / numberOfTests;
        }

        private static void PopulateOperationTest(KeyValuePair<string, double[]> operationTestResult, int numberOfTests)
        {
            for (int i = 0; i < operationTestResult.Value.Length; i++)
            {
                if (operationTestResult.Key.Contains("int"))
                {
                    operationTestResult.Value[i] = TestOperation(1, operationTestResult.Key, numberOfTests);
                }
                else if (operationTestResult.Key.Contains("long"))
                {
                    operationTestResult.Value[i] = TestOperation(1L, operationTestResult.Key, numberOfTests);
                }
                else if (operationTestResult.Key.Contains("double"))
                {
                    operationTestResult.Value[i] = TestOperation(1D, operationTestResult.Key, numberOfTests);
                }
                else if (operationTestResult.Key.Contains("decimal"))
                {
                    operationTestResult.Value[i] = TestOperation(1M, operationTestResult.Key, numberOfTests);
                }
            }
        }

        private static double TestOperation(int operand, string operation, int numberOfTests)
        {
            Stopwatch stopwatch = new Stopwatch();
            TimeSpan result = new TimeSpan();
            int one = 1;
            if (operation.Contains(" + "))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    operand = operand + operand;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }
            else if (operation.Contains(" - "))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    operand = operand - operand;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }
            else if (operation.StartsWith("++"))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    ++operand;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }
            else if (operation.EndsWith("++"))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    operand++;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }
            else if (operation.Contains("+="))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    operand += operand;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }
            else if (operation.Contains(" * "))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    operand = operand * operand;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }
            else if (operation.Contains(" / "))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    operand = operand / operand;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }

            return result.TotalMilliseconds / numberOfTests;
        }

        private static double TestOperation(long operand, string operation, int numberOfTests)
        {
            Stopwatch stopwatch = new Stopwatch();
            TimeSpan result = new TimeSpan();
            long one = 1;
            if (operation.Contains(" + "))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    operand = operand + operand;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }
            else if (operation.Contains(" - "))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    operand = operand - operand;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }
            else if (operation.StartsWith("++"))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    ++operand;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }
            else if (operation.EndsWith("++"))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    operand++;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }
            else if (operation.Contains("+="))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    operand += operand;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }
            else if (operation.Contains(" * "))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    operand = operand * operand;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }
            else if (operation.Contains(" / "))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    operand = operand / operand;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }

            return result.TotalMilliseconds / numberOfTests;
        }

        private static double TestOperation(double operand, string operation, int numberOfTests)
        {
            Stopwatch stopwatch = new Stopwatch();
            TimeSpan result = new TimeSpan();
            double one = 1;
            if (operation.Contains(" + "))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    operand = operand + operand;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }
            else if (operation.Contains(" - "))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    operand = operand - operand;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }
            else if (operation.StartsWith("++"))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    ++operand;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }
            else if (operation.EndsWith("++"))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    operand++;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }
            else if (operation.Contains("+="))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    operand += operand;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }
            else if (operation.Contains(" * "))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    operand = operand * operand;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }
            else if (operation.Contains(" / "))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    operand = operand / operand;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }

            return result.TotalMilliseconds / numberOfTests;
        }

        private static double TestOperation(decimal operand, string operation, int numberOfTests)
        {
            Stopwatch stopwatch = new Stopwatch();
            TimeSpan result = new TimeSpan();
            decimal one = 1;
            if (operation.Contains(" + "))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    operand = operand + operand;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }
            else if (operation.Contains(" - "))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    operand = operand - operand;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }
            else if (operation.StartsWith("++"))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    ++operand;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }
            else if (operation.EndsWith("++"))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    operand++;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }
            else if (operation.Contains("+="))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    operand += operand;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }
            else if (operation.Contains(" * "))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    operand = operand * operand;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }
            else if (operation.Contains(" / "))
            {
                for (int i = 0; i < numberOfTests; i++)
                {
                    stopwatch.Start();
                    operand = operand / operand;
                    result += stopwatch.Elapsed;
                    stopwatch.Reset();

                    operand = one;
                }
            }

            return result.TotalMilliseconds / numberOfTests;
        }
    }
}
