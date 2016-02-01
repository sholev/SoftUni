namespace EducationSystem.Views.Courses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using EducationSystem.Model;

    public class All : View
    {
        public All(IEnumerable<Course> courses)
            : base(courses)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var courses = this.Model as IEnumerable<Course>;

            if (!courses.Any())
            {
                viewResult.Append("No courses.");
            }
            else
            {
                viewResult.AppendLine("All courses:");
                var outputCoursees = courses.Select(
                    course => $"{course.Name} ({course.Students.Count} students)");
                viewResult.Append(string.Join(Environment.NewLine, outputCoursees));
            }
        }
    }
}