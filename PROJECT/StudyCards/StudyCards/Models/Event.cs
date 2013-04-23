using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StudyCards.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string EventTitle { get; set; }
        public DateTime EventTime { get; set; }
        public string EventDesc { get; set; }
        public string EventLocation { get; set; }
        public int CourseID { get; set; }
    }

    public class EventDBContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

    }
}