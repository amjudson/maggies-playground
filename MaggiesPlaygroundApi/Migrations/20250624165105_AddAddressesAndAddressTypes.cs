using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MaggiesPlaygroundApi.Migrations
{
    /// <inheritdoc />
    public partial class AddAddressesAndAddressTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressTypes",
                columns: table => new
                {
                    AddressTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    ClientId = table.Column<string>(type: "varchar", maxLength: 255, nullable: true),
                    Name = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    ClientOption = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTypes", x => x.AddressTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressLine1 = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    AddressLine2 = table.Column<string>(type: "varchar", maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    StateId = table.Column<int>(type: "integer", nullable: false),
                    Zip = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    AddressTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_AddressTypes_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalTable: "AddressTypes",
                        principalColumn: "AddressTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AddressTypes",
                columns: new[] { "AddressTypeId", "ClientId", "ClientOption", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, false, "Home address", "Home" },
                    { 2, null, false, "Work address", "Work" },
                    { 3, null, false, "Billing address", "Billing" },
                    { 4, null, false, "Shipping address", "Shipping" },
                    { 5, null, false, "Mailing address", "Mailing" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressTypeId",
                table: "Addresses",
                column: "AddressTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AddressTypes");
        }
    }
}
