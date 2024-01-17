using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class IC4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("236553b4-e268-415d-905e-c4d83adbd8e8"));

            migrationBuilder.DeleteData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("c0a1e9fe-cc18-4a97-b160-7485a6d74a1b"));

            migrationBuilder.DeleteData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("c6459b44-8761-47fe-b881-7783cd0635e8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("174228f5-9184-4739-a10a-f3a362e36cfd"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3871df99-2192-47d9-853d-ead64de7b6e9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6ffe0405-43da-4b75-be7e-5718adf27ebb"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "ContactInfo", "Email", "EmailConfirmed", "FirstName", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType", "WebsiteURL" },
                values: new object[,]
                {
                    { new Guid("1a5d4693-ca01-4b11-9630-3b0392f4789c"), 0, "Doe Innovations", "cecafb2e-4d6f-47a6-9cd7-3aa3feded08a", "john.doe@doeinnovations.com", "john.doe@doeinnovations.com", true, "John", "Doe", "New York, USA", false, null, "JOHN.DOE@DOEINNOVATIONS.COM", "JOHN.DOE", "hashed_password_placeholder", "123-456-7890", true, "security_stamp_placeholder", false, "john.doe", "BusinessUser", "https://www.doeinnovations.com" },
                    { new Guid("8b0d3278-8875-46fa-8ae7-e8ba87f0e3ab"), 0, "Smith Networking", "247882f1-7095-4376-a42c-2b9d062d3b8b", "jane.smith@smithnetworking.co.uk", "jane.smith@smithnetworking.co.uk", true, "Jane", "Smith", "London, UK", false, null, "JANE.SMITH@SMITHNETWORKING.CO.UK", "JANE.SMITH", "hashed_password_placeholder", "098-765-4321", true, "security_stamp_placeholder", false, "jane.smith", "BusinessUser", "https://www.smithnetworking.co.uk" },
                    { new Guid("c7252408-3a93-472d-bc45-a55575cd3477"), 0, "Johnson AI Labs", "8708e55b-cef5-4049-986e-7478e39267ee", "alice.johnson@johnsonailabs.de", "alice.johnson@johnsonailabs.de", true, "Alice", "Johnson", "Berlin, Germany", false, null, "ALICE.JOHNSON@JOHNSONAILABS.DE", "ALICE.JOHNSON", "hashed_password_placeholder", "321-654-0987", true, "security_stamp_placeholder", false, "alice.johnson", "BusinessUser", "https://www.johnsonailabs.de" }
                });

            migrationBuilder.InsertData(
                table: "Researches",
                columns: new[] { "Id", "ConductorId", "DateTime", "Description", "LocationOnline", "ResearchType", "Reward", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("70bbaa63-a66d-4215-befa-9a444a958638"), new Guid("c7252408-3a93-472d-bc45-a55575cd3477"), new DateTime(2024, 3, 17, 18, 26, 9, 495, DateTimeKind.Local).AddTicks(5910), "Analyzing sustainable practices in urban development", "WebEx", "Mixed", "150 USD Amazon Voucher", "Open", "Sustainable Urban Development" },
                    { new Guid("a848b2ff-8812-44a4-a225-4d4a18ca2dff"), new Guid("8b0d3278-8875-46fa-8ae7-e8ba87f0e3ab"), new DateTime(2024, 2, 17, 18, 26, 9, 495, DateTimeKind.Local).AddTicks(5890), "Studying the latest trends in renewable energy technologies", "Microsoft Teams", "Quantitative", "Participation Certificate", "Planning", "Renewable Energy Innovations" },
                    { new Guid("bde37409-bf63-40e7-91f4-f995eee857ac"), new Guid("1a5d4693-ca01-4b11-9630-3b0392f4789c"), new DateTime(2024, 1, 17, 18, 26, 9, 495, DateTimeKind.Local).AddTicks(5820), "Exploring the impact of AI technologies in medical diagnostics", "Zoom Meeting", "Qualitative", "100 USD Amazon Voucher", "Open", "AI in Healthcare" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("70bbaa63-a66d-4215-befa-9a444a958638"));

            migrationBuilder.DeleteData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("a848b2ff-8812-44a4-a225-4d4a18ca2dff"));

            migrationBuilder.DeleteData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("bde37409-bf63-40e7-91f4-f995eee857ac"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a5d4693-ca01-4b11-9630-3b0392f4789c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8b0d3278-8875-46fa-8ae7-e8ba87f0e3ab"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c7252408-3a93-472d-bc45-a55575cd3477"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "ContactInfo", "Email", "EmailConfirmed", "FirstName", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType", "WebsiteURL" },
                values: new object[,]
                {
                    { new Guid("174228f5-9184-4739-a10a-f3a362e36cfd"), 0, "Doe Innovations", "744fb506-2443-4831-b383-b24822536bef", "john.doe@doeinnovations.com", "john.doe@doeinnovations.com", true, "John", "Doe", "New York, USA", false, null, "JOHN.DOE@DOEINNOVATIONS.COM", "JOHN.DOE", "hashed_password_placeholder", "123-456-7890", true, "security_stamp_placeholder", false, "john.doe", "BusinessUser", "https://www.doeinnovations.com" },
                    { new Guid("3871df99-2192-47d9-853d-ead64de7b6e9"), 0, "Smith Networking", "50a0f8af-34a6-4eef-9d36-86f2ee8c0e38", "jane.smith@smithnetworking.co.uk", "jane.smith@smithnetworking.co.uk", true, "Jane", "Smith", "London, UK", false, null, "JANE.SMITH@SMITHNETWORKING.CO.UK", "JANE.SMITH", "hashed_password_placeholder", "098-765-4321", true, "security_stamp_placeholder", false, "jane.smith", "BusinessUser", "https://www.smithnetworking.co.uk" },
                    { new Guid("6ffe0405-43da-4b75-be7e-5718adf27ebb"), 0, "Johnson AI Labs", "ebbf4963-c56f-4ae0-98c1-33dd91ea5ff9", "alice.johnson@johnsonailabs.de", "alice.johnson@johnsonailabs.de", true, "Alice", "Johnson", "Berlin, Germany", false, null, "ALICE.JOHNSON@JOHNSONAILABS.DE", "ALICE.JOHNSON", "hashed_password_placeholder", "321-654-0987", true, "security_stamp_placeholder", false, "alice.johnson", "BusinessUser", "https://www.johnsonailabs.de" }
                });

            migrationBuilder.InsertData(
                table: "Researches",
                columns: new[] { "Id", "ConductorId", "DateTime", "Description", "LocationOnline", "ResearchType", "Reward", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("236553b4-e268-415d-905e-c4d83adbd8e8"), new Guid("3871df99-2192-47d9-853d-ead64de7b6e9"), new DateTime(2024, 2, 17, 18, 23, 43, 658, DateTimeKind.Local).AddTicks(2250), "Studying the latest trends in renewable energy technologies", "Microsoft Teams", "Quantitative", "Participation Certificate", "Planning", "Renewable Energy Innovations" },
                    { new Guid("c0a1e9fe-cc18-4a97-b160-7485a6d74a1b"), new Guid("6ffe0405-43da-4b75-be7e-5718adf27ebb"), new DateTime(2024, 3, 17, 18, 23, 43, 658, DateTimeKind.Local).AddTicks(2270), "Analyzing sustainable practices in urban development", "WebEx", "Mixed", "150 USD Amazon Voucher", "Open", "Sustainable Urban Development" },
                    { new Guid("c6459b44-8761-47fe-b881-7783cd0635e8"), new Guid("174228f5-9184-4739-a10a-f3a362e36cfd"), new DateTime(2024, 1, 17, 18, 23, 43, 658, DateTimeKind.Local).AddTicks(2160), "Exploring the impact of AI technologies in medical diagnostics", "Zoom Meeting", "Qualitative", "100 USD Amazon Voucher", "Open", "AI in Healthcare" }
                });
        }
    }
}
