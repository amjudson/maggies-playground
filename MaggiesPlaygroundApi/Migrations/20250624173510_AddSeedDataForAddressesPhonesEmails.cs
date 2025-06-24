using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MaggiesPlaygroundApi.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataForAddressesPhonesEmails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "AddressLine1", "AddressLine2", "AddressTypeId", "AddressTypeId1", "City", "StateId", "StateId1", "Zip" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "110 Main Street", "Apt 1", 2, null, "City 1", 2, null, "10001" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "120 Main Street", "Apt 2", 3, null, "City 2", 3, null, "10002" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "130 Main Street", "Apt 3", 4, null, "City 3", 4, null, "10003" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "140 Main Street", "Apt 4", 5, null, "City 4", 5, null, "10004" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "150 Main Street", "Apt 5", 1, null, "City 5", 6, null, "10005" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "160 Main Street", "Apt 6", 2, null, "City 6", 7, null, "10006" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "170 Main Street", "Apt 7", 3, null, "City 7", 8, null, "10007" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "180 Main Street", "Apt 8", 4, null, "City 8", 9, null, "10008" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "190 Main Street", "Apt 9", 5, null, "City 9", 10, null, "10009" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "200 Main Street", "Apt 10", 1, null, "City 10", 11, null, "10010" },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "210 Main Street", "Apt 11", 2, null, "City 11", 12, null, "10011" },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "220 Main Street", "Apt 12", 3, null, "City 12", 13, null, "10012" },
                    { new Guid("00000000-0000-0000-0000-000000000013"), "230 Main Street", "Apt 13", 4, null, "City 13", 14, null, "10013" },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "240 Main Street", "Apt 14", 5, null, "City 14", 15, null, "10014" },
                    { new Guid("00000000-0000-0000-0000-000000000015"), "250 Main Street", "Apt 15", 1, null, "City 15", 16, null, "10015" },
                    { new Guid("00000000-0000-0000-0000-000000000016"), "260 Main Street", "Apt 16", 2, null, "City 16", 17, null, "10016" },
                    { new Guid("00000000-0000-0000-0000-000000000017"), "270 Main Street", "Apt 17", 3, null, "City 17", 18, null, "10017" },
                    { new Guid("00000000-0000-0000-0000-000000000018"), "280 Main Street", "Apt 18", 4, null, "City 18", 19, null, "10018" },
                    { new Guid("00000000-0000-0000-0000-000000000019"), "290 Main Street", "Apt 19", 5, null, "City 19", 20, null, "10019" },
                    { new Guid("00000000-0000-0000-0000-000000000020"), "300 Main Street", "Apt 20", 1, null, "City 20", 21, null, "10020" },
                    { new Guid("00000000-0000-0000-0000-000000000021"), "310 Main Street", "Apt 21", 2, null, "City 21", 22, null, "10021" },
                    { new Guid("00000000-0000-0000-0000-000000000022"), "320 Main Street", "Apt 22", 3, null, "City 22", 23, null, "10022" },
                    { new Guid("00000000-0000-0000-0000-000000000023"), "330 Main Street", "Apt 23", 4, null, "City 23", 24, null, "10023" },
                    { new Guid("00000000-0000-0000-0000-000000000024"), "340 Main Street", "Apt 24", 5, null, "City 24", 25, null, "10024" },
                    { new Guid("00000000-0000-0000-0000-000000000025"), "350 Main Street", "Apt 25", 1, null, "City 25", 26, null, "10025" },
                    { new Guid("00000000-0000-0000-0000-000000000026"), "360 Main Street", "Apt 26", 2, null, "City 26", 27, null, "10026" },
                    { new Guid("00000000-0000-0000-0000-000000000027"), "370 Main Street", "Apt 27", 3, null, "City 27", 28, null, "10027" },
                    { new Guid("00000000-0000-0000-0000-000000000028"), "380 Main Street", "Apt 28", 4, null, "City 28", 29, null, "10028" },
                    { new Guid("00000000-0000-0000-0000-000000000029"), "390 Main Street", "Apt 29", 5, null, "City 29", 30, null, "10029" },
                    { new Guid("00000000-0000-0000-0000-000000000030"), "400 Main Street", "Apt 30", 1, null, "City 30", 31, null, "10030" },
                    { new Guid("00000000-0000-0000-0000-000000000031"), "410 Main Street", null, 2, null, "City 31", 32, null, "10031" },
                    { new Guid("00000000-0000-0000-0000-000000000032"), "420 Main Street", null, 3, null, "City 32", 33, null, "10032" },
                    { new Guid("00000000-0000-0000-0000-000000000033"), "430 Main Street", null, 4, null, "City 33", 34, null, "10033" },
                    { new Guid("00000000-0000-0000-0000-000000000034"), "440 Main Street", null, 5, null, "City 34", 35, null, "10034" },
                    { new Guid("00000000-0000-0000-0000-000000000035"), "450 Main Street", null, 1, null, "City 35", 36, null, "10035" },
                    { new Guid("00000000-0000-0000-0000-000000000036"), "460 Main Street", null, 2, null, "City 36", 37, null, "10036" },
                    { new Guid("00000000-0000-0000-0000-000000000037"), "470 Main Street", null, 3, null, "City 37", 38, null, "10037" },
                    { new Guid("00000000-0000-0000-0000-000000000038"), "480 Main Street", null, 4, null, "City 38", 39, null, "10038" },
                    { new Guid("00000000-0000-0000-0000-000000000039"), "490 Main Street", null, 5, null, "City 39", 40, null, "10039" },
                    { new Guid("00000000-0000-0000-0000-000000000040"), "500 Main Street", null, 1, null, "City 40", 41, null, "10040" },
                    { new Guid("00000000-0000-0000-0000-000000000041"), "510 Main Street", null, 2, null, "City 41", 42, null, "10041" },
                    { new Guid("00000000-0000-0000-0000-000000000042"), "520 Main Street", null, 3, null, "City 42", 43, null, "10042" },
                    { new Guid("00000000-0000-0000-0000-000000000043"), "530 Main Street", null, 4, null, "City 43", 44, null, "10043" },
                    { new Guid("00000000-0000-0000-0000-000000000044"), "540 Main Street", null, 5, null, "City 44", 45, null, "10044" },
                    { new Guid("00000000-0000-0000-0000-000000000045"), "550 Main Street", null, 1, null, "City 45", 46, null, "10045" },
                    { new Guid("00000000-0000-0000-0000-000000000046"), "560 Main Street", null, 2, null, "City 46", 47, null, "10046" },
                    { new Guid("00000000-0000-0000-0000-000000000047"), "570 Main Street", null, 3, null, "City 47", 48, null, "10047" },
                    { new Guid("00000000-0000-0000-0000-000000000048"), "580 Main Street", null, 4, null, "City 48", 49, null, "10048" },
                    { new Guid("00000000-0000-0000-0000-000000000049"), "590 Main Street", null, 5, null, "City 49", 50, null, "10049" },
                    { new Guid("00000000-0000-0000-0000-000000000050"), "600 Main Street", null, 1, null, "City 50", 1, null, "10050" },
                    { new Guid("00000000-0000-0000-0000-000000000051"), "610 Main Street", null, 2, null, "City 51", 2, null, "10051" },
                    { new Guid("00000000-0000-0000-0000-000000000052"), "620 Main Street", null, 3, null, "City 52", 3, null, "10052" },
                    { new Guid("00000000-0000-0000-0000-000000000053"), "630 Main Street", null, 4, null, "City 53", 4, null, "10053" },
                    { new Guid("00000000-0000-0000-0000-000000000054"), "640 Main Street", null, 5, null, "City 54", 5, null, "10054" },
                    { new Guid("00000000-0000-0000-0000-000000000055"), "650 Main Street", null, 1, null, "City 55", 6, null, "10055" },
                    { new Guid("00000000-0000-0000-0000-000000000056"), "660 Main Street", null, 2, null, "City 56", 7, null, "10056" },
                    { new Guid("00000000-0000-0000-0000-000000000057"), "670 Main Street", null, 3, null, "City 57", 8, null, "10057" },
                    { new Guid("00000000-0000-0000-0000-000000000058"), "680 Main Street", null, 4, null, "City 58", 9, null, "10058" },
                    { new Guid("00000000-0000-0000-0000-000000000059"), "690 Main Street", null, 5, null, "City 59", 10, null, "10059" },
                    { new Guid("00000000-0000-0000-0000-000000000060"), "700 Main Street", null, 1, null, "City 60", 11, null, "10060" }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "EmailId", "EmailAddress", "EmailTypeId", "EmailTypeId1" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000201"), "user1@gmail.com", 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000202"), "user2@gmail.com", 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000203"), "user3@gmail.com", 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000204"), "user4@gmail.com", 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000205"), "user5@gmail.com", 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000206"), "user6@gmail.com", 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000207"), "user7@gmail.com", 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000208"), "user8@gmail.com", 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000209"), "user9@gmail.com", 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000210"), "user10@gmail.com", 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000211"), "user11@gmail.com", 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000212"), "user12@gmail.com", 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000213"), "user13@gmail.com", 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000214"), "user14@gmail.com", 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000215"), "user15@gmail.com", 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000216"), "user16@gmail.com", 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000217"), "user17@gmail.com", 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000218"), "user18@gmail.com", 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000219"), "user19@gmail.com", 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000220"), "user20@gmail.com", 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000221"), "user21@yahoo.com", 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000222"), "user22@yahoo.com", 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000223"), "user23@yahoo.com", 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000224"), "user24@yahoo.com", 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000225"), "user25@yahoo.com", 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000226"), "user26@yahoo.com", 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000227"), "user27@yahoo.com", 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000228"), "user28@yahoo.com", 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000229"), "user29@yahoo.com", 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000230"), "user30@yahoo.com", 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000231"), "user31@yahoo.com", 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000232"), "user32@yahoo.com", 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000233"), "user33@yahoo.com", 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000234"), "user34@yahoo.com", 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000235"), "user35@yahoo.com", 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000236"), "user36@yahoo.com", 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000237"), "user37@yahoo.com", 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000238"), "user38@yahoo.com", 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000239"), "user39@yahoo.com", 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000240"), "user40@yahoo.com", 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000241"), "user41@hotmail.com", 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000242"), "user42@hotmail.com", 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000243"), "user43@hotmail.com", 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000244"), "user44@hotmail.com", 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000245"), "user45@hotmail.com", 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000246"), "user46@hotmail.com", 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000247"), "user47@hotmail.com", 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000248"), "user48@hotmail.com", 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000249"), "user49@hotmail.com", 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000250"), "user50@hotmail.com", 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000251"), "user51@hotmail.com", 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000252"), "user52@hotmail.com", 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000253"), "user53@hotmail.com", 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000254"), "user54@hotmail.com", 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000255"), "user55@hotmail.com", 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000256"), "user56@hotmail.com", 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000257"), "user57@hotmail.com", 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000258"), "user58@hotmail.com", 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000259"), "user59@hotmail.com", 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000260"), "user60@hotmail.com", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "PhoneId", "Extension", "PhoneNumber", "PhoneTypeId", "PhoneTypeId1" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000101"), "1", "201-501-1010", 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000102"), "2", "202-502-1020", 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000103"), "3", "203-503-1030", 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000104"), "4", "204-504-1040", 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000105"), "5", "205-505-1050", 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000106"), "6", "206-506-1060", 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000107"), "7", "207-507-1070", 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000108"), "8", "208-508-1080", 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000109"), "9", "209-509-1090", 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000110"), "10", "210-510-1100", 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000111"), "11", "211-511-1110", 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000112"), "12", "212-512-1120", 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000113"), "13", "213-513-1130", 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000114"), "14", "214-514-1140", 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000115"), "15", "215-515-1150", 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000116"), "16", "216-516-1160", 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000117"), "17", "217-517-1170", 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000118"), "18", "218-518-1180", 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000119"), "19", "219-519-1190", 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000120"), "20", "220-520-1200", 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000121"), null, "221-521-1210", 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000122"), null, "222-522-1220", 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000123"), null, "223-523-1230", 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000124"), null, "224-524-1240", 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000125"), null, "225-525-1250", 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000126"), null, "226-526-1260", 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000127"), null, "227-527-1270", 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000128"), null, "228-528-1280", 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000129"), null, "229-529-1290", 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000130"), null, "230-530-1300", 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000131"), null, "231-531-1310", 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000132"), null, "232-532-1320", 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000133"), null, "233-533-1330", 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000134"), null, "234-534-1340", 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000135"), null, "235-535-1350", 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000136"), null, "236-536-1360", 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000137"), null, "237-537-1370", 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000138"), null, "238-538-1380", 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000139"), null, "239-539-1390", 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000140"), null, "240-540-1400", 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000141"), null, "241-541-1410", 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000142"), null, "242-542-1420", 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000143"), null, "243-543-1430", 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000144"), null, "244-544-1440", 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000145"), null, "245-545-1450", 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000146"), null, "246-546-1460", 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000147"), null, "247-547-1470", 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000148"), null, "248-548-1480", 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000149"), null, "249-549-1490", 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000150"), null, "250-550-1500", 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000151"), null, "251-551-1510", 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000152"), null, "252-552-1520", 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000153"), null, "253-553-1530", 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000154"), null, "254-554-1540", 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000155"), null, "255-555-1550", 1, null },
                    { new Guid("00000000-0000-0000-0000-000000000156"), null, "256-556-1560", 2, null },
                    { new Guid("00000000-0000-0000-0000-000000000157"), null, "257-557-1570", 3, null },
                    { new Guid("00000000-0000-0000-0000-000000000158"), null, "258-558-1580", 4, null },
                    { new Guid("00000000-0000-0000-0000-000000000159"), null, "259-559-1590", 5, null },
                    { new Guid("00000000-0000-0000-0000-000000000160"), null, "260-560-1600", 1, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000201"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000202"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000203"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000204"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000205"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000206"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000207"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000208"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000209"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000210"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000211"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000212"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000213"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000214"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000215"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000216"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000217"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000218"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000219"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000220"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000221"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000222"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000223"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000224"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000225"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000226"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000227"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000228"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000229"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000230"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000231"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000232"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000233"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000234"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000235"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000236"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000237"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000238"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000239"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000240"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000241"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000242"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000243"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000244"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000245"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000246"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000247"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000248"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000249"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000250"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000251"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000252"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000253"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000254"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000255"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000256"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000257"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000258"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000259"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000260"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000121"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000122"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000123"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000124"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000125"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000126"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000127"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000128"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000129"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000130"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000131"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000132"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000133"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000134"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000135"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000136"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000137"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000138"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000139"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000140"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000141"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000142"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000143"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000144"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000145"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000146"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000147"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000148"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000149"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000150"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000151"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000152"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000153"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000154"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000155"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000156"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000157"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000158"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000159"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "PhoneId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000160"));
        }
    }
}
