using System;
using System.Collections.Generic;

#nullable disable

namespace PRN211_Lab1.DataAccess
{
    public partial class Country
    {
        public Country()
        {
            Students = new HashSet<Student>();
        }

        public int Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
