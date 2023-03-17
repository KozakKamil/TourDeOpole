using System;
using System.Collections.Generic;
using System.Text;

namespace TourDeOpole.Models
{
    public class Quiz
    {
        public int QuizID { get; set; }
        public string Name { get; set;}
        public string Description { get; set;}
        public int LocationID { get; set; }
        public Places Location { get; set; }
        public bool IsDone { get; set; }
        public bool IsStarted { get; set; }
    }
}
