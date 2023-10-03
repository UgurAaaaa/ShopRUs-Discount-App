using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopRUs_Discount_API_Minimal.Migrations
{
    /// <inheritdoc />
    public partial class thirdmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "discountPer100",
                table: "Invoice",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "discountPer100",
                table: "Invoice");
        }
    }
}
