using System;
using System.Collections.Generic;
using System.Text;

namespace TourDeOpole.Models
{
    public class Question
    {
        public int QuestionID { get; set; }
        public string Content { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string GoodAnswer { get; set; }
        public bool IsPassed { get; set; }

    }
}
