using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TourDeOpole.Models
{
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int CategoryID { get; set; }
        public string Name { get; set; }
    }
}
