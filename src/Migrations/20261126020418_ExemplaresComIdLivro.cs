using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class ExemplaresComIdLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exemplares_Livros_LivroId",
                table: "Exemplares");

            migrationBuilder.AddColumn<string>(
                name: "CapaUrl",
                table: "Livros",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LivroId",
                table: "Exemplares",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exemplares_Livros_LivroId",
                table: "Exemplares",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exemplares_Livros_LivroId",
                table: "Exemplares");

            migrationBuilder.DropColumn(
                name: "CapaUrl",
                table: "Livros");

            migrationBuilder.AlterColumn<int>(
                name: "LivroId",
                table: "Exemplares",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Exemplares_Livros_LivroId",
                table: "Exemplares",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "Id");
        }
    }
}
