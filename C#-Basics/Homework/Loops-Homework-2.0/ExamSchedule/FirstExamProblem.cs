using System;

namespace ExamSchedule
{
    class FirstExamProblem
    {
        static void Main(string[] args)
        {
            string startHour = string.Empty;
            string duration = string.Empty;

            startHour += Console.ReadLine();
            startHour += (":" + Console.ReadLine());
            startHour += (" " + Console.ReadLine());

            duration += Console.ReadLine();
            duration += (":" + Console.ReadLine());

            DateTime startTime = DateTime.Parse(startHour);
            TimeSpan durationTime = TimeSpan.Parse(duration);
            DateTime endTime = startTime + durationTime;

            Console.WriteLine(endTime.ToString("hh:mm:tt").ToUpper());
        }
    }
}
