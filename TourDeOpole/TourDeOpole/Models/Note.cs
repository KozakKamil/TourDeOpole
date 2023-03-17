using System;
using System.Collections.Generic;
using System.Text;

namespace TourDeOpole.Models
{
    public class Note
    {
        public int NoteID { get; set; }
        public string Content { get; set; }
        public string LocationID { get; set; }
        public Places Location { get; set; }
    }
}
