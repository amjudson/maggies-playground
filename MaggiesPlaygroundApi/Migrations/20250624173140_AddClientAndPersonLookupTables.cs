using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaggiesPlaygroundApi.Migrations
{
    /// <inheritdoc />
    public partial class AddClientAndPersonLookupTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhoneTypeId1",
                table: "Phones",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmailTypeId1",
                table: "Emails",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressTypeId1",
                table: "Addresses",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StateId1",
                table: "Addresses",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClientAddresses",
                columns: table => new
                {
                    ClientAddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    EnteredBy = table.Column<string>(type: "varchar", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientAddresses", x => x.ClientAddressId);
                    table.ForeignKey(
                        name: "FK_ClientAddresses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientAddresses_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientEmails",
                columns: table => new
                {
                    ClientEmailId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmailId = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    EnteredBy = table.Column<string>(type: "varchar", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientEmails", x => x.ClientEmailId);
                    table.ForeignKey(
                        name: "FK_ClientEmails_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientEmails_Emails_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Emails",
                        principalColumn: "EmailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientPhones",
                columns: table => new
                {
                    ClientPhoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    PhoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    EnteredBy = table.Column<string>(type: "varchar", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPhones", x => x.ClientPhoneId);
                    table.ForeignKey(
                        name: "FK_ClientPhones_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientPhones_Phones_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "Phones",
                        principalColumn: "PhoneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonAddresses",
                columns: table => new
                {
                    PersonAddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    EnteredBy = table.Column<string>(type: "varchar", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAddresses", x => x.PersonAddressId);
                    table.ForeignKey(
                        name: "FK_PersonAddresses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonAddresses_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonEmails",
                columns: table => new
                {
                    PersonEmailId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmailId = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    EnteredBy = table.Column<string>(type: "varchar", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonEmails", x => x.PersonEmailId);
                    table.ForeignKey(
                        name: "FK_PersonEmails_Emails_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Emails",
                        principalColumn: "EmailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonEmails_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonPhones",
                columns: table => new
                {
                    PersonPhoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    PhoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    EnteredBy = table.Column<string>(type: "varchar", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPhones", x => x.PersonPhoneId);
                    table.ForeignKey(
                        name: "FK_PersonPhones_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonPhones_Phones_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "Phones",
                        principalColumn: "PhoneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phones_PhoneTypeId1",
                table: "Phones",
                column: "PhoneTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_EmailTypeId1",
                table: "Emails",
                column: "EmailTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressTypeId1",
                table: "Addresses",
                column: "AddressTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StateId1",
                table: "Addresses",
                column: "StateId1");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddresses_AddressId",
                table: "ClientAddresses",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddresses_ClientId",
                table: "ClientAddresses",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientEmails_ClientId",
                table: "ClientEmails",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientEmails_EmailId",
                table: "ClientEmails",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPhones_ClientId",
                table: "ClientPhones",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPhones_PhoneId",
                table: "ClientPhones",
                column: "PhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddresses_AddressId",
                table: "PersonAddresses",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddresses_PersonId",
                table: "PersonAddresses",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEmails_EmailId",
                table: "PersonEmails",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEmails_PersonId",
                table: "PersonEmails",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPhones_PersonId",
                table: "PersonPhones",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPhones_PhoneId",
                table: "PersonPhones",
                column: "PhoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AddressTypes_AddressTypeId1",
                table: "Addresses",
                column: "AddressTypeId1",
                principalTable: "AddressTypes",
                principalColumn: "AddressTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_States_StateId1",
                table: "Addresses",
                column: "StateId1",
                principalTable: "States",
                principalColumn: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_EmailTypes_EmailTypeId1",
                table: "Emails",
                column: "EmailTypeId1",
                principalTable: "EmailTypes",
                principalColumn: "EmailTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_PhoneTypes_PhoneTypeId1",
                table: "Phones",
                column: "PhoneTypeId1",
                principalTable: "PhoneTypes",
                principalColumn: "PhoneTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AddressTypes_AddressTypeId1",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_States_StateId1",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_EmailTypes_EmailTypeId1",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Phones_PhoneTypes_PhoneTypeId1",
                table: "Phones");

            migrationBuilder.DropTable(
                name: "ClientAddresses");

            migrationBuilder.DropTable(
                name: "ClientEmails");

            migrationBuilder.DropTable(
                name: "ClientPhones");

            migrationBuilder.DropTable(
                name: "PersonAddresses");

            migrationBuilder.DropTable(
                name: "PersonEmails");

            migrationBuilder.DropTable(
                name: "PersonPhones");

            migrationBuilder.DropIndex(
                name: "IX_Phones_PhoneTypeId1",
                table: "Phones");

            migrationBuilder.DropIndex(
                name: "IX_Emails_EmailTypeId1",
                table: "Emails");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_AddressTypeId1",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_StateId1",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "PhoneTypeId1",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "EmailTypeId1",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "AddressTypeId1",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "StateId1",
                table: "Addresses");
        }
    }
}
