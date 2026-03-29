using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixCustomerIdIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Customers");

            migrationBuilder.AddColumn<long>(
                name: "CustomerId",
                table: "Customers",
                type: "bigint",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(name: "PK_Customers", table: "Customers");
            migrationBuilder.DropColumn(name: "CustomerId", table: "Customers");

            migrationBuilder.AddColumn<long>(
                name: "CustomerId",
                table: "Customers",
                type: "bigint",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"); 

            migrationBuilder.AddPrimaryKey(name: "PK_Customers", table: "Customers", column: "CustomerId");
        }
    }
}
