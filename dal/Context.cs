using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace dal
{
    public class Context: DbContext
    {
        public Context(){}

        public Context(string connString):base(connString){}

        public DbSet<Replacement> Replacements { get; set; }
        public DbSet<HistoryMessages> Messages { get; set; }
    }
}
