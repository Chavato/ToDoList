using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class relatecardwithuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "application_user_id",
                table: "card",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "ix_card_application_user_id",
                table: "card",
                column: "application_user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_card_users_application_user_id",
                table: "card",
                column: "application_user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_card_users_application_user_id",
                table: "card");

            migrationBuilder.DropIndex(
                name: "ix_card_application_user_id",
                table: "card");

            migrationBuilder.DropColumn(
                name: "application_user_id",
                table: "card");
        }
    }
}
