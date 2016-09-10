using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Cerberus.Models;

namespace Cerberus.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20160910083124_databasetest1")]
    partial class databasetest1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cerberus.Models.PERSON", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IS_ACTIVE");

                    b.Property<string>("NAME");

                    b.Property<string>("SURNAME2");

                    b.HasKey("ID");

                    b.ToTable("PERSONS");
                });
        }
    }
}
