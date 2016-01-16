namespace PerformanceOfOperations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public static class PerformanceTester
    {
        public static void Main(string[] args)
        {
            int numberOfTests = 1000;
            string[] tests =
                {
                    "int + int", "int - int", "++int", "int++", "int * int", "int / int",
                    "long + long", "long - long", "++long", "long++", "long * long", "long / long",
                    "double + double", "double - double", "++double", "double++", "double * double", "double / double",
                    "decimal + decimal", "decimal - decimal", "++decimal", "decimal++", "decimal * decimal", "decimal / decimal"
                };
            Dictionary<string, double[]> testResults = tests.ToDictionary(test => test, test => new double[numberOfTests]);

            Console.WriteLine("Starting analysis...");
            foreach (KeyValuePair<string, double[]> keyValuePair in testResults)
            {
                TestOperation(keyValuePair, numberOfTests);
            }

            foreach (KeyValuePair<string, double[]> keyValuePair in testResults)
            {
                var averageMilliseconds = keyValuePair.Value.Average();
                Console.WriteLine(
                    $"{keyValuePair.Key,20} Performed {numberOfTests * numberOfTests} tests, average time: {averageMilliseconds:F10} ms");
            }
            Console.ReadLine();
        }

        private static void TestOperation(KeyValuePair<string, double[]> keyValuePair, int numberOfTests)
        {
            for (int i = 0; i < keyValuePair.Value.Length; i++)
            {
                if (keyValuePair.Key.Contains("int"))
                {
                    keyValuePair.Value[i] = MakeOperation(1, keyValuePair.Key, numberOfTests);
                }
                else if (keyValuePair.Key.Contains("long"))
                {
                    keyValuePair.Value[i] = MakeOperation(1L, keyValuePair.Key, numberOfTests);
                }
                else if (keyValuePair.Key.Contains("double"))
                {
                    keyValuePair.Value[i] = MakeOperation(1D, keyValuePair.Key, numberOfTests);
                }
                else if (keyValuePair.Key.Contains("decimal"))
                {
                    keyValuePair.Value[i] = MakeOperation(1M, keyValuePair.Key, numberOfTests);
                }
            }
        }

        private static double MakeOperation(int operand, string operation, int numberOfTests)
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

        private static double MakeOperation(long operand, string operation, int numberOfTests)
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

        private static double MakeOperation(double operand, string operation, int numberOfTests)
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

        private static double MakeOperation(decimal operand, string operation, int numberOfTests)
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
