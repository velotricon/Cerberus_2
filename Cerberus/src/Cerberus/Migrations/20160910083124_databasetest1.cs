using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cerberus.Migrations
{
    public partial class databasetest1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SURNAME",
                table: "PERSONS");

            migrationBuilder.AddColumn<string>(
                name: "SURNAME2",
                table: "PERSONS",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SURNAME2",
                table: "PERSONS");

            migrationBuilder.AddColumn<string>(
                name: "SURNAME",
                table: "PERSONS",
                nullable: true);
        }
    }
}
