using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blood.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Pesel = table.Column<string>(nullable: false),
                    BloodGroup = table.Column<int>(nullable: false),
                    BloodType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Pesel);
                });

            migrationBuilder.CreateTable(
                name: "EventBlood",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PersonPesel = table.Column<string>(nullable: true),
                    DonatedBlood = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventBlood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventBlood_Person_PersonPesel",
                        column: x => x.PersonPesel,
                        principalTable: "Person",
                        principalColumn: "Pesel",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventBlood_PersonPesel",
                table: "EventBlood",
                column: "PersonPesel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventBlood");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
