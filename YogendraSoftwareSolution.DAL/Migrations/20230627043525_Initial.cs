using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YogendraSoftwareSolution.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Registration",
                columns: table => new
                {
                    RegId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "varchar(50)", nullable: true),
                    Gender = table.Column<string>(type: "varchar(20)", nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true),
                    Username = table.Column<string>(type: "varchar(50)", nullable: true),
                    PhonenNo = table.Column<string>(type: "varchar(12)", nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Registration", x => x.RegId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Registration");
        }
    }
}
