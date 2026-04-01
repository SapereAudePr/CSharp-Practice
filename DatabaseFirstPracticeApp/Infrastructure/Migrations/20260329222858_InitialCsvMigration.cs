using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCsvMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bank_Churn",
                table: "Bank_Churn");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Bank_Churn");

            migrationBuilder.RenameTable(
                name: "Bank_Churn",
                newName: "BankChurn");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "BankChurn",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankChurn",
                table: "BankChurn",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BankChurn",
                table: "BankChurn");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "BankChurn");

            migrationBuilder.RenameTable(
                name: "BankChurn",
                newName: "Bank_Churn");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Bank_Churn",
                type: "int",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bank_Churn",
                table: "Bank_Churn",
                column: "CustomerId");
        }
    }
}
