using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElasticExample.Data.Migrations
{
    public partial class UsersAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "ArticleEntities",
                newName: "UpdatedDate");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "ArticleEntities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "UserEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntities", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UserEntities",
                columns: new[] { "Id", "Username" },
                values: new object[] { new Guid("0487afc2-e528-48c3-bca2-1da5adf72baf"), "Denis" });

            migrationBuilder.InsertData(
                table: "UserEntities",
                columns: new[] { "Id", "Username" },
                values: new object[] { new Guid("55759079-471b-4c52-afc2-075f64d46be3"), "Hash" });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleEntities_AuthorId",
                table: "ArticleEntities",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleEntities_UserEntities_AuthorId",
                table: "ArticleEntities",
                column: "AuthorId",
                principalTable: "UserEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleEntities_UserEntities_AuthorId",
                table: "ArticleEntities");

            migrationBuilder.DropTable(
                name: "UserEntities");

            migrationBuilder.DropIndex(
                name: "IX_ArticleEntities_AuthorId",
                table: "ArticleEntities");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "ArticleEntities");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "ArticleEntities",
                newName: "UpdateDate");
        }
    }
}
