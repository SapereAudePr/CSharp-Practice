using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewFieldsAndUsingTypeConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Corporates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Corporates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Corporates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "UpdatedBy" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Corporates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "UpdatedBy" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Corporates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedBy", "UpdatedBy" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "UpdatedBy" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "UpdatedBy" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedBy", "UpdatedBy" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "UpdatedBy" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "UpdatedBy" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedBy", "UpdatedBy" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Corporates");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Corporates");
        }
    }
}
