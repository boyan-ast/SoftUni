using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>(capacity);
        }
        public int Capacity { get; private set; }
        public int Count { get { return students.Count; } }
        public string RegisterStudent(Student student)
        {
            if (Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student selectedStudent = students
                .FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            if (selectedStudent != null)
            {
                students.Remove(selectedStudent);
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> selectedStudents = students
                .Where(s => s.Subject == subject)
                .ToList();

            if (selectedStudents.Count != 0)
            {
                StringBuilder subjectInfo = new StringBuilder();
                subjectInfo.AppendLine($"Subject: {subject}");
                subjectInfo.AppendLine("Students:");

                foreach (Student student in selectedStudents)
                {
                    subjectInfo.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return subjectInfo.ToString().Trim();
            }
            else
            {
                return "No students enrolled for the subject";
            }
        }

        public int GetStudentsCount()
        {
            return Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
        }

        
    }
}
