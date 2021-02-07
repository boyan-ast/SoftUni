namespace ClassroomProject
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            Classroom classroom = new Classroom(3);

            Student studentOne = new Student("Alex", "Petkov", "Geometry");
            Student studentTwo = new Student("Milen", "Gamakov", "Algebra");
            Student studentThree = new Student("Francis", "Narh", "Algebra");
            Student studentFour = new Student("Babatunde", "Adeniji", "Music");

            Console.WriteLine(studentOne);

            string register = classroom.RegisterStudent(studentOne);
            Console.WriteLine(register);
            string registerTwo = classroom.RegisterStudent(studentTwo);
            string registerThree = classroom.RegisterStudent(studentThree);
            Console.WriteLine(classroom.RegisterStudent(studentFour));

            string dismissed = classroom.DismissStudent("Alex", "Petkov");
            Console.WriteLine(dismissed);

            string dismissedTwo = classroom.DismissStudent("Mama", "Jabi");
            Console.WriteLine(dismissedTwo);

            string subjectInfo = classroom.GetSubjectInfo("Algebra");
            Console.WriteLine(subjectInfo);

            string anotherInfo = classroom.GetSubjectInfo("Art");
            Console.WriteLine(anotherInfo);

            Console.WriteLine(classroom.GetStudent("Babatunde", "Adeniji"));
        }
    }
}