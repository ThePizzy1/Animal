using Microsoft.EntityFrameworkCore.Migrations;

namespace ANIMAL.DAL.Migrations
{
    public partial class Migracija_3001202502 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funds_Adopted_AdoptedCode",
                table: "Funds");

            migrationBuilder.DropIndex(
                name: "IX_Funds_AdoptedCode",
                table: "Funds");

            migrationBuilder.DropColumn(
                name: "AdoptedCode",
                table: "Funds");

            migrationBuilder.AddColumn<int>(
                name: "AnimalsIdAnimal",
                table: "Euthanasia",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FundsId",
                table: "Balans",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funds_AdopterId",
                table: "Funds",
                column: "AdopterId");

            migrationBuilder.CreateIndex(
                name: "IX_Euthanasia_AnimalsIdAnimal",
                table: "Euthanasia",
                column: "AnimalsIdAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_AdopterId",
                table: "Contact",
                column: "AdopterId");

            migrationBuilder.CreateIndex(
                name: "IX_Balans_FundsId",
                table: "Balans",
                column: "FundsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Balans_Funds_FundsId",
                table: "Balans",
                column: "FundsId",
                principalTable: "Funds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Adopter_AdopterId",
                table: "Contact",
                column: "AdopterId",
                principalTable: "Adopter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Euthanasia_Animals_AnimalsIdAnimal",
                table: "Euthanasia",
                column: "AnimalsIdAnimal",
                principalTable: "Animals",
                principalColumn: "IdAnimal",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funds_Adopter_AdopterId",
                table: "Funds",
                column: "AdopterId",
                principalTable: "Adopter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balans_Funds_FundsId",
                table: "Balans");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Adopter_AdopterId",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_Euthanasia_Animals_AnimalsIdAnimal",
                table: "Euthanasia");

            migrationBuilder.DropForeignKey(
                name: "FK_Funds_Adopter_AdopterId",
                table: "Funds");

            migrationBuilder.DropIndex(
                name: "IX_Funds_AdopterId",
                table: "Funds");

            migrationBuilder.DropIndex(
                name: "IX_Euthanasia_AnimalsIdAnimal",
                table: "Euthanasia");

            migrationBuilder.DropIndex(
                name: "IX_Contact_AdopterId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Balans_FundsId",
                table: "Balans");

            migrationBuilder.DropColumn(
                name: "AnimalsIdAnimal",
                table: "Euthanasia");

            migrationBuilder.DropColumn(
                name: "FundsId",
                table: "Balans");

            migrationBuilder.AddColumn<int>(
                name: "AdoptedCode",
                table: "Funds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funds_AdoptedCode",
                table: "Funds",
                column: "AdoptedCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Funds_Adopted_AdoptedCode",
                table: "Funds",
                column: "AdoptedCode",
                principalTable: "Adopted",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
