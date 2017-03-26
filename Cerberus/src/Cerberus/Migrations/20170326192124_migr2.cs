using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cerberus.Migrations
{
    public partial class migr2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FILE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CONTENT_TYPE = table.Column<string>(nullable: true),
                    FULL_NAME = table.Column<string>(nullable: true),
                    IS_ACTIVE = table.Column<bool>(nullable: false),
                    NAME = table.Column<string>(nullable: true),
                    PATH = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FILE", x => x.ID);
                });

            migrationBuilder.AddColumn<int>(
                name: "AVATAR_ID",
                table: "USERS",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_USERS_AVATAR_ID",
                table: "USERS",
                column: "AVATAR_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_USERS_FILE_AVATAR_ID",
                table: "USERS",
                column: "AVATAR_ID",
                principalTable: "FILE",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USERS_FILE_AVATAR_ID",
                table: "USERS");

            migrationBuilder.DropIndex(
                name: "IX_USERS_AVATAR_ID",
                table: "USERS");

            migrationBuilder.DropColumn(
                name: "AVATAR_ID",
                table: "USERS");

            migrationBuilder.DropTable(
                name: "FILE");
        }
    }
}
