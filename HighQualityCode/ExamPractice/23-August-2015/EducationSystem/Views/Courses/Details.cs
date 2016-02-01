namespace EducationSystem.Views.Courses
{
    using System;
    using System.Linq;
    using System.Text;

    using EducationSystem.Model;

    public class Details : View
    {
        public Details(Course course)
            : base(course)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendLine(course.Name);
            if (!course.Lectures.Any())
            {
                viewResult.Append("No lectures");
            }
            else
            {
                var lectureNames = course.Lectures.Select(lecture => "- " + lecture.Name);
                viewResult.Append(string.Join(Environment.NewLine, lectureNames));
            }
        }
    }
}