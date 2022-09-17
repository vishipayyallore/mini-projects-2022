using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Server.Data.Migrations
{
    public partial class SeedCarData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cac43a6e-f7bb-4448-baaf-1add431ccbbf", "33c095b5-5b0e-4e0d-bb75-e605f29c32b1", "User", "USER" },
                    { "cbc43a8e-f7bb-4445-baaf-1add431ffbbf", "d1d71c0d-4f52-4742-ab19-b24dc025e9f3", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "72fb93b6-75c8-4489-9f00-38944d6fb8ba", "admin@localhost.com", false, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAEHM015SGm3YckA+g9gx4NR4Px47bN1KDiy7653yooG4jhIsslmD256/ZLRUPAkQBow==", null, false, "fce1bfc2-d1e7-4c3f-99d9-4678cededd30", false, "admin@localhost.com" },
                    { "9e224968-33e4-4652-b7b7-8574d048cdb9", 0, "8113adaf-45fb-4ada-839e-ecaa35a643cf", "user@localhost.com", false, "System", "User", false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAEAACcQAAAAEN2pgFaaxUUCcHRKR717E/XS0WU+gu1XoD8AS+wu4O2qtvnPhixYRuNkV+BYYgojLA==", null, false, "e4c44229-677d-4b4a-81c2-8be785b185f6", false, "user@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "Colours",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2022, 7, 21, 23, 35, 3, 545, DateTimeKind.Local).AddTicks(1661), new DateTime(2022, 7, 21, 23, 35, 3, 545, DateTimeKind.Local).AddTicks(1669), "Black", "System" },
                    { 2, "System", new DateTime(2022, 7, 21, 23, 35, 3, 545, DateTimeKind.Local).AddTicks(1671), new DateTime(2022, 7, 21, 23, 35, 3, 545, DateTimeKind.Local).AddTicks(1671), "Blue", "System" }
                });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2022, 7, 21, 23, 35, 3, 545, DateTimeKind.Local).AddTicks(1826), new DateTime(2022, 7, 21, 23, 35, 3, 545, DateTimeKind.Local).AddTicks(1827), "Toyota", "System" },
                    { 2, "System", new DateTime(2022, 7, 21, 23, 35, 3, 545, DateTimeKind.Local).AddTicks(1829), new DateTime(2022, 7, 21, 23, 35, 3, 545, DateTimeKind.Local).AddTicks(1829), "BMW", "System" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2022, 7, 21, 23, 35, 3, 545, DateTimeKind.Local).AddTicks(1886), new DateTime(2022, 7, 21, 23, 35, 3, 545, DateTimeKind.Local).AddTicks(1886), "Prius", "System" },
                    { 2, "System", new DateTime(2022, 7, 21, 23, 35, 3, 545, DateTimeKind.Local).AddTicks(1887), new DateTime(2022, 7, 21, 23, 35, 3, 545, DateTimeKind.Local).AddTicks(1888), "Vitz", "System" },
                    { 3, "System", new DateTime(2022, 7, 21, 23, 35, 3, 545, DateTimeKind.Local).AddTicks(1889), new DateTime(2022, 7, 21, 23, 35, 3, 545, DateTimeKind.Local).AddTicks(1889), "3 Series", "System" },
                    { 4, "System", new DateTime(2022, 7, 21, 23, 35, 3, 545, DateTimeKind.Local).AddTicks(1890), new DateTime(2022, 7, 21, 23, 35, 3, 545, DateTimeKind.Local).AddTicks(1890), "X5", "System" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cbc43a8e-f7bb-4445-baaf-1add431ffbbf", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cac43a6e-f7bb-4448-baaf-1add431ccbbf", "9e224968-33e4-4652-b7b7-8574d048cdb9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cbc43a8e-f7bb-4445-baaf-1add431ffbbf", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cac43a6e-f7bb-4448-baaf-1add431ccbbf", "9e224968-33e4-4652-b7b7-8574d048cdb9" });

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9");
        }
    }
}
