using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class WTD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Department_DepartmentId",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TicketDocument_TicketFinanceId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TicketFinance_TicketDocumentId",
                table: "Ticket");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Document",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Department_DepartmentId",
                table: "Document",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_TicketDocument_TicketDocumentId",
                table: "Ticket",
                column: "TicketDocumentId",
                principalTable: "TicketDocument",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_TicketFinance_TicketFinanceId",
                table: "Ticket",
                column: "TicketFinanceId",
                principalTable: "TicketFinance",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Department_DepartmentId",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TicketDocument_TicketDocumentId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TicketFinance_TicketFinanceId",
                table: "Ticket");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Document",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Department_DepartmentId",
                table: "Document",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_TicketDocument_TicketFinanceId",
                table: "Ticket",
                column: "TicketFinanceId",
                principalTable: "TicketDocument",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_TicketFinance_TicketDocumentId",
                table: "Ticket",
                column: "TicketDocumentId",
                principalTable: "TicketFinance",
                principalColumn: "Id");
        }
    }
}
