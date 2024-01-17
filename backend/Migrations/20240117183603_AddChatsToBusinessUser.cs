using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AddChatsToBusinessUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_AspNetUsers_BusinessUserId",
                table: "Chats");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_AspNetUsers_BusinessUserId",
                table: "Chats",
                column: "BusinessUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_AspNetUsers_BusinessUserId",
                table: "Chats");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_AspNetUsers_BusinessUserId",
                table: "Chats",
                column: "BusinessUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
