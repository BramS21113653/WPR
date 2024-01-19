using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class chatdto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("8598d02b-5023-464f-b450-4a596635428b"));

            migrationBuilder.DeleteData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("b504e1be-0149-41c2-9f9f-edc6f365eee2"));

            migrationBuilder.DeleteData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("ea3d7ae4-8086-4e3c-944d-a4b133301c57"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0a5cd29a-90b8-486b-93a0-7cd8bb11144e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("47b86695-6436-4b61-8638-4009df2d0dbc"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fd7a419-733b-4ac5-8705-e109e87885a5"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "ContactInfo", "Email", "EmailConfirmed", "FirstName", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType", "WebsiteURL" },
                values: new object[,]
                {
                    { new Guid("ae1db0b1-a5ae-46cf-a499-06f16a3e4893"), 0, "Doe Innovations", "93bf1f1e-5524-422f-9d66-61d50aac6928", "john.doe@doeinnovations.com", "john.doe@doeinnovations.com", true, "John", "Doe", "New York, USA", false, null, "JOHN.DOE@DOEINNOVATIONS.COM", "JOHN.DOE", "hashed_password_placeholder", "123-456-7890", true, "security_stamp_placeholder", false, "john.doe", "BusinessUser", "https://www.doeinnovations.com" },
                    { new Guid("dc2d32c9-3022-4c98-81c5-23e0d03c8148"), 0, "Smith Networking", "d38fa8ab-ed40-4aa0-bcf5-75c4343f8597", "jane.smith@smithnetworking.co.uk", "jane.smith@smithnetworking.co.uk", true, "Jane", "Smith", "London, UK", false, null, "JANE.SMITH@SMITHNETWORKING.CO.UK", "JANE.SMITH", "hashed_password_placeholder", "098-765-4321", true, "security_stamp_placeholder", false, "jane.smith", "BusinessUser", "https://www.smithnetworking.co.uk" },
                    { new Guid("ffa9a93a-5873-4f58-9f66-16f497963d7c"), 0, "Johnson AI Labs", "aaea58e0-37af-4b8a-8a99-fc623ce2a1a7", "alice.johnson@johnsonailabs.de", "alice.johnson@johnsonailabs.de", true, "Alice", "Johnson", "Berlin, Germany", false, null, "ALICE.JOHNSON@JOHNSONAILABS.DE", "ALICE.JOHNSON", "hashed_password_placeholder", "321-654-0987", true, "security_stamp_placeholder", false, "alice.johnson", "BusinessUser", "https://www.johnsonailabs.de" }
                });

            migrationBuilder.InsertData(
                table: "Researches",
                columns: new[] { "Id", "ConductorId", "DateTime", "Description", "LocationOnline", "ResearchType", "Reward", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("388e9510-7273-4506-976f-70638fae1214"), new Guid("ffa9a93a-5873-4f58-9f66-16f497963d7c"), new DateTime(2024, 3, 19, 23, 12, 56, 958, DateTimeKind.Local).AddTicks(5030), "Analyzing sustainable practices in urban development", "WebEx", "Mixed", "150 USD Amazon Voucher", "Open", "Sustainable Urban Development" },
                    { new Guid("40885c42-25ba-43ff-9cff-db66e9777590"), new Guid("ae1db0b1-a5ae-46cf-a499-06f16a3e4893"), new DateTime(2024, 1, 19, 23, 12, 56, 958, DateTimeKind.Local).AddTicks(4920), "Exploring the impact of AI technologies in medical diagnostics", "Zoom Meeting", "Qualitative", "100 USD Amazon Voucher", "Open", "AI in Healthcare" },
                    { new Guid("b573b166-ba7a-449e-8d4e-c1e4f8640a9d"), new Guid("dc2d32c9-3022-4c98-81c5-23e0d03c8148"), new DateTime(2024, 2, 19, 23, 12, 56, 958, DateTimeKind.Local).AddTicks(5010), "Studying the latest trends in renewable energy technologies", "Microsoft Teams", "Quantitative", "Participation Certificate", "Planning", "Renewable Energy Innovations" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("388e9510-7273-4506-976f-70638fae1214"));

            migrationBuilder.DeleteData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("40885c42-25ba-43ff-9cff-db66e9777590"));

            migrationBuilder.DeleteData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("b573b166-ba7a-449e-8d4e-c1e4f8640a9d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ae1db0b1-a5ae-46cf-a499-06f16a3e4893"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dc2d32c9-3022-4c98-81c5-23e0d03c8148"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ffa9a93a-5873-4f58-9f66-16f497963d7c"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "ContactInfo", "Email", "EmailConfirmed", "FirstName", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType", "WebsiteURL" },
                values: new object[,]
                {
                    { new Guid("0a5cd29a-90b8-486b-93a0-7cd8bb11144e"), 0, "Smith Networking", "498123e4-a632-41c4-b055-a247b7cf41f1", "jane.smith@smithnetworking.co.uk", "jane.smith@smithnetworking.co.uk", true, "Jane", "Smith", "London, UK", false, null, "JANE.SMITH@SMITHNETWORKING.CO.UK", "JANE.SMITH", "hashed_password_placeholder", "098-765-4321", true, "security_stamp_placeholder", false, "jane.smith", "BusinessUser", "https://www.smithnetworking.co.uk" },
                    { new Guid("47b86695-6436-4b61-8638-4009df2d0dbc"), 0, "Johnson AI Labs", "fcd9af5f-f966-47f8-9ba3-ac115158a975", "alice.johnson@johnsonailabs.de", "alice.johnson@johnsonailabs.de", true, "Alice", "Johnson", "Berlin, Germany", false, null, "ALICE.JOHNSON@JOHNSONAILABS.DE", "ALICE.JOHNSON", "hashed_password_placeholder", "321-654-0987", true, "security_stamp_placeholder", false, "alice.johnson", "BusinessUser", "https://www.johnsonailabs.de" },
                    { new Guid("6fd7a419-733b-4ac5-8705-e109e87885a5"), 0, "Doe Innovations", "5fca0cf6-d3a5-47c7-aadc-141441e953dd", "john.doe@doeinnovations.com", "john.doe@doeinnovations.com", true, "John", "Doe", "New York, USA", false, null, "JOHN.DOE@DOEINNOVATIONS.COM", "JOHN.DOE", "hashed_password_placeholder", "123-456-7890", true, "security_stamp_placeholder", false, "john.doe", "BusinessUser", "https://www.doeinnovations.com" }
                });

            migrationBuilder.InsertData(
                table: "Researches",
                columns: new[] { "Id", "ConductorId", "DateTime", "Description", "LocationOnline", "ResearchType", "Reward", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("8598d02b-5023-464f-b450-4a596635428b"), new Guid("47b86695-6436-4b61-8638-4009df2d0dbc"), new DateTime(2024, 3, 18, 12, 40, 15, 444, DateTimeKind.Local).AddTicks(6480), "Analyzing sustainable practices in urban development", "WebEx", "Mixed", "150 USD Amazon Voucher", "Open", "Sustainable Urban Development" },
                    { new Guid("b504e1be-0149-41c2-9f9f-edc6f365eee2"), new Guid("6fd7a419-733b-4ac5-8705-e109e87885a5"), new DateTime(2024, 1, 18, 12, 40, 15, 444, DateTimeKind.Local).AddTicks(6410), "Exploring the impact of AI technologies in medical diagnostics", "Zoom Meeting", "Qualitative", "100 USD Amazon Voucher", "Open", "AI in Healthcare" },
                    { new Guid("ea3d7ae4-8086-4e3c-944d-a4b133301c57"), new Guid("0a5cd29a-90b8-486b-93a0-7cd8bb11144e"), new DateTime(2024, 2, 18, 12, 40, 15, 444, DateTimeKind.Local).AddTicks(6470), "Studying the latest trends in renewable energy technologies", "Microsoft Teams", "Quantitative", "Participation Certificate", "Planning", "Renewable Energy Innovations" }
                });
        }
    }
}
