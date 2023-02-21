using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasks.DAL.Migrations
{
    public partial class UpdateSeedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("a9d326a5-3517-4f3c-93d0-367ed94a0383"));

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: new Guid("490fd8e7-f6e1-443b-8d20-1b8b7599c18b"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("8cb21350-fa5a-4506-a0f7-a9b4b1d79d91"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("ae54910d-4e62-4121-a196-9d37c93a815d"));

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentType", "Content", "TaskId" },
                values: new object[] { new Guid("cfcf0b99-a7eb-423d-9a2f-d95e60268f2d"), (byte)5, new byte[] { 84, 97, 115, 107, 32, 99, 111, 110, 116, 101, 110, 116 }, new Guid("cd0be526-1342-4669-b540-cf079ece407d") });

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: new Guid("7e4e30ed-cd5d-454f-b236-49e5263b1765"),
                column: "CreateDate",
                value: new DateTime(2023, 2, 21, 12, 43, 29, 296, DateTimeKind.Utc).AddTicks(9025));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: new Guid("ca4f2d5d-ea74-47b9-8485-ec387ef6620a"),
                column: "CreateDate",
                value: new DateTime(2023, 2, 21, 12, 43, 29, 296, DateTimeKind.Utc).AddTicks(9631));

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "CreateDate", "Name", "UpdateDate" },
                values: new object[] { new Guid("928b4863-b1d7-45c7-9e36-a218313b5fb1"), new DateTime(2023, 2, 21, 12, 43, 29, 296, DateTimeKind.Utc).AddTicks(9721), "Project3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("cd0be526-1342-4669-b540-cf079ece407d"),
                columns: new[] { "CreateDate", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 21, 12, 43, 29, 324, DateTimeKind.Utc).AddTicks(3006), new DateTime(2023, 2, 21, 12, 43, 29, 324, DateTimeKind.Utc).AddTicks(2797), new DateTime(2023, 2, 21, 12, 43, 29, 324, DateTimeKind.Utc).AddTicks(2752) });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CancelDate", "CreateDate", "EndDate", "Name", "ProjectId", "StartDate", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("7e4e30ed-cd5d-454f-b236-49e5263b1765"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 21, 12, 43, 29, 322, DateTimeKind.Utc).AddTicks(6823), new DateTime(2023, 2, 21, 13, 43, 29, 320, DateTimeKind.Utc).AddTicks(9377), "Project1Task1", new Guid("7e4e30ed-cd5d-454f-b236-49e5263b1765"), new DateTime(2023, 2, 21, 12, 43, 29, 320, DateTimeKind.Utc).AddTicks(9240), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("10c05605-20db-4720-bdab-e87c3b7ccb50"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 21, 12, 43, 29, 324, DateTimeKind.Utc).AddTicks(3892), null, "Project2Task1", new Guid("ca4f2d5d-ea74-47b9-8485-ec387ef6620a"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("cfcf0b99-a7eb-423d-9a2f-d95e60268f2d"));

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: new Guid("928b4863-b1d7-45c7-9e36-a218313b5fb1"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("10c05605-20db-4720-bdab-e87c3b7ccb50"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("7e4e30ed-cd5d-454f-b236-49e5263b1765"));

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentType", "Content", "TaskId" },
                values: new object[] { new Guid("a9d326a5-3517-4f3c-93d0-367ed94a0383"), (byte)5, new byte[] { 84, 97, 115, 107, 32, 99, 111, 110, 116, 101, 110, 116 }, new Guid("cd0be526-1342-4669-b540-cf079ece407d") });

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: new Guid("7e4e30ed-cd5d-454f-b236-49e5263b1765"),
                column: "CreateDate",
                value: new DateTime(2023, 2, 20, 18, 58, 57, 771, DateTimeKind.Utc).AddTicks(2142));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: new Guid("ca4f2d5d-ea74-47b9-8485-ec387ef6620a"),
                column: "CreateDate",
                value: new DateTime(2023, 2, 20, 18, 58, 57, 771, DateTimeKind.Utc).AddTicks(2818));

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "CreateDate", "Name", "UpdateDate" },
                values: new object[] { new Guid("490fd8e7-f6e1-443b-8d20-1b8b7599c18b"), new DateTime(2023, 2, 20, 18, 58, 57, 771, DateTimeKind.Utc).AddTicks(2901), "Project3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("cd0be526-1342-4669-b540-cf079ece407d"),
                columns: new[] { "CreateDate", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 20, 18, 58, 57, 794, DateTimeKind.Utc).AddTicks(1185), null, new DateTime(2023, 2, 20, 18, 58, 57, 794, DateTimeKind.Utc).AddTicks(1610) });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CancelDate", "CreateDate", "EndDate", "Name", "ProjectId", "StartDate", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("ae54910d-4e62-4121-a196-9d37c93a815d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 20, 18, 58, 57, 793, DateTimeKind.Utc).AddTicks(9266), new DateTime(2023, 2, 20, 19, 58, 57, 794, DateTimeKind.Utc).AddTicks(308), "Project1Task1", new Guid("7e4e30ed-cd5d-454f-b236-49e5263b1765"), new DateTime(2023, 2, 20, 18, 58, 57, 793, DateTimeKind.Utc).AddTicks(9752), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8cb21350-fa5a-4506-a0f7-a9b4b1d79d91"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 20, 18, 58, 57, 794, DateTimeKind.Utc).AddTicks(1660), null, "Project2Task1", new Guid("ca4f2d5d-ea74-47b9-8485-ec387ef6620a"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
