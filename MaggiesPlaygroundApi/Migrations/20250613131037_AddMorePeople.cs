using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MaggiesPlaygroundApi.Migrations
{
    /// <inheritdoc />
    public partial class AddMorePeople : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "Alias", "FirstName", "LastName" },
                values: new object[] { "mmorris", "Margaret", "Morris" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Alias", "CreatedDate", "DateOfBirth", "EnteredBy", "FirstName", "GenderId", "LastName", "MiddleName", "PersonTypeId", "Prefix", "RaceId", "Suffix" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000013"), "rwilson", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Robert", 1, "Wilson", "M", 1, null, 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "janderson", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1994, 2, 16, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Jennifer", 2, "Anderson", "N", 2, null, 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000015"), "dthomas", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1979, 3, 17, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Daniel", 1, "Thomas", "O", 3, null, 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000016"), "ltaylor", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1991, 4, 18, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Lisa", 2, "Taylor", "P", 4, null, 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000017"), "jmoore", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1985, 5, 19, 0, 0, 0, 0, DateTimeKind.Utc), "System", "James", 1, "Moore", "Q", 1, null, 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000018"), "mjackson", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1993, 6, 20, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Michelle", 2, "Jackson", "R", 2, null, 6, null },
                    { new Guid("00000000-0000-0000-0000-000000000019"), "amartin", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 7, 21, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Andrew", 1, "Martin", "S", 3, null, 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000020"), "slee", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1990, 8, 22, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Stephanie", 2, "Lee", "T", 4, null, 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000021"), "kthompson", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1984, 9, 23, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Kevin", 1, "Thompson", "U", 1, null, 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000022"), "nwhite", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 10, 24, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Nicole", 2, "White", "V", 2, null, 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000023"), "bharris", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1986, 11, 25, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Brian", 1, "Harris", "W", 3, null, 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000024"), "rclark", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1994, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Rachel", 2, "Clark", "X", 4, null, 6, null },
                    { new Guid("00000000-0000-0000-0000-000000000025"), "slewis", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1983, 1, 27, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Steven", 1, "Lewis", "Y", 1, null, 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000026"), "mrobinson", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1991, 2, 28, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Melissa", 2, "Robinson", "Z", 2, null, 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000027"), "twalker", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1988, 3, 29, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Timothy", 1, "Walker", "AA", 3, null, 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000028"), "kyoung", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1993, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Kimberly", 2, "Young", "AB", 4, null, 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000029"), "rallen", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1985, 5, 31, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Richard", 1, "Allen", "AC", 1, null, 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000030"), "lking", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1990, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Laura", 2, "King", "AD", 2, null, 6, null },
                    { new Guid("00000000-0000-0000-0000-000000000031"), "cwright", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Charles", 1, "Wright", "AE", 3, null, 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000032"), "hscott", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 8, 3, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Heather", 2, "Scott", "AF", 4, null, 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000033"), "jgreen", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1984, 9, 4, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Joseph", 1, "Green", "AG", 1, null, 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000034"), "ebaker", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1991, 10, 5, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Elizabeth", 2, "Baker", "AH", 2, null, 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000035"), "tadams", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1986, 11, 6, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Thomas", 1, "Adams", "AI", 3, null, 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000036"), "cnelson", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1993, 12, 7, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Christine", 2, "Nelson", "AJ", 4, null, 6, null },
                    { new Guid("00000000-0000-0000-0000-000000000037"), "pcarter", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1985, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Paul", 1, "Carter", "AK", 1, null, 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000038"), "smitchell", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1990, 2, 9, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Samantha", 2, "Mitchell", "AL", 2, null, 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000039"), "mperez", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 3, 10, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Mark", 1, "Perez", "AM", 3, null, 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000040"), "proberts", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 4, 11, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Patricia", 2, "Roberts", "AN", 4, null, 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000041"), "dturner", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1985, 5, 12, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Donald", 1, "Turner", "AO", 1, null, 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000042"), "nphillips", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1991, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Nancy", 2, "Phillips", "AP", 2, null, 6, null },
                    { new Guid("00000000-0000-0000-0000-000000000043"), "gcampbell", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1986, 7, 14, 0, 0, 0, 0, DateTimeKind.Utc), "System", "George", 1, "Campbell", "AQ", 3, null, 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000044"), "kparker", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1993, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Karen", 2, "Parker", "AR", 4, null, 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000045"), "eevans", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1984, 9, 16, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Edward", 1, "Evans", "AS", 1, null, 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000046"), "bedwards", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1990, 10, 17, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Betty", 2, "Edwards", "AT", 2, null, 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000047"), "wcollins", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 11, 18, 0, 0, 0, 0, DateTimeKind.Utc), "System", "William", 1, "Collins", "AU", 3, null, 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000048"), "hstewart", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 12, 19, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Helen", 2, "Stewart", "AV", 4, null, 6, null },
                    { new Guid("00000000-0000-0000-0000-000000000049"), "rsanchez", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1985, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Ronald", 1, "Sanchez", "AW", 1, null, 1, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"));

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "Alias", "FirstName", "LastName" },
                values: new object[] { "tyoung", "Taylor", "Young" });
        }
    }
}
