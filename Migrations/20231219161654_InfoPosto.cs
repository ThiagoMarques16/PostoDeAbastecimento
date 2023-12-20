using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaDePostos.Migrations
{
    /// <inheritdoc />
    public partial class InfoPosto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Banheiro",
                table: "PostosDeAbastecimento",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Calibrador",
                table: "PostosDeAbastecimento",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                table: "PostosDeAbastecimento",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "LavaJato",
                table: "PostosDeAbastecimento",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Banheiro",
                table: "PostosDeAbastecimento");

            migrationBuilder.DropColumn(
                name: "Calibrador",
                table: "PostosDeAbastecimento");

            migrationBuilder.DropColumn(
                name: "Cnpj",
                table: "PostosDeAbastecimento");

            migrationBuilder.DropColumn(
                name: "LavaJato",
                table: "PostosDeAbastecimento");
        }
    }
}
