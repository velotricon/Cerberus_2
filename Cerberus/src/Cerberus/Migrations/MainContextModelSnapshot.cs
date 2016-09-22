﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Cerberus.Models;

namespace Cerberus.Migrations
{
    [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cerberus.Models.ADDRESS", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CITY");

                    b.Property<string>("COUNTRY_CODE");

                    b.Property<string>("HOUSE_NUMBER");

                    b.Property<bool>("IS_ACTIVE");

                    b.Property<string>("STREET");

                    b.Property<string>("ZIP_CODE");

                    b.HasKey("ID");

                    b.ToTable("ADDRESSES");
                });

            modelBuilder.Entity("Cerberus.Models.BANK_ACCOUNT", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ACCOUNT_NUMBER");

                    b.Property<int>("ADDRESS_ID");

                    b.Property<string>("BANK_NAME");

                    b.Property<string>("IBAN");

                    b.Property<bool>("IS_ACTIVE");

                    b.Property<string>("SWIFT_CODE");

                    b.HasKey("ID");

                    b.HasIndex("ADDRESS_ID");

                    b.ToTable("BANK_ACCOUNTS");
                });

            modelBuilder.Entity("Cerberus.Models.EMPLOYEE", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ADDRESS_ID");

                    b.Property<int>("BANK_ACCOUNT_ID");

                    b.Property<bool>("IS_ACTIVE");

                    b.Property<int>("PERSON_ID");

                    b.Property<int>("ROLE_ID");

                    b.HasKey("ID");

                    b.HasIndex("ADDRESS_ID");

                    b.HasIndex("BANK_ACCOUNT_ID");

                    b.HasIndex("PERSON_ID");

                    b.HasIndex("ROLE_ID");

                    b.ToTable("EMPLOYEES");
                });

            modelBuilder.Entity("Cerberus.Models.PERSON", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IS_ACTIVE");

                    b.Property<string>("NAME");

                    b.Property<string>("SURNAME");

                    b.HasKey("ID");

                    b.ToTable("PERSONS");
                });

            modelBuilder.Entity("Cerberus.Models.ROLE", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IS_ACTIVE");

                    b.Property<string>("ROLE_NAME");

                    b.HasKey("ID");

                    b.ToTable("ROLES");
                });

            modelBuilder.Entity("Cerberus.Models.BANK_ACCOUNT", b =>
                {
                    b.HasOne("Cerberus.Models.ADDRESS", "ADDRESS")
                        .WithMany()
                        .HasForeignKey("ADDRESS_ID");
                });

            modelBuilder.Entity("Cerberus.Models.EMPLOYEE", b =>
                {
                    b.HasOne("Cerberus.Models.ADDRESS", "ADDRESS")
                        .WithMany()
                        .HasForeignKey("ADDRESS_ID");

                    b.HasOne("Cerberus.Models.BANK_ACCOUNT", "BANK_ACCOUNT")
                        .WithMany()
                        .HasForeignKey("BANK_ACCOUNT_ID");

                    b.HasOne("Cerberus.Models.PERSON", "PERSON")
                        .WithMany()
                        .HasForeignKey("PERSON_ID");

                    b.HasOne("Cerberus.Models.ROLE", "ROLE")
                        .WithMany()
                        .HasForeignKey("ROLE_ID");
                });
        }
    }
}
