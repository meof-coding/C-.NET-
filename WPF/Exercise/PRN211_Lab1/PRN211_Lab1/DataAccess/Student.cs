using System;
using System.Collections.Generic;

#nullable disable

namespace PRN211_Lab1.DataAccess
{
    public partial class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime? Dob { get; set; }
        public bool? Gender { get; set; }
        public int Code { get; set; }

        public virtual Country CodeNavigation { get; set; }
    }
}
