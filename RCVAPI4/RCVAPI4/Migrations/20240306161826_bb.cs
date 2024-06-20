using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCVAPI4.Migrations
{
    /// <inheritdoc />
    public partial class bb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "TicketsT",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ticket_acceptUserId = table.Column<int>(type: "int", nullable: false),
                    ticket_productsId = table.Column<int>(type: "int", nullable: false),
                    ticket_contactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ticket_createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ticket_deliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ticket_deliveryAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ticket_deliveryStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ticket_sum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketsT", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketsT");

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    ticketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ticket_acceptUserId = table.Column<int>(type: "int", nullable: false),
                    ticket_contactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ticket_createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ticket_deliveryAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ticket_deliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ticket_deliveryStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ticket_productsId = table.Column<int>(type: "int", nullable: false),
                    ticket_sum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.ticketId);
                });
        }
    }
}
