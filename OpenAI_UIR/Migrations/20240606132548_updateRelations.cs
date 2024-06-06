using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenAI_UIR.Migrations
{
    /// <inheritdoc />
    public partial class updateRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Conversations_ConversationId",
                table: "Questions");

            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("b974bcc6-3c72-4e22-9ad8-2a31551756ad"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ConversationId",
                table: "Questions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CreatedAt", "Name", "Password", "UserName" },
                values: new object[] { new Guid("f8752470-e114-41ce-ab75-df6304df09c5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jobintech", "@Jobintech2024@", "jobintech@jobintech-uir.ma" });

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Conversations_ConversationId",
                table: "Questions",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Conversations_ConversationId",
                table: "Questions");

            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("f8752470-e114-41ce-ab75-df6304df09c5"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ConversationId",
                table: "Questions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CreatedAt", "Name", "Password", "UserName" },
                values: new object[] { new Guid("b974bcc6-3c72-4e22-9ad8-2a31551756ad"), new DateTime(2024, 6, 6, 12, 2, 15, 306, DateTimeKind.Utc).AddTicks(8930), "Jobintech", "@Jobintech2024@", "jobintech@jobintech-uir.ma" });

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Conversations_ConversationId",
                table: "Questions",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
