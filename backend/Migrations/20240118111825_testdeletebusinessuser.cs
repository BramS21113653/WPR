using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class testdeletebusinessuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("0a35304d-ac82-4aa1-8fd1-8b559fd5647e"), 0, "Johnson AI Labs", "ecebd40c-3b57-48d9-a788-3be91eddc313", "alice.johnson@johnsonailabs.de", "alice.johnson@johnsonailabs.de", true, "Alice", "Johnson", "Berlin, Germany", false, null, "ALICE.JOHNSON@JOHNSONAILABS.DE", "ALICE.JOHNSON", "hashed_password_placeholder", "321-654-0987", true, "security_stamp_placeholder", false, "alice.johnson", "BusinessUser", "https://www.johnsonailabs.de" },
                    { new Guid("24d6613c-29f0-4d1f-8a3a-e0f3bcb575b4"), 0, "Smith Networking", "6ed6ea19-df84-4dab-83fe-3044e77ac8d4", "jane.smith@smithnetworking.co.uk", "jane.smith@smithnetworking.co.uk", true, "Jane", "Smith", "London, UK", false, null, "JANE.SMITH@SMITHNETWORKING.CO.UK", "JANE.SMITH", "hashed_password_placeholder", "098-765-4321", true, "security_stamp_placeholder", false, "jane.smith", "BusinessUser", "https://www.smithnetworking.co.uk" },
                    { new Guid("cf46fba3-96ac-449a-a8a3-c4800e930cae"), 0, "Doe Innovations", "0618e418-eab1-4500-aae0-65ca48c11e1d", "john.doe@doeinnovations.com", "john.doe@doeinnovations.com", true, "John", "Doe", "New York, USA", false, null, "JOHN.DOE@DOEINNOVATIONS.COM", "JOHN.DOE", "hashed_password_placeholder", "123-456-7890", true, "security_stamp_placeholder", false, "john.doe", "BusinessUser", "https://www.doeinnovations.com" }
                });

            migrationBuilder.InsertData(
                table: "Researches",
                columns: new[] { "Id", "ConductorId", "DateTime", "Description", "LocationOnline", "ResearchType", "Reward", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("2574a50b-0f95-4f52-91ce-fd608a0bf1ad"), new Guid("24d6613c-29f0-4d1f-8a3a-e0f3bcb575b4"), new DateTime(2024, 2, 18, 12, 18, 24, 908, DateTimeKind.Local).AddTicks(2700), "Studying the latest trends in renewable energy technologies", "Microsoft Teams", "Quantitative", "Participation Certificate", "Planning", "Renewable Energy Innovations" },
                    { new Guid("c7b63247-43e5-4f1c-9617-775268aba152"), new Guid("0a35304d-ac82-4aa1-8fd1-8b559fd5647e"), new DateTime(2024, 3, 18, 12, 18, 24, 908, DateTimeKind.Local).AddTicks(2720), "Analyzing sustainable practices in urban development", "WebEx", "Mixed", "150 USD Amazon Voucher", "Open", "Sustainable Urban Development" },
                    { new Guid("c7cbef02-6ad9-48f0-9130-e3b524371e65"), new Guid("cf46fba3-96ac-449a-a8a3-c4800e930cae"), new DateTime(2024, 1, 18, 12, 18, 24, 908, DateTimeKind.Local).AddTicks(2610), "Exploring the impact of AI technologies in medical diagnostics", "Zoom Meeting", "Qualitative", "100 USD Amazon Voucher", "Open", "AI in Healthcare" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("2574a50b-0f95-4f52-91ce-fd608a0bf1ad"));

            migrationBuilder.DeleteData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("c7b63247-43e5-4f1c-9617-775268aba152"));

            migrationBuilder.DeleteData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("c7cbef02-6ad9-48f0-9130-e3b524371e65"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0a35304d-ac82-4aa1-8fd1-8b559fd5647e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("24d6613c-29f0-4d1f-8a3a-e0f3bcb575b4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cf46fba3-96ac-449a-a8a3-c4800e930cae"));

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
    }
}
