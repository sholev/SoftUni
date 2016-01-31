namespace EducationSystem.Views.Courses
{
    using System.Text;

    using EducationSystem.Model;

    public class Crate : View
    {
        public Crate(Course course)
            : base(course)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendFormat("Course {0} created successfully.", course.Name).AppendLine();
        }
    }
}