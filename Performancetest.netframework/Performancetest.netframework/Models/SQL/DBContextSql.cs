using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Performancetest.netframework.Models.SQL
{
    public class DBContextSql :DbContext
    {
        public DbSet<StudentSQL> Students { get; set; }
    }
}