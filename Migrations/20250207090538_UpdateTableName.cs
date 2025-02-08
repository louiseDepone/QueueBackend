using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TicketDocument_TicketDocumentId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TicketFinance_TicketFinanceId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketFinance_Document_TypeOfDocument",
                table: "TicketFinance");

            migrationBuilder.DropIndex(
                name: "IX_TicketFinance_TypeOfDocument",
                table: "TicketFinance");

            migrationBuilder.DropColumn(
                name: "TypeOfDocument",
                table: "TicketFinance");

            migrationBuilder.DropColumn(
                name: "AmountToPay",
                table: "TicketDocument");

            migrationBuilder.DropColumn(
                name: "CashTendered",
                table: "TicketDocument");

            migrationBuilder.DropColumn(
                name: "PurposeOfTransaction",
                table: "TicketDocument");

            migrationBuilder.AddColumn<decimal>(
                name: "AmountToPay",
                table: "TicketFinance",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CashTendered",
                table: "TicketFinance",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurposeOfTransaction",
                table: "TicketFinance",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfDocument",
                table: "TicketDocument",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketDocument_TypeOfDocument",
                table: "TicketDocument",
                column: "TypeOfDocument");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDocument_Document_TypeOfDocument",
                table: "TicketDocument",
                column: "TypeOfDocument",
                principalTable: "Document",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TicketDocument_TicketFinanceId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TicketFinance_TicketDocumentId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketDocument_Document_TypeOfDocument",
                table: "TicketDocument");

            migrationBuilder.DropIndex(
                name: "IX_TicketDocument_TypeOfDocument",
                table: "TicketDocument");

            migrationBuilder.DropColumn(
                name: "AmountToPay",
                table: "TicketFinance");

            migrationBuilder.DropColumn(
                name: "CashTendered",
                table: "TicketFinance");

            migrationBuilder.DropColumn(
                name: "PurposeOfTransaction",
                table: "TicketFinance");

            migrationBuilder.DropColumn(
                name: "TypeOfDocument",
                table: "TicketDocument");

            migrationBuilder.AddColumn<int>(
                name: "TypeOfDocument",
                table: "TicketFinance",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountToPay",
                table: "TicketDocument",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CashTendered",
                table: "TicketDocument",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurposeOfTransaction",
                table: "TicketDocument",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketFinance_TypeOfDocument",
                table: "TicketFinance",
                column: "TypeOfDocument");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TicketFinance_Document_TypeOfDocument",
                table: "TicketFinance",
                column: "TypeOfDocument",
                principalTable: "Document",
                principalColumn: "Id");
        }
    }
}
