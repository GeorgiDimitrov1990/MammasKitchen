#nullable disable

namespace MammasKitchen.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class Image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_AspNetUsers_AddedByUserId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Products_ProductId",
                table: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Image",
                table: "Image");

            migrationBuilder.RenameTable(
            name: "Image",
            schema: "dbo",
            newName: "Images",
            newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Image_ProductId",
                table: "Images",
                newName: "IX_Images_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Image_AddedByUserId",
                table: "Images",
                newName: "IX_Images_AddedByUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AspNetUsers_AddedByUserId",
                table: "Images",
                column: "AddedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_ProductId",
                table: "Images",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_AddedByUserId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_ProductId",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
            name: "Image",
            schema: "dbo",
            newName: "Images",
            newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Images_ProductId",
                table: "Image",
                newName: "IX_Image_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_AddedByUserId",
                table: "Image",
                newName: "IX_Image_AddedByUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Image",
                table: "Image",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_AspNetUsers_AddedByUserId",
                table: "Image",
                column: "AddedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Products_ProductId",
                table: "Image",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
