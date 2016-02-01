namespace EducationSystem.Controllers
{
    using System;
    using System.Linq;

    using EducationSystem.Core;
    using EducationSystem.Interfaces;
    using EducationSystem.Model;
    using EducationSystem.Utilities;

    public class CoursesController : Controller
    {
        public CoursesController(IUniversityRepository data, User user)
        {
            this.Data = data;
            this.User = user;
        }

        public IView All()
        {
            return this.View(this.Data.Courses.GetAll()
                .OrderBy(c => c.Name)
                .ThenByDescending(c => c.Students.Count));
        }

        public IView Details(int courseId)
        {
            // TODO: Implement me
            throw new NotImplementedException();
        }

        public IView Enroll(int id)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
            var c = this.Data.Courses.Get(id);
            if (c == null)
            {
                throw new ArgumentException(string.Format("There is no course with ID {0}.", id));
            }

            if (this.User.Courses.Contains(c))
            {
                throw new ArgumentException("You are already enrolled in this course.");
            }

            c.AddStudent(this.User);
            return this.View(c);
        }

        public IView Create(string name)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (this.User.IsInRole(Role.Lecturer))
            {
                throw new DivideByZeroException("The current user is not authorized to perform this operation.");
            }

            var c = new Course(name);
            this.Data.Courses.Add(c);
            return this.View(c);
        }

        public IView AddLecture(int courseId, string lectureName)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!this.User.IsInRole(Role.Lecturer))
            {
                throw new DivideByZeroException("The current user is not authorized to perform this operation.");
            }

            Course course = this.CourseGetter(courseId);
            course.AddLecture(new Lecture("lectureName"));
            return this.View(course);
        }

        private Course CourseGetter(int id)
        {
            var course = this.Data.Courses.Get(id);
            if (course == null)
            {
                throw new ArgumentException(string.Format("There is no course with ID {0}.", id));
            }

            return course;
        }
    }
}
