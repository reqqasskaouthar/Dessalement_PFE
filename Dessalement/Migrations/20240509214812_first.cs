using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dessalement.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usagers",
                columns: table => new
                {
                    typeusage = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codeusage = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nationalite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    datenaissance = table.Column<DateTime>(type: "datetime2", nullable: true),
                    lieunaissance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fixe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    portable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    propriétaire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    superficiesouscrite = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usagers", x => new { x.typeusage, x.codeusage });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usagers");
        }
    }
}
