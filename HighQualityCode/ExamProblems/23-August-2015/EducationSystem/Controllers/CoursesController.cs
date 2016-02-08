namespace EducationSystem.Controllers
{
    using System;
    using System.Linq;

    using EducationSystem.Core;
    using EducationSystem.Interfaces;
    using EducationSystem.Messages;
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
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
            
            var course = this.GetCourse(courseId);
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException(Errors.UserNotLoggedIn);
            }

            var isEnrolledOrLecturer = course.Students.Any(user => user.Equals(this.User));
            if (!isEnrolledOrLecturer)
            {
                throw new ArgumentException(Errors.UserNotEnrolled);
            }

            return this.View(course);
        }

        public IView Enroll(int courseId)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
            var course = this.GetCourse(courseId);

            if (this.User.Courses.Contains(course))
            {
                throw new ArgumentException(Errors.AlreadyEnrolled);
            }

            course.AddStudent(this.User);
            return this.View(course);
        }

        public IView Create(string name)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException(Errors.UserNotLoggedIn);
            }

            if (!this.User.IsInRole(Role.Lecturer))
            {
                throw new AuthorizationFailedException(Errors.UserNotAuthorized);
            }

            var course = new Course(name);
            this.Data.Courses.Add(course);
            return this.View(course);
        }

        public IView AddLecture(int courseId, string lectureName)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException(Errors.UserNotLoggedIn);
            }

            if (!this.User.IsInRole(Role.Lecturer))
            {
                throw new AuthorizationFailedException(Errors.UserNotAuthorized);
            }

            Course course = this.GetCourse(courseId);
            course.AddLecture(new Lecture(lectureName));
            return this.View(course);
        }

        private Course GetCourse(int courseId)
        {
            var course = this.Data.Courses.Get(courseId);
            if (course == null)
            {
                throw new ArgumentException(Errors.NoCourseWithId(courseId));
            }

            return course;
        }
    }
}
