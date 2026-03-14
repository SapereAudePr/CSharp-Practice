using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPIDemo.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1f2f1f77-25ce-450d-927c-4bc87d01b4b8"), "Medium" },
                    { new Guid("7d98406f-6b1e-4d9d-9442-083581e73883"), "Hard" },
                    { new Guid("927cf7bc-5249-4de7-a1a4-5fce13792125"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImgUrl" },
                values: new object[,]
                {
                    { new Guid("2cc22ad3-f286-464f-a60f-a0e4897c40dd"), "TKI", "Taranaki", null },
                    { new Guid("822940ae-6e22-4a1a-9e43-f79586eea451"), "AUK", "Auckland", null },
                    { new Guid("c812ca2d-dbf2-45d1-9143-1a9b7932f615"), "NTL", "Northland", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("1f2f1f77-25ce-450d-927c-4bc87d01b4b8"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7d98406f-6b1e-4d9d-9442-083581e73883"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("927cf7bc-5249-4de7-a1a4-5fce13792125"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("2cc22ad3-f286-464f-a60f-a0e4897c40dd"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("822940ae-6e22-4a1a-9e43-f79586eea451"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c812ca2d-dbf2-45d1-9143-1a9b7932f615"));
        }
    }
}
