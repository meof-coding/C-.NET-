using System;
using System.Collections.Generic;

#nullable disable

namespace Q2.Models
{
    public partial class TestResult
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string Subject { get; set; }
        public string TestType { get; set; }
        public DateTime Date { get; set; }
        public double? Mark { get; set; }
    }
}
