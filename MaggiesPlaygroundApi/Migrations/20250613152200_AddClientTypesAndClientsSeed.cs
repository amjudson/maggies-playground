using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MaggiesPlaygroundApi.Migrations
{
    /// <inheritdoc />
    public partial class AddClientTypesAndClientsSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ClientTypes",
                columns: new[] { "ClientTypeId", "Active", "CreatedDate", "EnteredBy", "Name" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451), "System", "Corporate" },
                    { 2, true, new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451), "System", "Small Business" },
                    { 3, true, new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451), "System", "Startup" },
                    { 4, true, new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451), "System", "Non-Profit" },
                    { 5, true, new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451), "System", "Government" }
                });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "PersonTypes",
                keyColumn: "PersonTypeId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "PersonTypes",
                keyColumn: "PersonTypeId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "PersonTypes",
                keyColumn: "PersonTypeId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "PersonTypes",
                keyColumn: "PersonTypeId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451));

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Active", "ClientName", "ClientTypeId", "CreatedDate", "EnteredBy" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), true, "Acme Corporation", 1, new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451), "System" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), true, "TechStart Inc", 3, new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451), "System" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), true, "Local Bakery", 2, new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451), "System" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), true, "City Health Department", 5, new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451), "System" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), true, "Green Earth Foundation", 4, new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451), "System" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), true, "Global Industries", 1, new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451), "System" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), true, "Innovate Labs", 3, new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451), "System" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), true, "Family Restaurant", 2, new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451), "System" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), true, "County Education Board", 5, new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451), "System" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), true, "Community Outreach", 4, new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451), "System" },
                    { new Guid("00000000-0000-0000-0000-000000000011"), true, "MegaCorp International", 1, new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451), "System" },
                    { new Guid("00000000-0000-0000-0000-000000000012"), true, "Future Tech", 3, new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451), "System" },
                    { new Guid("00000000-0000-0000-0000-000000000013"), true, "Neighborhood Cafe", 2, new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451), "System" },
                    { new Guid("00000000-0000-0000-0000-000000000014"), true, "State Transportation", 5, new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451), "System" },
                    { new Guid("00000000-0000-0000-0000-000000000015"), true, "Youth Development", 4, new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451), "System" },
                    { new Guid("00000000-0000-0000-0000-000000000016"), true, "Enterprise Solutions", 1, new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451), "System" },
                    { new Guid("00000000-0000-0000-0000-000000000017"), true, "NextGen Innovations", 3, new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451), "System" },
                    { new Guid("00000000-0000-0000-0000-000000000018"), true, "Artisan Crafts", 2, new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451), "System" },
                    { new Guid("00000000-0000-0000-0000-000000000019"), true, "Public Safety", 5, new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451), "System" },
                    { new Guid("00000000-0000-0000-0000-000000000020"), true, "Cultural Heritage", 4, new DateTime(2025, 6, 13, 15, 21, 59, 993, DateTimeKind.Utc).AddTicks(2451), "System" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "ClientTypes",
                keyColumn: "ClientTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClientTypes",
                keyColumn: "ClientTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClientTypes",
                keyColumn: "ClientTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ClientTypes",
                keyColumn: "ClientTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ClientTypes",
                keyColumn: "ClientTypeId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "PersonTypes",
                keyColumn: "PersonTypeId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "PersonTypes",
                keyColumn: "PersonTypeId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "PersonTypes",
                keyColumn: "PersonTypeId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "PersonTypes",
                keyColumn: "PersonTypeId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
        }
    }
}
