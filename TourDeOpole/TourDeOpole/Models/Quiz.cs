using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TourDeOpole.Models
{
    public class Quiz
    {
        [PrimaryKey, AutoIncrement]
        public int QuizID { get; set; }

        public string Name { get; set;}

        public string Description { get; set;}

        public int LocationID { get; set; }
        [Ignore]
        public Place Location { get; set; }

        public bool IsDone { get; set; }

        public bool IsStarted { get; set; }
    }
}
