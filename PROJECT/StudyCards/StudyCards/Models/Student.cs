using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyCards.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentFName { get; set; }
        public string StudentLName { get; set; }
        public string StudentPhone { get; set; }
        public string StudentEmail { get; set; }
        public string StudentPass { get; set; }
    }
}