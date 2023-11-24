using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentLessonApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("22905372-470f-4b15-8876-f61b72691841"), "Java", "Programming languages1" },
                    { new Guid("23905372-470f-4b15-8876-f61b72691842"), "C#", "Programming languages2" },
                    { new Guid("24905372-470f-4b15-8876-f61b72691843"), "React Native and Flutter Frameworks", "Mobile App Development" },
                    { new Guid("25905372-470f-4b15-8876-f61b72691843"), "MicroServices", "Software Architectures" },
                    { new Guid("26905372-470f-4b15-8876-f61b72691843"), "Searching-Sorting Algorithms", "Data Structures and Algorithms" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FullName", "Password", "Phone", "UserName" },
                values: new object[,]
                {
                    { new Guid("72305372-470f-4b15-8876-f61b72691841"), "esra@gmail.com", "Esra Yaşın", "Esra.1", "05331545547", "esra" },
                    { new Guid("73305372-470f-4b15-8876-f61b72691843"), "mehmet@gmail.com", "Mehmet Kutlu", "Mehmet.1", "05551545547", "mehmet" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("22905372-470f-4b15-8876-f61b72691841"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("23905372-470f-4b15-8876-f61b72691842"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("24905372-470f-4b15-8876-f61b72691843"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("25905372-470f-4b15-8876-f61b72691843"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("26905372-470f-4b15-8876-f61b72691843"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("72305372-470f-4b15-8876-f61b72691841"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("73305372-470f-4b15-8876-f61b72691843"));
        }
    }
}
