using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PojistovnaWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class PojistovnaWebApp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CeleJmeno",
                table: "PojisteneOsoby",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "SjednanaPojisteni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazev = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PojistnaCastka = table.Column<int>(type: "int", nullable: false),
                    ZacatekPojisteni = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KonecPojisteni = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PojisteneOsobyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SjednanaPojisteni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SjednanaPojisteni_PojisteneOsoby_PojisteneOsobyId",
                        column: x => x.PojisteneOsobyId,
                        principalTable: "PojisteneOsoby",
                        principalColumn: "IdOsoby",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PojistnaUdalost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Popis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumUdalosti = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Plneni = table.Column<int>(type: "int", nullable: false),
                    PojisteneOsobyId = table.Column<int>(type: "int", nullable: false),
                    SjednanaPojisteniId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PojistnaUdalost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PojistnaUdalost_PojisteneOsoby_PojisteneOsobyId",
                        column: x => x.PojisteneOsobyId,
                        principalTable: "PojisteneOsoby",
                        principalColumn: "IdOsoby",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PojistnaUdalost_SjednanaPojisteni_SjednanaPojisteniId",
                        column: x => x.SjednanaPojisteniId,
                        principalTable: "SjednanaPojisteni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PojistnaUdalost_PojisteneOsobyId",
                table: "PojistnaUdalost",
                column: "PojisteneOsobyId");

            migrationBuilder.CreateIndex(
                name: "IX_PojistnaUdalost_SjednanaPojisteniId",
                table: "PojistnaUdalost",
                column: "SjednanaPojisteniId");

            migrationBuilder.CreateIndex(
                name: "IX_SjednanaPojisteni_PojisteneOsobyId",
                table: "SjednanaPojisteni",
                column: "PojisteneOsobyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PojistnaUdalost");

            migrationBuilder.DropTable(
                name: "SjednanaPojisteni");

            migrationBuilder.DropColumn(
                name: "CeleJmeno",
                table: "PojisteneOsoby");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
