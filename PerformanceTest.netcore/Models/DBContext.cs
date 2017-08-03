using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Data.SqlClient;

namespace PerformanceTest.netcore.Models{
    public class DBContext :DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
      :base(options)
    { }

        public DbSet<StudentSQL> Students { get; set; }
    }
}