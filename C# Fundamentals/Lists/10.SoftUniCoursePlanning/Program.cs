using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> coursesString = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<Course> courses = new List<Course>();

            for (int i = 0; i < coursesString.Count; i++)
            {
                string courseName = coursesString[i];

                bool hasExercise = false;

                if ((i != coursesString.Count - 1) && coursesString[i + 1].Contains(courseName + "-Exercise"))
                {
                    hasExercise = true;
                    coursesString.Remove(courseName + "-Exercise");
                }

                Course course = new Course(courseName, hasExercise);
                courses.Add(course);
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "course start")
            {
                string[] actions = command.Split(':');

                ModifyTheSchedule(courses, actions);
            }

            int counter = 1;

            foreach (Course course in courses)
            {
                Console.WriteLine($"{counter}.{course.Name}");
                counter++;

                if (course.HasExercise)
                {
                    Console.WriteLine($"{counter}.{course.Name}-Exercise");
                    counter++;
                }
            }
        }

        private static void ModifyTheSchedule(List<Course> courses, string[] tokens)
        {
            string action = tokens[0];
            string title = tokens[1];

            if (action == "Add")
            {
                if (!courseExists(courses, title))
                {
                    Course newCourse = new Course(title, false);
                    courses.Add(newCourse);
                }
            }
            else if (action == "Insert")
            {
                int index = int.Parse(tokens[2]);

                if (!courseExists(courses, title))
                {
                    Course newCourse = new Course(title, false);
                    courses.Insert(index, newCourse);
                }
            }
            else if (action == "Remove")
            {
                if (courseExists(courses, title))
                {
                    Course existingCourse = courses.FirstOrDefault(x => x.Name == title);
                    courses.Remove(existingCourse);
                }
            }
            else if (action == "Swap")
            {
                string firstTitle = tokens[1];
                string secondTitle = tokens[2];

                if (courseExists(courses, firstTitle) && courseExists(courses, secondTitle))
                {
                    int indexOfFirstCourse = courses.FindIndex(x => x.Name == firstTitle);
                    int indexOfSecondCourse = courses.FindIndex(x => x.Name == secondTitle);

                    Course temp = courses[indexOfFirstCourse];
                    courses[indexOfFirstCourse] = courses[indexOfSecondCourse];
                    courses[indexOfSecondCourse] = temp;
                }
            }
            else if (action == "Exercise")
            {
                if (courseExists(courses, title))
                {
                    Course existingCourse = courses.FirstOrDefault(x => x.Name == title);

                    if (!existingCourse.HasExercise)
                    {
                        existingCourse.HasExercise = true;
                    }
                }
                else
                {
                    Course newCourse = new Course(title, true);
                    courses.Add(newCourse);
                }
            }

        }

        private static bool courseExists(List<Course> courses, string name)
        {
            int index = courses.FindIndex(x => x.Name == name);

            if (index >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }


    public class Course
    {
        private string name;
        private bool hasExercise;

        public Course()
        {

        }

        public Course(string name, bool hasExercise)
        {
            this.Name = name;
            this.HasExercise = hasExercise;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public bool HasExercise
        {
            get { return hasExercise; }
            set { hasExercise = value; }
        }

    }


}
