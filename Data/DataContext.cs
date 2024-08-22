using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCEcoCria.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}