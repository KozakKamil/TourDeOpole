using System;
using System.Collections.Generic;
using System.Text;

namespace TourDeOpole.Models
{
    public class HasCategory
    {
        public int HasCategoryID { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public int LocationID { get; set; }
        public Location Location { get; set; }

    }
}
