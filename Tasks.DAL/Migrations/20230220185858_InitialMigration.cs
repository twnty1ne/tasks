using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasks.DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancelDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentType = table.Column<byte>(type: "tinyint", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "CreateDate", "Name", "UpdateDate" },
                values: new object[] { new Guid("7e4e30ed-cd5d-454f-b236-49e5263b1765"), new DateTime(2023, 2, 20, 18, 58, 57, 771, DateTimeKind.Utc).AddTicks(2142), "Project1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "CreateDate", "Name", "UpdateDate" },
                values: new object[] { new Guid("ca4f2d5d-ea74-47b9-8485-ec387ef6620a"), new DateTime(2023, 2, 20, 18, 58, 57, 771, DateTimeKind.Utc).AddTicks(2818), "Project2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "CreateDate", "Name", "UpdateDate" },
                values: new object[] { new Guid("490fd8e7-f6e1-443b-8d20-1b8b7599c18b"), new DateTime(2023, 2, 20, 18, 58, 57, 771, DateTimeKind.Utc).AddTicks(2901), "Project3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CancelDate", "CreateDate", "EndDate", "Name", "ProjectId", "StartDate", "UpdateDate" },
                values: new object[] { new Guid("ae54910d-4e62-4121-a196-9d37c93a815d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 20, 18, 58, 57, 793, DateTimeKind.Utc).AddTicks(9266), new DateTime(2023, 2, 20, 19, 58, 57, 794, DateTimeKind.Utc).AddTicks(308), "Project1Task1", new Guid("7e4e30ed-cd5d-454f-b236-49e5263b1765"), new DateTime(2023, 2, 20, 18, 58, 57, 793, DateTimeKind.Utc).AddTicks(9752), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CancelDate", "CreateDate", "EndDate", "Name", "ProjectId", "StartDate", "UpdateDate" },
                values: new object[] { new Guid("cd0be526-1342-4669-b540-cf079ece407d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 20, 18, 58, 57, 794, DateTimeKind.Utc).AddTicks(1185), null, "Project1Task2", new Guid("7e4e30ed-cd5d-454f-b236-49e5263b1765"), new DateTime(2023, 2, 20, 18, 58, 57, 794, DateTimeKind.Utc).AddTicks(1610), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CancelDate", "CreateDate", "EndDate", "Name", "ProjectId", "StartDate", "UpdateDate" },
                values: new object[] { new Guid("8cb21350-fa5a-4506-a0f7-a9b4b1d79d91"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 20, 18, 58, 57, 794, DateTimeKind.Utc).AddTicks(1660), null, "Project2Task1", new Guid("ca4f2d5d-ea74-47b9-8485-ec387ef6620a"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentType", "Content", "TaskId" },
                values: new object[] { new Guid("a9d326a5-3517-4f3c-93d0-367ed94a0383"), (byte)5, new byte[] { 84, 97, 115, 107, 32, 99, 111, 110, 116, 101, 110, 116 }, new Guid("cd0be526-1342-4669-b540-cf079ece407d") });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TaskId",
                table: "Comments",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
