using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _001_Basics.Migrations
{
    /// <inheritdoc />
    public partial class AlcoholColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Alcohol",
                table: "BeerModels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alcohol",
                table: "BeerModels");
        }
    }
}
