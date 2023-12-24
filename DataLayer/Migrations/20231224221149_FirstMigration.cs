using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "basic_data");

            migrationBuilder.EnsureSchema(
                name: "states_data");

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "basic_data",
                columns: table => new
                {
                    idPerson = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    email = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    cellPhone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.idPerson);
                });

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
                    priority = table.Column<int>(type: "int", nullable: false),
                    idUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskManager", x => x.idTask);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "basic_data",
                columns: table => new
                {
                    idPerson = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.idPerson);
                    table.ForeignKey(
                        name: "FK_User_Person_idPerson",
                        column: x => x.idPerson,
                        principalSchema: "basic_data",
                        principalTable: "Person",
                        principalColumn: "idPerson",
                        onDelete: ReferentialAction.Cascade);
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
                schema: "basic_data");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "basic_data");
        }
    }
}
