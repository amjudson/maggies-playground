using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaggiesPlaygroundApi.Migrations
{
    /// <inheritdoc />
    public partial class FixPersonTypeClientRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonTypes_Clients_ClientId1",
                table: "PersonTypes");

            migrationBuilder.DropIndex(
                name: "IX_PersonTypes_ClientId1",
                table: "PersonTypes");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "PersonTypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClientId1",
                table: "PersonTypes",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "PersonTypes",
                keyColumn: "PersonTypeId",
                keyValue: 1,
                column: "ClientId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "PersonTypes",
                keyColumn: "PersonTypeId",
                keyValue: 2,
                column: "ClientId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "PersonTypes",
                keyColumn: "PersonTypeId",
                keyValue: 3,
                column: "ClientId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "PersonTypes",
                keyColumn: "PersonTypeId",
                keyValue: 4,
                column: "ClientId1",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_PersonTypes_ClientId1",
                table: "PersonTypes",
                column: "ClientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonTypes_Clients_ClientId1",
                table: "PersonTypes",
                column: "ClientId1",
                principalTable: "Clients",
                principalColumn: "ClientId");
        }
    }
}
