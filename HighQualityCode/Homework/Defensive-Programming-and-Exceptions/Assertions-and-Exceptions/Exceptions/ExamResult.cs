namespace Exceptions
{
    using System;

    public class ExamResult
    {
        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            if (grade < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(grade), $"{nameof(grade)} cannot be negative.");
            }

            if (minGrade < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minGrade), $"{nameof(minGrade)} cannot be negative.");
            }

            if (maxGrade <= minGrade)
            {
                throw new ArgumentOutOfRangeException(nameof(maxGrade), $"{nameof(maxGrade)} cannot be lower than {nameof(minGrade)}."); ;
            }

            if (string.IsNullOrEmpty(comments))
            {
                throw new ArgumentNullException(nameof(comments), $"{nameof(comments)} cannot be null.");
            }

            this.Grade = grade;
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Comments = comments;
        }

        public int Grade { get; private set; }

        public int MinGrade { get; private set; }

        public int MaxGrade { get; private set; }

        public string Comments { get; private set; }
    }
}
