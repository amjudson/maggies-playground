using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MaggiesPlaygroundApi.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailsAndEmailTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailTypes",
                columns: table => new
                {
                    EmailTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    ClientId = table.Column<string>(type: "varchar", maxLength: 255, nullable: true),
                    Name = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    ClientOption = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTypes", x => x.EmailTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    EmailId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmailAddress = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    EmailTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.EmailId);
                    table.ForeignKey(
                        name: "FK_Emails_EmailTypes_EmailTypeId",
                        column: x => x.EmailTypeId,
                        principalTable: "EmailTypes",
                        principalColumn: "EmailTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "EmailTypes",
                columns: new[] { "EmailTypeId", "ClientId", "ClientOption", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, false, "Personal email address", "Personal" },
                    { 2, null, false, "Work email address", "Work" },
                    { 3, null, false, "Business email address", "Business" },
                    { 4, null, false, "Marketing email address", "Marketing" },
                    { 5, null, false, "Support email address", "Support" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emails_EmailTypeId",
                table: "Emails",
                column: "EmailTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "EmailTypes");
        }
    }
}
