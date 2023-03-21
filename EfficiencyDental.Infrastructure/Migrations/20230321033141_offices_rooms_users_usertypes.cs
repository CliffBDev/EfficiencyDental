using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfficiencyDental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class offices_rooms_users_usertypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_office_practices_practice_id",
                table: "office");

            migrationBuilder.DropForeignKey(
                name: "fk_office_user_office_offices_id",
                table: "office_user");

            migrationBuilder.DropForeignKey(
                name: "fk_office_user_user_users_id",
                table: "office_user");

            migrationBuilder.DropForeignKey(
                name: "fk_room_office_office_id",
                table: "room");

            migrationBuilder.DropForeignKey(
                name: "fk_user_user_type_user_type_id",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_type",
                table: "user_type");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "pk_room",
                table: "room");

            migrationBuilder.DropPrimaryKey(
                name: "pk_office",
                table: "office");

            migrationBuilder.RenameTable(
                name: "user_type",
                newName: "user_types");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "room",
                newName: "rooms");

            migrationBuilder.RenameTable(
                name: "office",
                newName: "offices");

            migrationBuilder.RenameIndex(
                name: "ix_user_user_type_id",
                table: "users",
                newName: "ix_users_user_type_id");

            migrationBuilder.RenameIndex(
                name: "ix_room_office_id",
                table: "rooms",
                newName: "ix_rooms_office_id");

            migrationBuilder.RenameIndex(
                name: "ix_office_practice_id",
                table: "offices",
                newName: "ix_offices_practice_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_types",
                table: "user_types",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_rooms",
                table: "rooms",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_offices",
                table: "offices",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_office_user_offices_offices_id",
                table: "office_user",
                column: "offices_id",
                principalTable: "offices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_office_user_users_users_id",
                table: "office_user",
                column: "users_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_offices_practices_practice_id",
                table: "offices",
                column: "practice_id",
                principalTable: "practices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_rooms_offices_office_id",
                table: "rooms",
                column: "office_id",
                principalTable: "offices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_users_user_types_user_type_id",
                table: "users",
                column: "user_type_id",
                principalTable: "user_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_office_user_offices_offices_id",
                table: "office_user");

            migrationBuilder.DropForeignKey(
                name: "fk_office_user_users_users_id",
                table: "office_user");

            migrationBuilder.DropForeignKey(
                name: "fk_offices_practices_practice_id",
                table: "offices");

            migrationBuilder.DropForeignKey(
                name: "fk_rooms_offices_office_id",
                table: "rooms");

            migrationBuilder.DropForeignKey(
                name: "fk_users_user_types_user_type_id",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_types",
                table: "user_types");

            migrationBuilder.DropPrimaryKey(
                name: "pk_rooms",
                table: "rooms");

            migrationBuilder.DropPrimaryKey(
                name: "pk_offices",
                table: "offices");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "user_types",
                newName: "user_type");

            migrationBuilder.RenameTable(
                name: "rooms",
                newName: "room");

            migrationBuilder.RenameTable(
                name: "offices",
                newName: "office");

            migrationBuilder.RenameIndex(
                name: "ix_users_user_type_id",
                table: "user",
                newName: "ix_user_user_type_id");

            migrationBuilder.RenameIndex(
                name: "ix_rooms_office_id",
                table: "room",
                newName: "ix_room_office_id");

            migrationBuilder.RenameIndex(
                name: "ix_offices_practice_id",
                table: "office",
                newName: "ix_office_practice_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user",
                table: "user",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_type",
                table: "user_type",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_room",
                table: "room",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_office",
                table: "office",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_office_practices_practice_id",
                table: "office",
                column: "practice_id",
                principalTable: "practices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_office_user_office_offices_id",
                table: "office_user",
                column: "offices_id",
                principalTable: "office",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_office_user_user_users_id",
                table: "office_user",
                column: "users_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_room_office_office_id",
                table: "room",
                column: "office_id",
                principalTable: "office",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_user_type_user_type_id",
                table: "user",
                column: "user_type_id",
                principalTable: "user_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
