using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCHotel.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexToReservationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_reservation_first_name",
                table: "reservation",
                column: "first_name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_reservation_first_name",
                table: "reservation");
        }
    }
}
