using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EfficiencyDental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "practices",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_practices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "office",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    practice_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_office", x => x.id);
                    table.ForeignKey(
                        name: "fk_office_practices_practice_id",
                        column: x => x.practice_id,
                        principalTable: "practices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    employee_number = table.Column<string>(type: "text", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    user_type_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_user_type_user_type_id",
                        column: x => x.user_type_id,
                        principalTable: "user_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "room",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    office_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_room", x => x.id);
                    table.ForeignKey(
                        name: "fk_room_office_office_id",
                        column: x => x.office_id,
                        principalTable: "office",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "office_user",
                columns: table => new
                {
                    offices_id = table.Column<int>(type: "integer", nullable: false),
                    users_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_office_user", x => new { x.offices_id, x.users_id });
                    table.ForeignKey(
                        name: "fk_office_user_office_offices_id",
                        column: x => x.offices_id,
                        principalTable: "office",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_office_user_user_users_id",
                        column: x => x.users_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_office_practice_id",
                table: "office",
                column: "practice_id");

            migrationBuilder.CreateIndex(
                name: "ix_office_user_users_id",
                table: "office_user",
                column: "users_id");

            migrationBuilder.CreateIndex(
                name: "ix_room_office_id",
                table: "room",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_user_type_id",
                table: "user",
                column: "user_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "office_user");

            migrationBuilder.DropTable(
                name: "room");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "office");

            migrationBuilder.DropTable(
                name: "user_type");

            migrationBuilder.DropTable(
                name: "practices");
        }
    }
}
