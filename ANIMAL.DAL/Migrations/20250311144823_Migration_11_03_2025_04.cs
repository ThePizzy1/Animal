using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ANIMAL.DAL.Migrations
{
    public partial class Migration_11_03_2025_04 : Migration
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
                    NumAdoptedAnimals = table.Column<int>(unicode: false, maxLength: 255, nullable: false),
                    NumReturnedAnimals = table.Column<int>(unicode: false, maxLength: 255, nullable: false),
                    Flag = table.Column<bool>(nullable: false),
                    RegisterId = table.Column<string>(nullable: true)
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
                    HealthIssues = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    PersonalityDescription = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    Adopted = table.Column<bool>(nullable: false),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Animals__951092F0A1868E05", x => x.IdAnimal);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Balans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Iban = table.Column<string>(unicode: false, maxLength: 21, nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(20, 2)", nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false, defaultValue: new DateTime().AddTicks(1508)),
                    Password = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Balans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    FoodType = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    AnimalType = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    AgeGroup = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    MeasurementWeight = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    CaloriesPerServing = table.Column<decimal>(type: "decimal(10, 4)", nullable: false),
                    WeightPerServing = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    MeasurementPerServing = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    FatContent = table.Column<decimal>(type: "decimal(10, 4)", nullable: false),
                    FiberContent = table.Column<decimal>(type: "decimal(10, 4)", nullable: false),
                    ExporationDate = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(unicode: false, maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Food", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 50000, nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordNumber = table.Column<int>(type: "integer", nullable: false),
                    RecordName = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    RecordDescription = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SystemRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Toys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    AnimalType = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ToyType = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    AgeGroup = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Hight = table.Column<decimal>(type: "decimal(10,2 )", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(10,2 )", nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Toys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    AdopterId = table.Column<int>(nullable: false),
                    Read = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Contact__Adopter",
                        column: x => x.AdopterId,
                        principalTable: "Adopter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Funds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdopterId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(20, 2)", nullable: false),
                    Purpose = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    DateTimed = table.Column<DateTime>(nullable: false, defaultValue: new DateTime().AddTicks(3822))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Funds", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Funds__Adopter",
                        column: x => x.AdopterId,
                        principalTable: "Adopter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "ContageusAnimals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(nullable: false),
                    DesisseName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    Contageus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ContageusAnimals", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ContageusAnimals__Animal",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Euthanasia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    NameOfDesissse = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Complited = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Euthanasia", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Euthanasia__Animal",
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
                name: "Labs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Labs_1235468", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Labs__Animals",
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
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(nullable: false),
                    NameOfMedicines = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    VetUsername = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    AmountOfMedicine = table.Column<decimal>(type: "decimal(20, 6)", nullable: false),
                    MesurmentUnit = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    MedicationIntake = table.Column<int>(nullable: false),
                    FrequencyOfMedicationUse = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Usage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Medicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Medicines__Animal",
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
                name: "VetVisits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    TypeOfVisit = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Notes = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__VetVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK__VetVisits__Animal",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoundRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Adress = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    OwnerName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    OwnerSurname = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    OwnerPhoneNumber = table.Column<string>(unicode: false, maxLength: 13, nullable: false),
                    OwnerOIB = table.Column<string>(unicode: false, maxLength: 11, nullable: false),
                    RegisterId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FoundRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK__FoundRecord__Animal",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__FoundRecord__User",
                        column: x => x.RegisterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnimalRecord",
                columns: table => new
                {
                    AnimalId = table.Column<int>(nullable: false),
                    RecordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AnimalRecord", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK__AnimalRecord__Animals__AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__AnimalRecord__SystemRecord__RecordId",
                        column: x => x.RecordId,
                        principalTable: "SystemRecord",
                        principalColumn: "Id",
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

            migrationBuilder.CreateTable(
                name: "Parameter",
                columns: table => new
                {
                    LabId = table.Column<int>(nullable: false),
                    ParameterName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ParameterValue = table.Column<decimal>(type: "decimal(10, 4)", nullable: false),
                    Remarks = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    MeasurementUnits = table.Column<string>(unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Parameter", x => x.LabId);
                    table.ForeignKey(
                        name: "FK__Parameter__Lab",
                        column: x => x.LabId,
                        principalTable: "Labs",
                        principalColumn: "Id",
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
                name: "IX_AnimalRecord_RecordId",
                table: "AnimalRecord",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Balans_Iban",
                table: "Balans",
                column: "Iban",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_AdopterId",
                table: "Contact",
                column: "AdopterId");

            migrationBuilder.CreateIndex(
                name: "IX_ContageusAnimals_AnimalId",
                table: "ContageusAnimals",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Euthanasia_AnimalId",
                table: "Euthanasia",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Fish_AnimalId",
                table: "Fish",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_FoundRecord_AnimalId",
                table: "FoundRecord",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_FoundRecord_RegisterId",
                table: "FoundRecord",
                column: "RegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_Funds_AdopterId",
                table: "Funds",
                column: "AdopterId");

            migrationBuilder.CreateIndex(
                name: "IX_Labs_AnimalId",
                table: "Labs",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Mammals_AnimalId",
                table: "Mammals",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_AnimalId",
                table: "Medicines",
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

            migrationBuilder.CreateIndex(
                name: "IX_VetVisits_AnimalId",
                table: "VetVisits",
                column: "AnimalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amphibians");

            migrationBuilder.DropTable(
                name: "AnimalRecord");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Balans");

            migrationBuilder.DropTable(
                name: "Birds");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "ContageusAnimals");

            migrationBuilder.DropTable(
                name: "Euthanasia");

            migrationBuilder.DropTable(
                name: "Fish");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "FoundRecord");

            migrationBuilder.DropTable(
                name: "Funds");

            migrationBuilder.DropTable(
                name: "Mammals");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Parameter");

            migrationBuilder.DropTable(
                name: "Reptiles");

            migrationBuilder.DropTable(
                name: "ReturnedAnimal");

            migrationBuilder.DropTable(
                name: "Toys");

            migrationBuilder.DropTable(
                name: "VetVisits");

            migrationBuilder.DropTable(
                name: "SystemRecord");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Labs");

            migrationBuilder.DropTable(
                name: "Adopted");

            migrationBuilder.DropTable(
                name: "Adopter");

            migrationBuilder.DropTable(
                name: "Animals");
        }
    }
}
