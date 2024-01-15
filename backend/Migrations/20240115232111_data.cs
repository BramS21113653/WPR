using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "ContactInfo", "Email", "EmailConfirmed", "FirstName", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType", "WebsiteURL" },
                values: new object[,]
                {
                    { new Guid("5dcefc08-f364-46b8-ac58-9e87938ccaf9"), 0, "Doe Innovations", "17cde92e-c2e9-4d9b-b790-1384b83b11f6", "john.doe@doeinnovations.com", "john.doe@doeinnovations.com", true, "John", "Doe", "New York, USA", false, null, "JOHN.DOE@DOEINNOVATIONS.COM", "JOHN.DOE", "hashed_password_placeholder", "123-456-7890", true, "security_stamp_placeholder", false, "john.doe", "BusinessUser", "https://www.doeinnovations.com" },
                    { new Guid("62f5a822-9367-4f5b-8335-02e11fc21174"), 0, "Smith Networking", "f7d032d1-cd4b-43c0-8c2c-89c0e46e8a7b", "jane.smith@smithnetworking.co.uk", "jane.smith@smithnetworking.co.uk", true, "Jane", "Smith", "London, UK", false, null, "JANE.SMITH@SMITHNETWORKING.CO.UK", "JANE.SMITH", "hashed_password_placeholder", "098-765-4321", true, "security_stamp_placeholder", false, "jane.smith", "BusinessUser", "https://www.smithnetworking.co.uk" },
                    { new Guid("c171a09f-9fd7-4b31-a350-c4e6b4f2a545"), 0, "Johnson AI Labs", "fa92b4ca-91a6-4671-bcdf-5260f3c75fd4", "alice.johnson@johnsonailabs.de", "alice.johnson@johnsonailabs.de", true, "Alice", "Johnson", "Berlin, Germany", false, null, "ALICE.JOHNSON@JOHNSONAILABS.DE", "ALICE.JOHNSON", "hashed_password_placeholder", "321-654-0987", true, "security_stamp_placeholder", false, "alice.johnson", "BusinessUser", "https://www.johnsonailabs.de" }
                });

            migrationBuilder.InsertData(
                table: "Researches",
                columns: new[] { "Id", "ConductorId", "DateTime", "Description", "LocationOnline", "ResearchType", "Reward", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("5b760850-c24f-457b-97aa-2d966e94072b"), new Guid("c171a09f-9fd7-4b31-a350-c4e6b4f2a545"), new DateTime(2024, 3, 16, 0, 21, 11, 59, DateTimeKind.Local).AddTicks(4910), "Analyzing sustainable practices in urban development", "WebEx", "Mixed", "150 USD Amazon Voucher", "Open", "Sustainable Urban Development" },
                    { new Guid("a22147f8-8a54-4ca6-ad66-34ecaa636696"), new Guid("62f5a822-9367-4f5b-8335-02e11fc21174"), new DateTime(2024, 2, 16, 0, 21, 11, 59, DateTimeKind.Local).AddTicks(4890), "Studying the latest trends in renewable energy technologies", "Microsoft Teams", "Quantitative", "Participation Certificate", "Planning", "Renewable Energy Innovations" },
                    { new Guid("a6ce7b40-5f15-4442-a6ff-1926817c4d09"), new Guid("5dcefc08-f364-46b8-ac58-9e87938ccaf9"), new DateTime(2024, 1, 16, 0, 21, 11, 59, DateTimeKind.Local).AddTicks(4810), "Exploring the impact of AI technologies in medical diagnostics", "Zoom Meeting", "Qualitative", "100 USD Amazon Voucher", "Open", "AI in Healthcare" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("5b760850-c24f-457b-97aa-2d966e94072b"));

            migrationBuilder.DeleteData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("a22147f8-8a54-4ca6-ad66-34ecaa636696"));

            migrationBuilder.DeleteData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("a6ce7b40-5f15-4442-a6ff-1926817c4d09"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5dcefc08-f364-46b8-ac58-9e87938ccaf9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("62f5a822-9367-4f5b-8335-02e11fc21174"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c171a09f-9fd7-4b31-a350-c4e6b4f2a545"));
        }
    }
}
