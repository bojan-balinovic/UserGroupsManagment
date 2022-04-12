using Microsoft.EntityFrameworkCore.Migrations;

namespace UserGroupsManagment.Repository.Migrations
{
    public partial class groupfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_GroupEntityId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "GroupEntityId",
                table: "Users",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_GroupEntityId",
                table: "Users",
                newName: "IX_Users_GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_GroupId",
                table: "Users",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_GroupId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Users",
                newName: "GroupEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_GroupId",
                table: "Users",
                newName: "IX_Users_GroupEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_GroupEntityId",
                table: "Users",
                column: "GroupEntityId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
