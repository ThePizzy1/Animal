using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ANIMAL.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adopter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Residence = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Username = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    NumAdoptedAnimals = table.Column<int>(nullable: false),
                    NumReturnedAnimals = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adopter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    IdAnimal = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Family = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Species = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Subspecies = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Neutered = table.Column<bool>(nullable: false),
                    Vaccinated = table.Column<bool>(nullable: false),
                    Microchipped = table.Column<bool>(nullable: false),
                    Trained = table.Column<bool>(nullable: false),
                    Socialized = table.Column<bool>(nullable: false),
                    Picture = table.Column<byte[]>(nullable: false),
                    HealthIssues = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    PersonalityDescription = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    Adopted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Animals__951092F0A1868E05", x => x.IdAnimal);
                });

            migrationBuilder.CreateTable(
                name: "Adopted",
                columns: table => new
                {
                    Code = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(nullable: false),
                    AdopterId = table.Column<int>(nullable: false),
                    AdoptionDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Adopted__A25C5AA69BF7B47B", x => x.Code);
                    table.ForeignKey(
                        name: "FK__Adopted__Adopter__4E88ABD4",
                        column: x => x.AdopterId,
                        principalTable: "Adopter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Adopted__AnimalI__4D94879B",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Amphibians",
                columns: table => new
                {
                    AnimalId = table.Column<int>(nullable: false),
                    Humidity = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    Temperature = table.Column<decimal>(type: "decimal(5, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Amphibian__Anima__5CD6CB2B",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Birds",
                columns: table => new
                {
                    AnimalId = table.Column<int>(nullable: false),
                    CageSize = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    RecommendedToys = table.Column<string>(unicode: false, maxLength: 1000, nullable: false),
                    Sociability = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Birds__A21A73070FA89F7C", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK__Birds__AnimalId__5812160E",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fish",
                columns: table => new
                {
                    AnimalId = table.Column<int>(nullable: false),
                    TankSize = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    CompatibleSpecies = table.Column<string>(unicode: false, maxLength: 1000, nullable: false),
                    RecommendedItems = table.Column<string>(unicode: false, maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Fish__AnimalId__5EBF139D",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mammals",
                columns: table => new
                {
                    AnimalId = table.Column<int>(nullable: false),
                    CoatType = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    GroomingProducts = table.Column<string>(unicode: false, maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Mammals__AnimalI__5535A963",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reptiles",
                columns: table => new
                {
                    AnimalId = table.Column<int>(nullable: false),
                    TankSize = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Sociability = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    CompatibleSpecies = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    RecommendedItems = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reptiles__A21A7307D28BF62E", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK__Reptiles__Animal__5AEE82B9",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReturnedAnimal",
                columns: table => new
                {
                    ReturnCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdoptionCode = table.Column<int>(nullable: false),
                    AnimalId = table.Column<int>(nullable: false),
                    AdopterId = table.Column<int>(nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "date", nullable: false),
                    ReturnReason = table.Column<string>(unicode: false, maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Returned__4CF726C86410F49F", x => x.ReturnCode);
                    table.ForeignKey(
                        name: "FK__ReturnedA__Adopt__534D60F1",
                        column: x => x.AdopterId,
                        principalTable: "Adopter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ReturnedA__Adopt__5165187F",
                        column: x => x.AdoptionCode,
                        principalTable: "Adopted",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ReturnedA__Anima__52593CB8",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adopted_AdopterId",
                table: "Adopted",
                column: "AdopterId");

            migrationBuilder.CreateIndex(
                name: "IX_Adopted_AnimalId",
                table: "Adopted",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Amphibians_AnimalId",
                table: "Amphibians",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Fish_AnimalId",
                table: "Fish",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Mammals_AnimalId",
                table: "Mammals",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnedAnimal_AdopterId",
                table: "ReturnedAnimal",
                column: "AdopterId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnedAnimal_AdoptionCode",
                table: "ReturnedAnimal",
                column: "AdoptionCode");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnedAnimal_AnimalId",
                table: "ReturnedAnimal",
                column: "AnimalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amphibians");

            migrationBuilder.DropTable(
                name: "Birds");

            migrationBuilder.DropTable(
                name: "Fish");

            migrationBuilder.DropTable(
                name: "Mammals");

            migrationBuilder.DropTable(
                name: "Reptiles");

            migrationBuilder.DropTable(
                name: "ReturnedAnimal");

            migrationBuilder.DropTable(
                name: "Adopted");

            migrationBuilder.DropTable(
                name: "Adopter");

            migrationBuilder.DropTable(
                name: "Animals");
        }
    }
}
