namespace Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public Student(string firstName, string lastName, IList<Exam> exams = null)
        {
            this.ValidateList(firstName.ToList(), nameof(firstName));
            this.ValidateList(lastName.ToList(), nameof(lastName));

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Exams = exams;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IList<Exam> Exams { get; set; }

        public IList<ExamResult> CheckExams()
        {
            this.ValidateList(this.Exams, nameof(this.Exams));

            IList<ExamResult> results = new List<ExamResult>();
            for (int i = 0; i < this.Exams.Count; i++)
            {
                results.Add(this.Exams[i].Check());
            }

            return results;
        }

        public double CalcAverageExamResultInPercents()
        {
            this.ValidateList(this.Exams, nameof(this.Exams));

            double[] examScore = new double[this.Exams.Count];
            IList<ExamResult> examResults = this.CheckExams();
            for (int i = 0; i < examResults.Count; i++)
            {
                examScore[i] = 
                    ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                    (examResults[i].MaxGrade - examResults[i].MinGrade);
            }

            return examScore.Average();
        }

        private void ValidateList<T>(ICollection<T> list, string parameterName)
        {
            if (list == null)
            {
                throw new ArgumentNullException(parameterName, $"{parameterName} is not initialized.");
            }
            else if (list.Count == 0)
            {
                throw new ArgumentException($"{parameterName} is empty.", parameterName);
            }
        }
    }
}
