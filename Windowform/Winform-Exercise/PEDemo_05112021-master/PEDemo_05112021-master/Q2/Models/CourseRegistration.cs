using System;
using System.Collections.Generic;

#nullable disable

namespace Q2.Models
{
    public partial class CourseRegistration
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public bool Sex { get; set; }
        public string Subject { get; set; }
        public string Time { get; set; }
        public string Note { get; set; }
    }
}
