using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransactionExchange.Api.Migrations
{
    /// <inheritdoc />
    public partial class TransactionTableChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrencyName",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CurrencyName",
                table: "Transactions");
        }
    }
}
