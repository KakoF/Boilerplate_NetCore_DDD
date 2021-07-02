using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 45, nullable: false),
                    Initials = table.Column<string>(maxLength: 2, nullable: false),
                    Iso = table.Column<string>(maxLength: 100, nullable: false),
                    Slug = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Password = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Counties",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Iso = table.Column<string>(maxLength: 100, nullable: false),
                    Slug = table.Column<string>(maxLength: 100, nullable: false),
                    Lat = table.Column<double>(nullable: false),
                    Long = table.Column<double>(nullable: false),
                    StateId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Counties_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    ZipCode = table.Column<string>(maxLength: 8, nullable: false),
                    Address = table.Column<string>(maxLength: 250, nullable: false),
                    District = table.Column<string>(maxLength: 150, nullable: false),
                    Number = table.Column<string>(maxLength: 10, nullable: false),
                    CountyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adresses_Counties_CountyId",
                        column: x => x.CountyId,
                        principalTable: "Counties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "Password", "UpdateAt" },
                values: new object[] { new Guid("4cd25a92-cad0-4f87-abf5-345813e9efeb"), new DateTime(2021, 7, 2, 13, 50, 8, 397, DateTimeKind.Local).AddTicks(3473), "kakoferrare87@gmail.com", "Kako", "kako123456", new DateTime(2021, 7, 2, 13, 50, 8, 398, DateTimeKind.Local).AddTicks(5471) });

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_CountyId",
                table: "Adresses",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_Counties_StateId",
                table: "Counties",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Counties");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
