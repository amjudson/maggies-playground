using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MaggiesPlaygroundApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPhonesAndPhoneTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhoneTypes",
                columns: table => new
                {
                    PhoneTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    ClientId = table.Column<string>(type: "varchar", maxLength: 255, nullable: true),
                    Name = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    ClientOption = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneTypes", x => x.PhoneTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    PhoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    Extension = table.Column<string>(type: "varchar", maxLength: 10, nullable: true),
                    PhoneTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.PhoneId);
                    table.ForeignKey(
                        name: "FK_Phones_PhoneTypes_PhoneTypeId",
                        column: x => x.PhoneTypeId,
                        principalTable: "PhoneTypes",
                        principalColumn: "PhoneTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PhoneTypes",
                columns: new[] { "PhoneTypeId", "ClientId", "ClientOption", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, false, "Home phone number", "Home" },
                    { 2, null, false, "Work phone number", "Work" },
                    { 3, null, false, "Mobile phone number", "Mobile" },
                    { 4, null, false, "Fax number", "Fax" },
                    { 5, null, false, "Emergency contact number", "Emergency" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phones_PhoneTypeId",
                table: "Phones",
                column: "PhoneTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "PhoneTypes");
        }
    }
}
