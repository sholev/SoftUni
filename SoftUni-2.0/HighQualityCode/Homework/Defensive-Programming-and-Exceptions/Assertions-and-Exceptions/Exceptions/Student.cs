namespace Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class Student
    {
        public Student(string firstName, string lastName, IList<Exam> exams = null)
        {
            this.ValidateObjectLength(firstName, nameof(firstName));
            this.ValidateObjectLength(lastName, nameof(lastName));

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Exams = exams;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IList<Exam> Exams { get; set; }

        public IList<ExamResult> CheckExams()
        {
            this.ValidateObjectLength(this.Exams, nameof(this.Exams));

            IList<ExamResult> results = new List<ExamResult>();
            for (int i = 0; i < this.Exams.Count; i++)
            {
                results.Add(this.Exams[i].Check());
            }

            return results;
        }

        public double CalcAverageExamResultInPercents()
        {
            this.ValidateObjectLength(this.Exams, nameof(this.Exams));

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

        private void ValidateObjectLength(dynamic obj, string parameterName, int minLength = 1)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(parameterName, $"{parameterName} is not initialized.");
            }

            int length;
            PropertyInfo[] properties = obj.GetType().GetProperties();
            if (properties.Any(p => p.Name.Equals("Length")))
            {
                length = obj.Length;
            }
            else if (properties.Any(p => p.Name.Equals("Count")))
            {
                length = obj.Count;
            }
            else
            {
                throw new ArgumentException($"{parameterName} is of type with length or count.", parameterName);
            }

            if (length < minLength)
            {
                throw new ArgumentException($"{parameterName} is empty.", parameterName);
            }
        }
    }
}
