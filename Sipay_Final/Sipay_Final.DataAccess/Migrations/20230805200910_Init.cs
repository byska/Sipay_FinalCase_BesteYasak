using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sipay_Final.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: true),
                    LastActivity = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Block = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    ApartmentNumber = table.Column<int>(type: "int", nullable: false),
                    Resident = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GasBill = table.Column<int>(type: "int", precision: 2, nullable: true),
                    ElectricityBill = table.Column<int>(type: "int", precision: 2, nullable: true),
                    WaterBill = table.Column<int>(type: "int", precision: 2, nullable: true),
                    Dues = table.Column<int>(type: "int", precision: 2, nullable: true),
                    BillDuesDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayInformations_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tc = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: true),
                    LastActivity = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageToAdmins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageToAdmins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageToAdmins_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageToAdmins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageToUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageToUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageToUsers_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageToUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "Firstname", "IsActive", "LastActivity", "Lastname", "ModifiedBy", "ModifiedDate", "Password", "Role" },
                values: new object[] { 1, "admin@gmail.com", new DateTime(2023, 8, 5, 20, 9, 9, 827, DateTimeKind.Utc).AddTicks(6072), null, null, "admin@gmail.com", "admin", true, null, "admin", null, null, "Lkxdh-(q)Pv+", 1 });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "ApartmentNumber", "Block", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Floor", "IsActive", "ModifiedBy", "ModifiedDate", "Resident", "Status", "Type" },
                values: new object[] { 1, 4, 1, "admin@gmail.com", new DateTime(2023, 8, 5, 20, 9, 9, 827, DateTimeKind.Utc).AddTicks(6270), null, null, 2, true, null, null, 2, 1, 2 });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "ApartmentNumber", "Block", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Floor", "IsActive", "ModifiedBy", "ModifiedDate", "Resident", "Status", "Type" },
                values: new object[] { 2, 2, 2, "admin@gmail.com", new DateTime(2023, 8, 5, 20, 9, 9, 827, DateTimeKind.Utc).AddTicks(6273), null, null, 1, true, null, null, 2, 1, 1 });

            migrationBuilder.InsertData(
                table: "PayInformations",
                columns: new[] { "Id", "ApartmentId", "BillDuesDate", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Dues", "ElectricityBill", "GasBill", "IsActive", "ModifiedBy", "ModifiedDate", "WaterBill" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2023, 8, 5, 20, 9, 9, 827, DateTimeKind.Utc).AddTicks(6286), "admin@gmail.com", new DateTime(2023, 8, 5, 20, 9, 9, 827, DateTimeKind.Utc).AddTicks(6289), null, null, 250, 200, 800, true, null, null, 150 },
                    { 2, 1, new DateTime(2023, 8, 5, 20, 9, 9, 827, DateTimeKind.Utc).AddTicks(6291), "admin@gmail.com", new DateTime(2023, 8, 5, 20, 9, 9, 827, DateTimeKind.Utc).AddTicks(6291), null, null, 300, 150, 600, true, null, null, 200 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ApartmentId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "Firstname", "IsActive", "LastActivity", "Lastname", "LicensePlate", "ModifiedBy", "ModifiedDate", "Password", "Phone", "Role", "Tc" },
                values: new object[,]
                {
                    { 1, 1, "admin@gmail.com", new DateTime(2023, 8, 5, 20, 9, 9, 827, DateTimeKind.Utc).AddTicks(6187), null, null, "johndoe@gmail.com", "John", true, null, "Doe", "34BY428", null, null, "Omdk_2j50Nud", "05342569312", 0, "23674356974" },
                    { 2, 2, "admin@gmail.com", new DateTime(2023, 8, 5, 20, 9, 9, 827, DateTimeKind.Utc).AddTicks(6198), null, null, "jeyndoe@gmail.com", "Jeyn", true, null, "Doe", null, null, null, "x&w%p10B4ww0", "05317241735", 0, "45832173821" }
                });

            migrationBuilder.InsertData(
                table: "MessageToAdmins",
                columns: new[] { "Id", "AdminId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsActive", "ModifiedBy", "ModifiedDate", "Status", "Text", "UserId" },
                values: new object[] { 1, 1, "johndoe@gmail.com", new DateTime(2023, 8, 5, 20, 9, 9, 827, DateTimeKind.Utc).AddTicks(6300), null, null, true, null, null, 2, "Hi,Our water pipe burst. Could you direct me to the plumber? ", 1 });

            migrationBuilder.InsertData(
                table: "MessageToUsers",
                columns: new[] { "Id", "AdminId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsActive", "ModifiedBy", "ModifiedDate", "Status", "Text", "UserId" },
                values: new object[] { 1, 1, "admin@gmail.com", new DateTime(2023, 8, 5, 20, 9, 9, 827, DateTimeKind.Utc).AddTicks(6308), null, null, true, null, null, 1, "Hi,please pay your bill.", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_MessageToAdmins_AdminId",
                table: "MessageToAdmins",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageToAdmins_UserId",
                table: "MessageToAdmins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageToUsers_AdminId",
                table: "MessageToUsers",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageToUsers_UserId",
                table: "MessageToUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PayInformations_ApartmentId",
                table: "PayInformations",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ApartmentId",
                table: "Users",
                column: "ApartmentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageToAdmins");

            migrationBuilder.DropTable(
                name: "MessageToUsers");

            migrationBuilder.DropTable(
                name: "PayInformations");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Apartments");
        }
    }
}
