using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cerberus.Migrations
{
    public partial class mig_2016_10_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IS_ACTIVE",
                table: "USER_ROLES",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IS_ACTIVE",
                table: "ROLE_PERMISSIONS",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IS_ACTIVE",
                table: "PERMISSIONS",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IS_ACTIVE",
                table: "USER_ROLES");

            migrationBuilder.DropColumn(
                name: "IS_ACTIVE",
                table: "ROLE_PERMISSIONS");

            migrationBuilder.DropColumn(
                name: "IS_ACTIVE",
                table: "PERMISSIONS");
        }
    }
}
