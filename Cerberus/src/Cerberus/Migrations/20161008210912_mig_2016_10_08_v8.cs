using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cerberus.Migrations
{
    public partial class mig_2016_10_08_v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LOGIN",
                table: "USERS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PASSWORD",
                table: "USERS",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LOGIN",
                table: "USERS");

            migrationBuilder.DropColumn(
                name: "PASSWORD",
                table: "USERS");
        }
    }
}
