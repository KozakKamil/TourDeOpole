using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TourDeOpole.Services
{
    public class DatabaseService
    {
        [PrimaryKey, AutoIncrement]
        public int IdTest { get; set; }
        public string NameTest { get; set; }

    }
}
