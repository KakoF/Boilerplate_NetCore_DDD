using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Iso = table.Column<string>(maxLength: 100, nullable: false),
                    Slug = table.Column<string>(maxLength: 100, nullable: false),
                    Lat = table.Column<double>(nullable: false),
                    Long = table.Column<double>(nullable: false),
                    StateId = table.Column<Guid>(nullable: false),
                    StateId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId1",
                        column: x => x.StateId1,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    ZipCode = table.Column<string>(maxLength: 8, nullable: false),
                    Address = table.Column<string>(maxLength: 250, nullable: false),
                    District = table.Column<string>(maxLength: 150, nullable: false),
                    Number = table.Column<string>(maxLength: 10, nullable: false),
                    CityId = table.Column<Guid>(nullable: false),
                    CountyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adresses_Cities_CountyId",
                        column: x => x.CountyId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CreateAt", "Initials", "Iso", "Name", "Slug", "UpdateAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7315), "AC", "12", "Acre", "acre", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7365) },
                    { 26, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7485), "SP", "35", "São Paulo", "sao-paulo", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7486) },
                    { 25, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7482), "SE", "28", "Sergipe", "sergipe", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7483) },
                    { 24, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7480), "SC", "42", "Santa Catarina", "santa-catarina", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7481) },
                    { 23, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7477), "RS", "43", "Rio Grande do Sul", "rio-grande-do-sul", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7478) },
                    { 22, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7474), "RR", "14", "Roraima", "roraima", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7475) },
                    { 21, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7472), "RO", "11", "Rondônia", "rondonia", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7473) },
                    { 20, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7469), "RN", "24", "Rio Grande do Norte", "rio-grande-do-norte", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7470) },
                    { 19, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7466), "RJ", "33", "Rio de Janeiro", "rio-de-janeiro", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7468) },
                    { 18, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7464), "PR", "41", "Paraná", "parana", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7465) },
                    { 17, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7462), "PI", "22", "Piauí", "piaui", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7463) },
                    { 16, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7459), "PE", "26", "Pernambuco", "pernambuco", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7460) },
                    { 15, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7456), "PB", "25", "Paraiba", "paraiba", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7457) },
                    { 14, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7454), "PA", "15", "Pará", "para", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7454) },
                    { 13, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7451), "MT", "51", "Mato Grosso", "mato-grosso", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7452) },
                    { 12, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7448), "MS", "50", "Mato Grosso do Sul", "mato-grosso-do-sul", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7449) },
                    { 11, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7446), "MG", "31", "Minas Gerais", "minas-gerais", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7447) },
                    { 10, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7444), "MA", "21", "Maranhão", "maranhao", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7445) },
                    { 9, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7438), "GO", "52", "Goiás", "goias", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7439) },
                    { 8, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7434), "ES", "32", "Espírito Santo", "espirito-santo", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7435) },
                    { 7, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7431), "DF", "53", "Distrito Federal", "distrito-federal", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7432) },
                    { 6, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7429), "CE", "23", "Ceará", "ceara", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7430) },
                    { 5, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7427), "BA", "29", "Bahia", "bahia", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7428) },
                    { 4, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7424), "AP", "16", "Amapá", "amapa", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7426) },
                    { 3, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7421), "AM", "13", "Amazonas", "amazonas", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7422) },
                    { 2, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7418), "AL", "27", "Alagoas", "alagoas", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7419) },
                    { 27, new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7488), "TO", "17", "Tocantins", "tocantins", new DateTime(2021, 7, 2, 15, 28, 59, 399, DateTimeKind.Local).AddTicks(7489) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "Password", "UpdateAt" },
                values: new object[] { 100, new DateTime(2021, 7, 2, 15, 28, 59, 396, DateTimeKind.Local).AddTicks(9063), "kakoferrare87@gmail.com", "Kako", "kako123456", new DateTime(2021, 7, 2, 15, 28, 59, 398, DateTimeKind.Local).AddTicks(557) });

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_CountyId",
                table: "Adresses",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId1",
                table: "Cities",
                column: "StateId1");

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
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
