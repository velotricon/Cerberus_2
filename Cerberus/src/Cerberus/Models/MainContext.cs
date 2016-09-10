using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cerberus.Models;

namespace Cerberus.Models
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> Options) : base(Options) { }

        public DbSet<PERSON> PERSONS { get; set; }
    }
}
