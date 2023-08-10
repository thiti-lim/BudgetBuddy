using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetBuddy.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("3073bc1d-247d-4922-ad11-72784d252f5b"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("68b1110c-933e-43cc-b7c7-4f50457ab003"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("cfa920cb-811a-4631-a4e3-033cb91ffbcb"));

            migrationBuilder.AddColumn<Guid>(
                name: "User",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "User" },
                values: new object[] { new Guid("1bd98f53-59b1-4b82-835e-57326853e918"), "Test 3", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "User" },
                values: new object[] { new Guid("66a3f209-b0e3-4747-936d-ee46815b0094"), "Test 1", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "User" },
                values: new object[] { new Guid("a40649e2-b9af-41c9-966d-542145b93d48"), "Test 2", new Guid("00000000-0000-0000-0000-000000000000") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("1bd98f53-59b1-4b82-835e-57326853e918"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("66a3f209-b0e3-4747-936d-ee46815b0094"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("a40649e2-b9af-41c9-966d-542145b93d48"));

            migrationBuilder.DropColumn(
                name: "User",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("3073bc1d-247d-4922-ad11-72784d252f5b"), "Test 2" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("68b1110c-933e-43cc-b7c7-4f50457ab003"), "Test 3" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("cfa920cb-811a-4631-a4e3-033cb91ffbcb"), "Test 1" });
        }
    }
}
