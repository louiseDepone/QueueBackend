using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class UPdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Departments_DepartmentId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Roles_RoleId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Counters_Departments_DepartmentId",
                table: "Counters");

            migrationBuilder.DropForeignKey(
                name: "FK_Counters_Tickets_CurrentTicketId",
                table: "Counters");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Departments_DepartmentId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketFinances_Documents_TypeOfDocument",
                table: "TicketFinances");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Departments_DepartmentId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketDocuments_TicketDocumentId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketFinances_TicketFinanceId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_TransactedBy",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Departments_DepartmentId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Tickets_TicketId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketFinances",
                table: "TicketFinances");

            migrationBuilder.DropIndex(
                name: "IX_TicketFinances_TypeOfDocument",
                table: "TicketFinances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketDocuments",
                table: "TicketDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documents",
                table: "Documents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Counters",
                table: "Counters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "TypeOfDocument",
                table: "TicketFinances");

            migrationBuilder.DropColumn(
                name: "AmountToPay",
                table: "TicketDocuments");

            migrationBuilder.DropColumn(
                name: "CashTendered",
                table: "TicketDocuments");

            migrationBuilder.DropColumn(
                name: "PurposeOfTransaction",
                table: "TicketDocuments");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transaction");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Ticket");

            migrationBuilder.RenameTable(
                name: "TicketFinances",
                newName: "TicketDocument");

            migrationBuilder.RenameTable(
                name: "TicketDocuments",
                newName: "TicketFinance");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "Documents",
                newName: "Document");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameTable(
                name: "Counters",
                newName: "Counter");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "Account");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_TransactedBy",
                table: "Transaction",
                newName: "IX_Transaction_TransactedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_TicketId",
                table: "Transaction",
                newName: "IX_Transaction_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_DepartmentId",
                table: "Transaction",
                newName: "IX_Transaction_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TicketFinanceId",
                table: "Ticket",
                newName: "IX_Ticket_TicketFinanceId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TicketDocumentId",
                table: "Ticket",
                newName: "IX_Ticket_TicketDocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_DepartmentId",
                table: "Ticket",
                newName: "IX_Ticket_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_DepartmentId",
                table: "Document",
                newName: "IX_Document_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Counters_DepartmentId",
                table: "Counter",
                newName: "IX_Counter_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Counters_CurrentTicketId",
                table: "Counter",
                newName: "IX_Counter_CurrentTicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_RoleId",
                table: "Account",
                newName: "IX_Account_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_DepartmentId",
                table: "Account",
                newName: "IX_Account_DepartmentId");

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

            migrationBuilder.AddColumn<int>(
                name: "TypeOfDocument",
                table: "TicketFinance",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketDocument",
                table: "TicketDocument",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketFinance",
                table: "TicketFinance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document",
                table: "Document",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Counter",
                table: "Counter",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                table: "Account",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TicketFinance_TypeOfDocument",
                table: "TicketFinance",
                column: "TypeOfDocument");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Department_DepartmentId",
                table: "Account",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Role_RoleId",
                table: "Account",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Counter_Department_DepartmentId",
                table: "Counter",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Counter_Ticket_CurrentTicketId",
                table: "Counter",
                column: "CurrentTicketId",
                principalTable: "Ticket",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Department_DepartmentId",
                table: "Document",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Department_DepartmentId",
                table: "Ticket",
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

            migrationBuilder.AddForeignKey(
                name: "FK_TicketFinance_Document_TypeOfDocument",
                table: "TicketFinance",
                column: "TypeOfDocument",
                principalTable: "Document",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Account_TransactedBy",
                table: "Transaction",
                column: "TransactedBy",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Department_DepartmentId",
                table: "Transaction",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Ticket_TicketId",
                table: "Transaction",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Department_DepartmentId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Account_Role_RoleId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Counter_Department_DepartmentId",
                table: "Counter");

            migrationBuilder.DropForeignKey(
                name: "FK_Counter_Ticket_CurrentTicketId",
                table: "Counter");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_Department_DepartmentId",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Department_DepartmentId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TicketDocument_TicketDocumentId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TicketFinance_TicketFinanceId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketFinance_Document_TypeOfDocument",
                table: "TicketFinance");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Account_TransactedBy",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Department_DepartmentId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Ticket_TicketId",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketFinance",
                table: "TicketFinance");

            migrationBuilder.DropIndex(
                name: "IX_TicketFinance_TypeOfDocument",
                table: "TicketFinance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketDocument",
                table: "TicketDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Document",
                table: "Document");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Counter",
                table: "Counter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                table: "Account");

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

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "Transactions");

            migrationBuilder.RenameTable(
                name: "TicketFinance",
                newName: "TicketDocuments");

            migrationBuilder.RenameTable(
                name: "TicketDocument",
                newName: "TicketFinances");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickets");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Document",
                newName: "Documents");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameTable(
                name: "Counter",
                newName: "Counters");

            migrationBuilder.RenameTable(
                name: "Account",
                newName: "Accounts");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_TransactedBy",
                table: "Transactions",
                newName: "IX_Transactions_TransactedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_TicketId",
                table: "Transactions",
                newName: "IX_Transactions_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_DepartmentId",
                table: "Transactions",
                newName: "IX_Transactions_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_TicketFinanceId",
                table: "Tickets",
                newName: "IX_Tickets_TicketFinanceId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_TicketDocumentId",
                table: "Tickets",
                newName: "IX_Tickets_TicketDocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_DepartmentId",
                table: "Tickets",
                newName: "IX_Tickets_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Document_DepartmentId",
                table: "Documents",
                newName: "IX_Documents_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Counter_DepartmentId",
                table: "Counters",
                newName: "IX_Counters_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Counter_CurrentTicketId",
                table: "Counters",
                newName: "IX_Counters_CurrentTicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Account_RoleId",
                table: "Accounts",
                newName: "IX_Accounts_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Account_DepartmentId",
                table: "Accounts",
                newName: "IX_Accounts_DepartmentId");

            migrationBuilder.AddColumn<decimal>(
                name: "AmountToPay",
                table: "TicketDocuments",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CashTendered",
                table: "TicketDocuments",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurposeOfTransaction",
                table: "TicketDocuments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfDocument",
                table: "TicketFinances",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketDocuments",
                table: "TicketDocuments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketFinances",
                table: "TicketFinances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documents",
                table: "Documents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Counters",
                table: "Counters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TicketFinances_TypeOfDocument",
                table: "TicketFinances",
                column: "TypeOfDocument");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Departments_DepartmentId",
                table: "Accounts",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Roles_RoleId",
                table: "Accounts",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Counters_Departments_DepartmentId",
                table: "Counters",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Counters_Tickets_CurrentTicketId",
                table: "Counters",
                column: "CurrentTicketId",
                principalTable: "Tickets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Departments_DepartmentId",
                table: "Documents",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketFinances_Documents_TypeOfDocument",
                table: "TicketFinances",
                column: "TypeOfDocument",
                principalTable: "Documents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Departments_DepartmentId",
                table: "Tickets",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketDocuments_TicketDocumentId",
                table: "Tickets",
                column: "TicketDocumentId",
                principalTable: "TicketDocuments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketFinances_TicketFinanceId",
                table: "Tickets",
                column: "TicketFinanceId",
                principalTable: "TicketFinances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_TransactedBy",
                table: "Transactions",
                column: "TransactedBy",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Departments_DepartmentId",
                table: "Transactions",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Tickets_TicketId",
                table: "Transactions",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
