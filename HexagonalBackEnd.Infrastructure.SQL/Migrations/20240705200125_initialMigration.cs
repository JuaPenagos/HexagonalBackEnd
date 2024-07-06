using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HexagonalBackEnd.Infrastructure.SQL.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RemunerationType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemunerationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AreaLeader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdArea = table.Column<int>(type: "int", nullable: false),
                    IdLeaderArea = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaLeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreaLeader_Area_IdArea",
                        column: x => x.IdArea,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: false),
                    IdRole = table.Column<int>(type: "int", nullable: false),
                    IdLeader = table.Column<int>(type: "int", nullable: true),
                    IdAreaLeader = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_AreaLeader_IdAreaLeader",
                        column: x => x.IdAreaLeader,
                        principalTable: "AreaLeader",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_Role_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryOvertime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOvertimeHours = table.Column<int>(type: "int", nullable: false),
                    IdStateInitial = table.Column<int>(type: "int", nullable: true),
                    IdStateFinal = table.Column<int>(type: "int", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: false),
                    IdApprover = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryOvertime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryOvertime_Employee_IdApprover",
                        column: x => x.IdApprover,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoryOvertime_Employee_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoryOvertime_State_IdStateFinal",
                        column: x => x.IdStateFinal,
                        principalTable: "State",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoryOvertime_State_IdStateInitial",
                        column: x => x.IdStateInitial,
                        principalTable: "State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OvertimeHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RemunerationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemunerationHours = table.Column<int>(type: "int", nullable: false),
                    Justification = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JustificationState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdEmployee = table.Column<int>(type: "int", nullable: false),
                    IdState = table.Column<int>(type: "int", nullable: false),
                    IdRemunerationType = table.Column<int>(type: "int", nullable: false),
                    IdApprover = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OvertimeHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OvertimeHours_Employee_IdApprover",
                        column: x => x.IdApprover,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OvertimeHours_Employee_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OvertimeHours_RemunerationType_IdRemunerationType",
                        column: x => x.IdRemunerationType,
                        principalTable: "RemunerationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OvertimeHours_State_IdState",
                        column: x => x.IdState,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaLeader_IdArea",
                table: "AreaLeader",
                column: "IdArea");

            migrationBuilder.CreateIndex(
                name: "IX_AreaLeader_IdLeaderArea",
                table: "AreaLeader",
                column: "IdLeaderArea",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_IdAreaLeader",
                table: "Employee",
                column: "IdAreaLeader");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_IdRole",
                table: "Employee",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryOvertime_IdApprover",
                table: "HistoryOvertime",
                column: "IdApprover");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryOvertime_IdEmployee",
                table: "HistoryOvertime",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryOvertime_IdStateFinal",
                table: "HistoryOvertime",
                column: "IdStateFinal");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryOvertime_IdStateInitial",
                table: "HistoryOvertime",
                column: "IdStateInitial");

            migrationBuilder.CreateIndex(
                name: "IX_OvertimeHours_IdApprover",
                table: "OvertimeHours",
                column: "IdApprover");

            migrationBuilder.CreateIndex(
                name: "IX_OvertimeHours_IdEmployee",
                table: "OvertimeHours",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_OvertimeHours_IdRemunerationType",
                table: "OvertimeHours",
                column: "IdRemunerationType");

            migrationBuilder.CreateIndex(
                name: "IX_OvertimeHours_IdState",
                table: "OvertimeHours",
                column: "IdState");

            migrationBuilder.AddForeignKey(
                name: "FK_AreaLeader_Employee_IdLeaderArea",
                table: "AreaLeader",
                column: "IdLeaderArea",
                principalTable: "Employee",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreaLeader_Area_IdArea",
                table: "AreaLeader");

            migrationBuilder.DropForeignKey(
                name: "FK_AreaLeader_Employee_IdLeaderArea",
                table: "AreaLeader");

            migrationBuilder.DropTable(
                name: "HistoryOvertime");

            migrationBuilder.DropTable(
                name: "OvertimeHours");

            migrationBuilder.DropTable(
                name: "RemunerationType");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "AreaLeader");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
