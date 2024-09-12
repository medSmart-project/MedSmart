
using Microsoft.EntityFrameworkCore.Migrations;

public partial class AddTable : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Medications_Brands_BrandId1",
            table: "Medications");

        migrationBuilder.DropForeignKey(
            name: "FK_Medications_MedicationCategories_CategoryId1",
            table: "Medications");

        migrationBuilder.DropIndex(
            name: "IX_Medications_BrandId1",
            table: "Medications");

        migrationBuilder.DropIndex(
            name: "IX_Medications_CategoryId1",
            table: "Medications");

        migrationBuilder.DropColumn(
            name: "BrandId1",
            table: "Medications");

        migrationBuilder.DropColumn(
            name: "CategoryId1",
            table: "Medications");

        migrationBuilder.AddColumn<string>(
            name: "Password",
            table: "Users",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "");

        migrationBuilder.AlterColumn<Guid>(
            name: "CategoryId",
            table: "Medications",
            type: "uniqueidentifier",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<Guid>(
            name: "BrandId",
            table: "Medications",
            type: "uniqueidentifier",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AddColumn<DateTime>(
            name: "CreatedAt",
            table: "Medications",
            type: "datetime2",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<string>(
            name: "PublicId",
            table: "MedicationImages",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "");

        migrationBuilder.CreateIndex(
            name: "IX_Medications_BrandId",
            table: "Medications",
            column: "BrandId");

        migrationBuilder.CreateIndex(
            name: "IX_Medications_CategoryId",
            table: "Medications",
            column: "CategoryId");

        migrationBuilder.AddForeignKey(
            name: "FK_Medications_Brands_BrandId",
            table: "Medications",
            column: "BrandId",
            principalTable: "Brands",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_Medications_MedicationCategories_CategoryId",
            table: "Medications",
            column: "CategoryId",
            principalTable: "MedicationCategories",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Medications_Brands_BrandId",
            table: "Medications");

        migrationBuilder.DropForeignKey(
            name: "FK_Medications_MedicationCategories_CategoryId",
            table: "Medications");

        migrationBuilder.DropIndex(
            name: "IX_Medications_BrandId",
            table: "Medications");

        migrationBuilder.DropIndex(
            name: "IX_Medications_CategoryId",
            table: "Medications");

        migrationBuilder.DropColumn(
            name: "Password",
            table: "Users");

        migrationBuilder.DropColumn(
            name: "CreatedAt",
            table: "Medications");

        migrationBuilder.DropColumn(
            name: "PublicId",
            table: "MedicationImages");

        migrationBuilder.AlterColumn<int>(
            name: "CategoryId",
            table: "Medications",
            type: "int",
            nullable: false,
            oldClrType: typeof(Guid),
            oldType: "uniqueidentifier");

        migrationBuilder.AlterColumn<int>(
            name: "BrandId",
            table: "Medications",
            type: "int",
            nullable: false,
            oldClrType: typeof(Guid),
            oldType: "uniqueidentifier");

        migrationBuilder.AddColumn<int>(
            name: "BrandId1",
            table: "Medications",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<int>(
            name: "CategoryId1",
            table: "Medications",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.CreateIndex(
            name: "IX_Medications_BrandId1",
            table: "Medications",
            column: "BrandId1");

        migrationBuilder.CreateIndex(
            name: "IX_Medications_CategoryId1",
            table: "Medications",
            column: "CategoryId1");

        migrationBuilder.AddForeignKey(
            name: "FK_Medications_Brands_BrandId1",
            table: "Medications",
            column: "BrandId1",
            principalTable: "Brands",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_Medications_MedicationCategories_CategoryId1",
            table: "Medications",
            column: "CategoryId1",
            principalTable: "MedicationCategories",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}