namespace Exceptions
{
    using System;

    public class CSharpExam : Exam
    {
        public CSharpExam(int score)
        {
            if (score < 0 || score > 100)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(score), $"{nameof(score)} is not in in the range of (0 < n < 100).");
            }

            this.Score = score;
        }

        public int Score { get; private set; }

        public override ExamResult Check()
        {
            var result = new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");

            return result;
        }
    }
}
