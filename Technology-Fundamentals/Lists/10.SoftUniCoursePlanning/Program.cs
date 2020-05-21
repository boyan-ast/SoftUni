using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> courses = Console.ReadLine().Split(", ").ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "course start")
            {
                string[] tokens = command.Split(":");
                string action = tokens[0];

                if (action == "Add" || action == "Insert" || action == "Remove")
                {
                    SimpleOperations(courses, tokens);
                }
                else if (action == "Exercise")
                {
                    AddExerciseToLesson(courses, tokens[1]);
                }
                else if (action == "Swap")
                {
                    SwapLessonsAndTheirExercises(courses, tokens[1], tokens[2]);
                }

            }

            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{courses[i]}");
            }
        }

        private static void SwapLessonsAndTheirExercises(List<string> courses, string firstLessonTitle, string secondLessonTitle)
        {
            string firstExerciseTitle = firstLessonTitle + "-Exercise";
            string secondExerciseTitle = secondLessonTitle + "-Exercise";

            bool bothLessonsExist = CheckIfLessonExists(courses, firstLessonTitle) && CheckIfLessonExists(courses, secondLessonTitle);

            if (!bothLessonsExist)
            {
                return;
            }

            int firstLessonIndex = courses.IndexOf(firstLessonTitle);
            int secondLessonIndex = courses.IndexOf(secondLessonTitle);

            bool firstExerciseExists = CheckIfLessonExists(courses, firstExerciseTitle);
            bool secondExerciseExists = CheckIfLessonExists(courses, secondExerciseTitle);

            courses[firstLessonIndex] = secondLessonTitle;
            courses[secondLessonIndex] = firstLessonTitle;

            if (firstExerciseExists && secondExerciseExists)
            {
                courses[firstLessonIndex + 1] = secondExerciseTitle;
                courses[secondLessonIndex + 1] = firstExerciseTitle;
            }
            else if (firstExerciseExists && !secondExerciseExists)
            {
                courses.Remove(firstExerciseTitle);
                courses.Insert(secondLessonIndex + 1, firstExerciseTitle);
            }
            else if (secondExerciseExists && !firstExerciseExists)
            {
                courses.Remove(secondExerciseTitle);
                courses.Insert(firstLessonIndex + 1, secondExerciseTitle);
            }
        }

        private static void AddExerciseToLesson(List<string> courses, string lessonTitle)
        {
            string exerciseTitle = lessonTitle + "-Exercise";
            bool exerciseExists = courses.Contains(exerciseTitle);
            bool lessonExists = CheckIfLessonExists(courses, lessonTitle);

            if (lessonExists && exerciseExists)
            {
                return;
            }

            if (lessonExists && !exerciseExists)
            {
                int lessonIndex = courses.IndexOf(lessonTitle);
                courses.Insert(lessonIndex + 1, exerciseTitle);
            }
            else if (!lessonExists && !exerciseExists)
            {
                courses.Add(lessonTitle);
                courses.Add(exerciseTitle);
            }

        }

        private static void SimpleOperations(List<string> courses, string[] tokens)
        {
            string lessonTitle = tokens[1];
            bool exists = CheckIfLessonExists(courses, lessonTitle);

            if (tokens[0] == "Add")
            {
                if (!exists)
                {
                    courses.Add(lessonTitle);
                }
            }
            else if (tokens[0] == "Insert")
            {
                if (!exists)
                {
                    int index = int.Parse(tokens[2]);

                    if (index >= 0 && index < courses.Count)
                    {
                        courses.Insert(index, lessonTitle);
                    }                   
                }
            }
            else
            {
                if (exists)
                {
                    int lessonIndex = courses.IndexOf(lessonTitle);
                    string exerciseTitle = lessonTitle + "-Exercise";
                    courses.Remove(lessonTitle);

                    if (courses.Contains(exerciseTitle))
                    {
                        courses.Remove(exerciseTitle);
                    }
                }
            }
        }

        private static bool CheckIfLessonExists(List<string> courses, string lessonTitle)
        {
            return courses.Contains(lessonTitle);
        }
    }
}
