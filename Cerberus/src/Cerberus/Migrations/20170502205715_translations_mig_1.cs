using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cerberus.Migrations
{
    public partial class translations_mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LOCALIZATIONS",
                columns: table => new
                {
                    LOCALE = table.Column<string>(nullable: false),
                    IS_ACTIVE = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOCALIZATIONS", x => x.LOCALE);
                });

            migrationBuilder.CreateTable(
                name: "SYSTEM_CODES",
                columns: table => new
                {
                    CODE = table.Column<string>(nullable: false),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    IS_ACTIVE = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYSTEM_CODES", x => x.CODE);
                });

            migrationBuilder.CreateTable(
                name: "TRANSLATIONS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CODE = table.Column<string>(nullable: true),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    LOCALE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSLATIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TRANSLATIONS_SYSTEM_CODES_CODE",
                        column: x => x.CODE,
                        principalTable: "SYSTEM_CODES",
                        principalColumn: "CODE",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRANSLATIONS_LOCALIZATIONS_LOCALE",
                        column: x => x.LOCALE,
                        principalTable: "LOCALIZATIONS",
                        principalColumn: "LOCALE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TRANSLATIONS_CODE",
                table: "TRANSLATIONS",
                column: "CODE");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSLATIONS_LOCALE",
                table: "TRANSLATIONS",
                column: "LOCALE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TRANSLATIONS");

            migrationBuilder.DropTable(
                name: "SYSTEM_CODES");

            migrationBuilder.DropTable(
                name: "LOCALIZATIONS");
        }
    }
}
