using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public delegate void change(int oldNumber, int newNumber);
    class Course
    {
        public event change OnNumberOfStudentChange;
        public int CourseID { get; set; }
        public string CourseTitle { get; set; }
        private Dictionary<Student, Double> StuDict = new Dictionary<Student, double>();
        public Course()
        {

        }

        public Course(int courseID, string courseTitle)
        {
            CourseID = courseID;
            CourseTitle = courseTitle;
        }
        public void AddStudent(Student p, double g)
        {
            StuDict.Add(p, g);
            OnNumberOfStudentChange?.Invoke(StuDict.Count - 1, StuDict.Count);
        }
        public void RemoveStudent(int StudentID)
        {
            foreach (KeyValuePair<Student,double> i in StuDict)
            {
                if (i.Key.StudentID==StudentID)
                {
                    StuDict.Remove(i.Key);
                    OnNumberOfStudentChange?.Invoke(StuDict.Count + 1, StuDict.Count);
                }
            }
        }
        public override string ToString()
        {
            string s = $"Course: {CourseID} - {CourseTitle}\n";
            foreach (KeyValuePair<Student,double> i in StuDict)
            {
                s += $"Student: {i.Key.StudentID} - {i.Key.StudentName} - Mark: {i.Value.ToString().Replace('.', ',')}\n";
            }
            return s;
        }
    }
}
