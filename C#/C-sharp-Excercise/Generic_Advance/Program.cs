using System;
using System.Collections.Generic;

namespace Generic_Advance
{
    public class Student
    {
        //Public properties
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        //Constructor
        public Student(int student_id, string student_name)
        {
            this.StudentID = student_id;
            this.StudentName = student_name;
        }

        
    }

    public class Course
    {
        public delegate void StudentChangeHandler(int old_num, int new_num);
        //Even declaration
        public event StudentChangeHandler OnNumberOfStudentChange;
        //Public props
        public int CourseID { get; set; }
        public string CourseTittle { get; set; }
        private Dictionary<Student, double> my_dictionary=new Dictionary<Student, double>();

        public Course(int course_id, string course_tittle)
        {
            this.CourseID = course_id;
            this.CourseTittle = course_tittle;
        }

       public void AddStudent(Student p, double g)
        {
            var a = my_dictionary.Count;
            my_dictionary.Add(p, g);
            OnNumberOfStudentChange?.Invoke(a,my_dictionary.Count);
        }

        public void RemoveStudent(int StudentiD)
        {
            var a = my_dictionary.Count;
            foreach (var item in my_dictionary)
            {
                if(item.Key.StudentID == StudentiD)
                {
                    my_dictionary.Remove(item.Key);
                }
            }
            OnNumberOfStudentChange?.Invoke(a, my_dictionary.Count);
        }

        public override string ToString()
        {
            string a = "\n";
            foreach (var item in my_dictionary)
            {

                a += $"Student: {item.Key.StudentID} - {item.Key.StudentName} - Mark: {item.Value.ToString().Replace('.',',')}\n";
            }
            return $"Course: {CourseID} - {CourseTittle}" + a;
        }
       
    }
    class Program
    {
        private static void Notify(int old_num, int new_num)
        {
            Console.WriteLine($"Number of student has changed from {old_num} to {new_num}");
        }
        static void Main(string[] args)
        {
            Student s = new Student(1, "Trung");
            Course c = new Course(1, "PRN211_Sum21");
            c.AddStudent(s, 7.5);
            c.AddStudent(new Student(2, "Hoa"), 7.8);
            c.AddStudent(new Student(3, "Vinh"), 7.4);
            Console.WriteLine(c);
            c.RemoveStudent(2);
            Console.WriteLine("\n----------After remove:");
            Console.WriteLine(c);

            Console.WriteLine("\n--------After add event handler:");
            c.OnNumberOfStudentChange += Notify;
            c.AddStudent(new Student(4, "Hoang Anh"), 8);
            c.RemoveStudent(1);
            Console.WriteLine(c);
            Console.ReadLine();
        }
    }
}
