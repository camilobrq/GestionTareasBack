using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "states_data");

            migrationBuilder.EnsureSchema(
                name: "basic_data");

            migrationBuilder.EnsureSchema(
                name: "Auth");

            migrationBuilder.CreateTable(
                name: "StateTask",
                schema: "states_data",
                columns: table => new
                {
                    idStateTask = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    stateName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    stateDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateTask", x => x.idStateTask);
                });

            migrationBuilder.CreateTable(
                name: "TaskManager",
                schema: "basic_data",
                columns: table => new
                {
                    idTask = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    taskTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    idStateTask = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskManager", x => x.idTask);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Auth",
                columns: table => new
                {
                    idUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    role = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    email = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    name = table.Column<string>(type: "nvarchar(155)", maxLength: 155, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(155)", maxLength: 155, nullable: false),
                    identification = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    telephone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    address = table.Column<string>(type: "nvarchar(155)", maxLength: 155, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.idUser);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StateTask",
                schema: "states_data");

            migrationBuilder.DropTable(
                name: "TaskManager",
                schema: "basic_data");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Auth");
        }
    }
}
