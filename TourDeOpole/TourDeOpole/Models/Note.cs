using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TourDeOpole.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int NoteID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int PlaceID { get; set; }

        [Ignore]
        public Place Place { get; set; }
    }
}
