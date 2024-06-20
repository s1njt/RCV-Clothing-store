using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCVAPI4.Migrations
{
    /// <inheritdoc />
    public partial class cartmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cart_user = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cart_clotheid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cart_price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");
        }
    }
}
