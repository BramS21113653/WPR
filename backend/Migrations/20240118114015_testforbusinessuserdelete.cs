using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class testforbusinessuserdelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
