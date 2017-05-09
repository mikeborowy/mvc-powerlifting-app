using PowerLiftingApp_2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PowerLiftingApp_2.Context
{
    public class PowerliftingDbContext : DbContext
    {
        public DbSet<Contender> Contenders { get; set; }

    }
}