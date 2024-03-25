using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class alterandomapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "ImagemCapa",
                table: "Filmes",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(500)",
                oldMaxLength: 500);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "ImagemCapa",
                table: "Filmes",
                type: "varbinary(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);
        }
    }
}
