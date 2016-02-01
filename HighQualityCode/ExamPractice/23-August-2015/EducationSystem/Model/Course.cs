namespace EducationSystem.Model
{
    using System;
    using System.Collections.Generic;

    using EducationSystem.Core;
    using EducationSystem.Views;

    public class Course
    {
        private string name;

        public Course(string name)
        {
            this.Name = name;
            this.Lectures = new List<Lecture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(Messages.GetLengthMessage("course name", 5));
                }

                this.name = value;
            }
        }

        public IList<Lecture> Lectures { get; }

        public IList<User> Students { get; set; }

        public void AddLecture(Lecture lecture)
        {
            this.Lectures.Add(lecture);
        }

        public void AddStudent(User student)
        {
            this.Students.Add(student);
            student.Courses.Add(this);
        }
    }
}