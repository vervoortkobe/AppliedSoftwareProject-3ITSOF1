using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AP.MyGameStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Person");

            migrationBuilder.EnsureSchema(
                name: "Store");

            migrationBuilder.CreateTable(
                name: "tblStores",
                schema: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    Addition = table.Column<string>(type: "nvarchar(2)", nullable: false),
                    Zipcode = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    IsFranchiseStore = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblPeople",
                schema: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    EmployerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPeople", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblPeople_tblStores_EmployerId",
                        column: x => x.EmployerId,
                        principalSchema: "Store",
                        principalTable: "tblStores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Store",
                table: "tblStores",
                columns: new[] { "Id", "Addition", "Place", "IsFranchiseStore", "Name", "Number", "Street", "Zipcode" },
                values: new object[,]
                {
                    { 1, "", "Kortrijk", false, "MyGameStore Kortrijk", "260", "Korte Steenstraat", "8500" },
                    { 2, "", "Ninove", true, "MyGameStore Ninove", "95", "Centrumlaan", "9400" },
                    { 3, "", "Roeselare", false, "MyGameStore Roeselare", "97", "Ooststraat", "8800" },
                    { 4, "", "Zaventem", false, "MyGameStore Zaventem", "173", "Weiveldlaan", "1930" },
                    { 5, "", "Hasselt", false, "MyGameStore Hasselt", "254", "Demerstraat", "3500" },
                    { 6, "", "Gent", true, "MyGameStore Gent", "128", "Veldstraat", "9000" },
                    { 7, "", "Knokke-Heist", false, "MyGameStore Knokke-Heist", "215", "Lippenslaan", "8300" },
                    { 8, "", "Maaseik", false, "MyGameStore Maaseik", "239", "Bosstraat", "3680" },
                    { 9, "", "Beringen", false, "MyGameStore Beringen", "85", "Koolmijnlaan", "3580" },
                    { 10, "", "Geraardsbergen", false, "MyGameStore Geraardsbergen", "149", "Winkelstraat", "9500" },
                    { 11, "", "Asse", false, "MyGameStore Asse", "260", "Stationsstraat", "1730" },
                    { 12, "", "Geel", false, "MyGameStore Geel", "59", "Nieuwstraat", "2440" },
                    { 13, "", "Antwerpen", true, "MyGameStore Antwerpen", "76", "Meir", "2000" },
                    { 14, "", "Mol", false, "MyGameStore Mol", "179", "Statiestraat", "2400" },
                    { 15, "", "Sint-Gillis", false, "MyGameStore Sint-Gillis", "286", "Fonsnylaan", "1060" },
                    { 16, "4", "Ieper", false, "MyGameStore Ieper", "189", "Boterstraat", "8900" },
                    { 17, "", "Aalst", false, "MyGameStore Aalst", "64", "Nieuwstraat", "3800" },
                    { 18, "B", "Mechelen", false, "MyGameStore Mechelen", "106", "Bruul", "2800" },
                    { 19, "", "Jette", false, "MyGameStore Jette", "78", "Léon Theodorstraat", "1090" },
                    { 20, "", "Schaarbeek", true, "MyGameStore Schaarbeek", "18", "Helmetsesteenweg", "1030" },
                    { 21, "", "Dendermonde", false, "MyGameStore Dendermonde", "206", "Oude Vest", "9200" },
                    { 22, "", "Sint-Niklaas", false, "MyGameStore Sint-Niklaas", "299", "Stationsstraat", "9100" },
                    { 23, "A", "Turnhout", false, "MyGameStore Turnhout", "40", "Gasthuisstraat", "2300" },
                    { 24, "", "Brecht", false, "MyGameStore Brecht", "18", "Heiken", "2960" },
                    { 25, "", "Sint-Jans-Molenbeek", false, "MyGameStore Sint-Jans-Molenbeek", "191", "Schoolstraat", "1080" },
                    { 26, "", "Brasschaat", false, "MyGameStore Brasschaat", "26", "Bredabaan", "2930" },
                    { 27, "2", "Halle", true, "MyGameStore Halle", "187", "Basiliekstraat", "1500" },
                    { 28, "", "Stokkem", false, "MyGameStore Dilsen-Stokkem", "236", "Rijksweg", "3650" },
                    { 29, "", "Schoten", false, "MyGameStore Schoten", "77", "Paalstraat", "2900" },
                    { 30, "H", "Genk", false, "MyGameStore Genk", "141", "Molenstraat", "3600" },
                    { 31, "", "Harelbeke", false, "MyGameStore Harelbeke", "184", "Tramstraat", "8530" },
                    { 32, "", "Wevelgem", false, "MyGameStore Wevelgem", "192", "Menenstraat", "8560" },
                    { 33, "", "Elsene", true, "MyGameStore Elsene", "135", "Elsensesteenweg", "1050" },
                    { 34, "", "Vilvoorde", false, "MyGameStore Vilvoorde", "68", "Leuvensestraat", "1800" },
                    { 35, "", "Leuven", false, "MyGameStore Leuven", "83", "Diestsestraat", "3000" },
                    { 36, "", "Anderlecht", false, "MyGameStore Anderlecht", "29", "Olympische Dreef", "1070" },
                    { 37, "", "Grimbergen", true, "MyGameStore Grimbergen", "264", "Hogesteenweg", "1850" },
                    { 38, "5", "Ukkel", false, "MyGameStore Ukkel", "170", "Verrewinkelstraat", "1180" },
                    { 39, "A", "Deinze", false, "MyGameStore Deinze", "180", "Winkelstraat", "9800" },
                    { 40, "", "Brussel", false, "MyGameStore Brussel", "104", "Louizalaan", "1000" },
                    { 41, "", "Waregem", false, "MyGameStore Waregem", "172", "Stationsstraat", "8790" },
                    { 42, "", "Brugge", false, "MyGameStore Brugge", "176", "Steenstraat", "8000" },
                    { 43, "", "Sint-Lambrechts-Woluwe", true, "MyGameStore Sint-Lambrechts-Woluwe", "35", "Konkelstraat", "1200" },
                    { 44, "", "Lommel", false, "MyGameStore Lommel", "157", "Kerkstraat", "3920" },
                    { 45, "", "Evergem", false, "MyGameStore Evergem", "41", "Noorwegenstraat", "9940" },
                    { 46, "", "Lier", false, "MyGameStore Lier", "169", "Antwerpsestraat", "2500" },
                    { 47, "", "Sint-Truiden", false, "MyGameStore Sint-Truiden", "76", "Luikerstraat", "3800" },
                    { 48, "C", "Aarschot", false, "MyGameStore Aarschot", "16", "Martelarenstraat", "3200" },
                    { 49, "", "Oostende", false, "MyGameStore Oostende", "149", "Kapellestraat", "8400" },
                    { 50, "", "Lokeren", false, "MyGameStore Lokeren", "2", "Kerkstraat", "9160" },
                    { 51, "", "Tienen", false, "MyGameStore Tienen", "183", "Leuvensestraat", "3300" },
                    { 52, "", "Vorst", false, "MyGameStore Vorst", "132", "Neerstalse Steenweg", "1190" },
                    { 53, "", "Dilbeek", false, "MyGameStore Dilbeek", "39", "Verheydenstraat", "1700" },
                    { 54, "E", "Bilzen", false, "MyGameStore Bilzen", "97", "Hees", "3740" },
                    { 55, "", "Tongeren", false, "MyGameStore Tongeren", "44", "Maastrichterstraat", "3700" },
                    { 56, "", "Sint-Pieters-Leeuw", false, "MyGameStore Sint-Pieters-Leeuw", "97", "Rink", "1600" },
                    { 57, "", "Beveren", false, "MyGameStore Beveren", "62", "Vrasenestraat", "8791" },
                    { 58, "1", "Bree", false, "MyGameStore Bree", "68", "Gerdingerstraat", "3960" },
                    { 59, "", "Menen", false, "MyGameStore Menen", "142", "Rijselstraat", "8930" },
                    { 60, "", "Berg", false, "MyGameStore Heist-op-den-Berg", "39", "Bergstraat", "1910" }
                });

            migrationBuilder.InsertData(
                schema: "Person",
                table: "tblPeople",
                columns: new[] { "Id", "BirthDate", "EmailAddress", "EmployerId", "FirstName", "Gender", "LastName" },
                values: new object[] { -1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bert@bibber.com", 1, "Bert", 1, "Bibber" });

            migrationBuilder.CreateIndex(
                name: "IX_tblPeople_EmployerId",
                schema: "Person",
                table: "tblPeople",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPeople_Id",
                schema: "Person",
                table: "tblPeople",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblStores_Name",
                schema: "Store",
                table: "tblStores",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblPeople",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "tblStores",
                schema: "Store");
        }
    }
}
