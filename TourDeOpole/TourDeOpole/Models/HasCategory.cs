using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TourDeOpole.Models
{
    public class HasCategory
    {
        [PrimaryKey, AutoIncrement]
        public int HasCategoryID { get; set; }

        public int CategoryID { get; set; }
        [Ignore]
        public Category Category { get; set; }

        public int PlaceID { get; set; }
        [Ignore]
        public Place Place { get; set; }

    }
}
