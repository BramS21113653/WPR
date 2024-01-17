using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AdjustChatDeletion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("2e9e4e9c-5c19-4867-a2ff-985a195a6e6d"));

            migrationBuilder.DeleteData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("c71755de-4644-4f65-bf71-1264c456a83b"));

            migrationBuilder.DeleteData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("f39cfc15-ffe0-4fdb-9900-7d6a79e69cbd"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("157b83e2-a5a8-419c-a5b8-52db8b75d064"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2115639e-1e6f-401b-9f9e-f46c89e06de3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2dea9963-1eb5-410a-b363-e517a7613750"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "ContactInfo", "Email", "EmailConfirmed", "FirstName", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType", "WebsiteURL" },
                values: new object[,]
                {
                    { new Guid("0a5972dc-e689-4673-a7eb-dad2a2852020"), 0, "Johnson AI Labs", "66ab9dfa-2adc-48dd-9539-7ee682c8a5ae", "alice.johnson@johnsonailabs.de", "alice.johnson@johnsonailabs.de", true, "Alice", "Johnson", "Berlin, Germany", false, null, "ALICE.JOHNSON@JOHNSONAILABS.DE", "ALICE.JOHNSON", "hashed_password_placeholder", "321-654-0987", true, "security_stamp_placeholder", false, "alice.johnson", "BusinessUser", "https://www.johnsonailabs.de" },
                    { new Guid("8bbee4a9-c4a0-4caf-a4c7-7f9a48188932"), 0, "Smith Networking", "7601af6d-20df-4e8e-8e7a-a2cb2fd35e63", "jane.smith@smithnetworking.co.uk", "jane.smith@smithnetworking.co.uk", true, "Jane", "Smith", "London, UK", false, null, "JANE.SMITH@SMITHNETWORKING.CO.UK", "JANE.SMITH", "hashed_password_placeholder", "098-765-4321", true, "security_stamp_placeholder", false, "jane.smith", "BusinessUser", "https://www.smithnetworking.co.uk" },
                    { new Guid("b31db3b1-5f46-467d-bce8-e3bb5ce3d22f"), 0, "Doe Innovations", "3ff7339a-0af4-4909-ab46-1063f61800b8", "john.doe@doeinnovations.com", "john.doe@doeinnovations.com", true, "John", "Doe", "New York, USA", false, null, "JOHN.DOE@DOEINNOVATIONS.COM", "JOHN.DOE", "hashed_password_placeholder", "123-456-7890", true, "security_stamp_placeholder", false, "john.doe", "BusinessUser", "https://www.doeinnovations.com" }
                });

            migrationBuilder.InsertData(
                table: "Researches",
                columns: new[] { "Id", "ConductorId", "DateTime", "Description", "LocationOnline", "ResearchType", "Reward", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("162a297d-b578-4d63-96a6-e20297c409d7"), new Guid("b31db3b1-5f46-467d-bce8-e3bb5ce3d22f"), new DateTime(2024, 1, 17, 19, 44, 7, 872, DateTimeKind.Local).AddTicks(3820), "Exploring the impact of AI technologies in medical diagnostics", "Zoom Meeting", "Qualitative", "100 USD Amazon Voucher", "Open", "AI in Healthcare" },
                    { new Guid("e13ab0af-cc1f-4514-ad72-179d7511d3bd"), new Guid("0a5972dc-e689-4673-a7eb-dad2a2852020"), new DateTime(2024, 3, 17, 19, 44, 7, 872, DateTimeKind.Local).AddTicks(3980), "Analyzing sustainable practices in urban development", "WebEx", "Mixed", "150 USD Amazon Voucher", "Open", "Sustainable Urban Development" },
                    { new Guid("e588e0a1-68d7-4d6f-ad92-e4001142a471"), new Guid("8bbee4a9-c4a0-4caf-a4c7-7f9a48188932"), new DateTime(2024, 2, 17, 19, 44, 7, 872, DateTimeKind.Local).AddTicks(3930), "Studying the latest trends in renewable energy technologies", "Microsoft Teams", "Quantitative", "Participation Certificate", "Planning", "Renewable Energy Innovations" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("162a297d-b578-4d63-96a6-e20297c409d7"));

            migrationBuilder.DeleteData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("e13ab0af-cc1f-4514-ad72-179d7511d3bd"));

            migrationBuilder.DeleteData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("e588e0a1-68d7-4d6f-ad92-e4001142a471"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0a5972dc-e689-4673-a7eb-dad2a2852020"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8bbee4a9-c4a0-4caf-a4c7-7f9a48188932"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b31db3b1-5f46-467d-bce8-e3bb5ce3d22f"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "ContactInfo", "Email", "EmailConfirmed", "FirstName", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType", "WebsiteURL" },
                values: new object[,]
                {
                    { new Guid("157b83e2-a5a8-419c-a5b8-52db8b75d064"), 0, "Johnson AI Labs", "ec31c1e3-7b09-46eb-a119-72c0badbf0eb", "alice.johnson@johnsonailabs.de", "alice.johnson@johnsonailabs.de", true, "Alice", "Johnson", "Berlin, Germany", false, null, "ALICE.JOHNSON@JOHNSONAILABS.DE", "ALICE.JOHNSON", "hashed_password_placeholder", "321-654-0987", true, "security_stamp_placeholder", false, "alice.johnson", "BusinessUser", "https://www.johnsonailabs.de" },
                    { new Guid("2115639e-1e6f-401b-9f9e-f46c89e06de3"), 0, "Doe Innovations", "d529d343-7fe9-4cc3-8ac1-5f278d064d9e", "john.doe@doeinnovations.com", "john.doe@doeinnovations.com", true, "John", "Doe", "New York, USA", false, null, "JOHN.DOE@DOEINNOVATIONS.COM", "JOHN.DOE", "hashed_password_placeholder", "123-456-7890", true, "security_stamp_placeholder", false, "john.doe", "BusinessUser", "https://www.doeinnovations.com" },
                    { new Guid("2dea9963-1eb5-410a-b363-e517a7613750"), 0, "Smith Networking", "157b3b62-c0c1-4146-aa0d-3ed03620b96b", "jane.smith@smithnetworking.co.uk", "jane.smith@smithnetworking.co.uk", true, "Jane", "Smith", "London, UK", false, null, "JANE.SMITH@SMITHNETWORKING.CO.UK", "JANE.SMITH", "hashed_password_placeholder", "098-765-4321", true, "security_stamp_placeholder", false, "jane.smith", "BusinessUser", "https://www.smithnetworking.co.uk" }
                });

            migrationBuilder.InsertData(
                table: "Researches",
                columns: new[] { "Id", "ConductorId", "DateTime", "Description", "LocationOnline", "ResearchType", "Reward", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("2e9e4e9c-5c19-4867-a2ff-985a195a6e6d"), new Guid("2dea9963-1eb5-410a-b363-e517a7613750"), new DateTime(2024, 2, 17, 19, 36, 3, 452, DateTimeKind.Local).AddTicks(2690), "Studying the latest trends in renewable energy technologies", "Microsoft Teams", "Quantitative", "Participation Certificate", "Planning", "Renewable Energy Innovations" },
                    { new Guid("c71755de-4644-4f65-bf71-1264c456a83b"), new Guid("2115639e-1e6f-401b-9f9e-f46c89e06de3"), new DateTime(2024, 1, 17, 19, 36, 3, 452, DateTimeKind.Local).AddTicks(2570), "Exploring the impact of AI technologies in medical diagnostics", "Zoom Meeting", "Qualitative", "100 USD Amazon Voucher", "Open", "AI in Healthcare" },
                    { new Guid("f39cfc15-ffe0-4fdb-9900-7d6a79e69cbd"), new Guid("157b83e2-a5a8-419c-a5b8-52db8b75d064"), new DateTime(2024, 3, 17, 19, 36, 3, 452, DateTimeKind.Local).AddTicks(2740), "Analyzing sustainable practices in urban development", "WebEx", "Mixed", "150 USD Amazon Voucher", "Open", "Sustainable Urban Development" }
                });
        }
    }
}
