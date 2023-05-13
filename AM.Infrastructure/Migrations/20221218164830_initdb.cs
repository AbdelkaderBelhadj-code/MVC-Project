using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invite",
                columns: table => new
                {
                    IdInvite = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdresseInvite = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invite", x => x.IdInvite);
                });

            migrationBuilder.CreateTable(
                name: "Salle",
                columns: table => new
                {
                    IdSalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomSalle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AdresseSalle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Capacite = table.Column<int>(type: "int", nullable: false),
                    PrixParHeure = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salle", x => x.IdSalle);
                });

            migrationBuilder.CreateTable(
                name: "Fete",
                columns: table => new
                {
                    IdFete = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    NbInviteMax = table.Column<int>(type: "int", nullable: false),
                    Duree = table.Column<int>(type: "int", nullable: false),
                    DateFete = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fete", x => x.IdFete);
                    table.ForeignKey(
                        name: "FK_Fete_Salle_SalleId",
                        column: x => x.SalleId,
                        principalTable: "Salle",
                        principalColumn: "IdSalle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invitation",
                columns: table => new
                {
                    DateInvitation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InviteFk = table.Column<int>(type: "int", nullable: false),
                    FeteFk = table.Column<int>(type: "int", nullable: false),
                    ConfirmeInvitation = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitation", x => new { x.FeteFk, x.InviteFk, x.DateInvitation });
                    table.ForeignKey(
                        name: "FK_Invitation_Fete_FeteFk",
                        column: x => x.FeteFk,
                        principalTable: "Fete",
                        principalColumn: "IdFete",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invitation_Invite_InviteFk",
                        column: x => x.InviteFk,
                        principalTable: "Invite",
                        principalColumn: "IdInvite",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fete_SalleId",
                table: "Fete",
                column: "SalleId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitation_InviteFk",
                table: "Invitation",
                column: "InviteFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invitation");

            migrationBuilder.DropTable(
                name: "Fete");

            migrationBuilder.DropTable(
                name: "Invite");

            migrationBuilder.DropTable(
                name: "Salle");
        }
    }
}
