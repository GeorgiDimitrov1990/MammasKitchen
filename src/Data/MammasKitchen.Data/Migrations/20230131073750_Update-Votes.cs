using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MammasKitchen.Data.Migrations
{
    public partial class UpdateVotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Products_ProductId1",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_ProductId1",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Votes");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "Votes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_ProductId",
                table: "Votes",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Products_ProductId",
                table: "Votes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Products_ProductId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_ProductId",
                table: "Votes");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductId1",
                table: "Votes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Votes_ProductId1",
                table: "Votes",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Products_ProductId1",
                table: "Votes",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
