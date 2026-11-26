using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class ReservaComExemplar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Livros_LivroReservadoId",
                table: "Reservas");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Exemplares_LivroReservadoId",
                table: "Reservas",
                column: "LivroReservadoId",
                principalTable: "Exemplares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Exemplares_LivroReservadoId",
                table: "Reservas");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Livros_LivroReservadoId",
                table: "Reservas",
                column: "LivroReservadoId",
                principalTable: "Livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
