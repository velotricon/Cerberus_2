using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cerberus.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cerberus.Models
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> Options) : base(Options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(builder);
        }

        public DbSet<ADDRESS> ADDRESSES { get; set; }
        public DbSet<BANK_ACCOUNT> BANK_ACCOUNTS { get; set; }
        public DbSet<EMPLOYEE> EMPLOYEES { get; set; }
        public DbSet<PERSON> PERSONS { get; set; }
        public DbSet<USER> USERS { get; set; }
        public DbSet<ROLE> ROLES { get; set; }
        public DbSet<USER_ROLE> USER_ROLES { get; set; }
        public DbSet<PERMISSION> PERMISSIONS { get; set; }
        public DbSet<ROLE_PERMISSION> ROLE_PERMISSIONS { get; set; }
        public DbSet<LOCALIZATION> LOCALIZATIONS { get; set; }
        public DbSet<TRANSLATION> TRANSLATIONS { get; set; }
        public DbSet<SYSTEM_CODE> SYSTEM_CODES { get; set; } 
    }
}
