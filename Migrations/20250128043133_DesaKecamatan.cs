using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuskesosRazor.Migrations
{
    /// <inheritdoc />
    public partial class DesaKecamatan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d57ed467-ff24-4109-bc78-716a65a9306f");

            migrationBuilder.CreateTable(
                name: "Kecamatan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kecamatan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Desa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KecamatanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desa_Kecamatan_KecamatanId",
                        column: x => x.KecamatanId,
                        principalTable: "Kecamatan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d9490348-6b04-4190-a4c3-0ce01c8cb0cc", null, "BPJS", "BPJS" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash" },
                values: new object[] { "530c28ec-ac3a-433d-8fc8-2a085bdd4495", true, "AQAAAAIAAYagAAAAEM0qCqOmnSZtHOCLuG0xNR4RL/AMI9TwnjLk9l3lse+D0fumBOJ57ukRjJ4DdI97Hw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Desa_KecamatanId",
                table: "Desa",
                column: "KecamatanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desa");

            migrationBuilder.DropTable(
                name: "Kecamatan");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9490348-6b04-4190-a4c3-0ce01c8cb0cc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d57ed467-ff24-4109-bc78-716a65a9306f", null, "BPJS", "BPJS" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash" },
                values: new object[] { "a6d76f26-5033-4555-94b8-bd5040b3aa13", false, "AQAAAAIAAYagAAAAEPr8vwNBkj7lxiFSiwKPu1KSeu+dFJIJegfOR8Vb4eEybglor3O7hmElZJDdRhZRxw==" });
        }
    }
}
