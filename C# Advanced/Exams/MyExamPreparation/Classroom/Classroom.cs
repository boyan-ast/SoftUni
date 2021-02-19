using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        private int capacity;

        public Classroom(int capacity)
        {
            this.capacity = capacity;
            students = new List<Student>(capacity);
        }

        public int Capacity { get { return capacity; } }
        public int Count { get { return students.Count; } }

        public string RegisterStudent(Student student)
        {
            if (students.Count == capacity)
            {
                return "No seats in the classroom";
            }

            students.Add(student);
            return $"Added student {student.FirstName} {student.LastName}";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = students
                .FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            if (student == null)
            {
                return "Student not found";
            }

            students.Remove(student);

            return $"Dismissed student {student.FirstName} {student.LastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> selectedStudents = students
                .Where(s => s.Subject == subject)
                .ToList();

            if (selectedStudents.Count == 0)
            {
                return "No students enrolled for the subject";
            }

            StringBuilder result = new StringBuilder();
            result.AppendLine($"Subject: {subject}");
            result.AppendLine("Students:");

            foreach (Student student in selectedStudents)
            {
                result.AppendLine($"{student.FirstName} {student.LastName}");
            }

            return result.ToString().Trim();
        }

        public int GetStudentsCount() => students.Count;

        public Student GetStudent(string firstName, string lastName) =>
            students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

    }
}
