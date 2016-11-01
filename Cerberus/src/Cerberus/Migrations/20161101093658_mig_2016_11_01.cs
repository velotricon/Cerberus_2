using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cerberus.Migrations
{
    public partial class mig_2016_11_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USERS_ROLES_ROLE_ID",
                table: "USERS");

            migrationBuilder.DropIndex(
                name: "IX_USERS_ROLE_ID",
                table: "USERS");

            migrationBuilder.DropColumn(
                name: "ROLE_ID",
                table: "USERS");

            migrationBuilder.CreateTable(
                name: "USER_ROLES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ROLE_ID = table.Column<int>(nullable: false),
                    USER_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_ROLES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USER_ROLES_ROLES_ROLE_ID",
                        column: x => x.ROLE_ID,
                        principalTable: "ROLES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USER_ROLES_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATE_DATE",
                table: "USERS",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_USER_ROLES_ROLE_ID",
                table: "USER_ROLES",
                column: "ROLE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_ROLES_USER_ID",
                table: "USER_ROLES",
                column: "USER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CREATE_DATE",
                table: "USERS");

            migrationBuilder.DropTable(
                name: "USER_ROLES");

            migrationBuilder.AddColumn<int>(
                name: "ROLE_ID",
                table: "USERS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_USERS_ROLE_ID",
                table: "USERS",
                column: "ROLE_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_USERS_ROLES_ROLE_ID",
                table: "USERS",
                column: "ROLE_ID",
                principalTable: "ROLES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
