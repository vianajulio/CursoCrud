using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoCrud.Api.Migrations
{
    /// <inheritdoc />
    public partial class v002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_carrinho",
                table: "carrinho");

            migrationBuilder.RenameTable(
                name: "carrinho",
                newName: "Cars");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.RenameTable(
                name: "Cars",
                newName: "carrinho");

            migrationBuilder.AddPrimaryKey(
                name: "PK_carrinho",
                table: "carrinho",
                column: "Id");
        }
    }
}
