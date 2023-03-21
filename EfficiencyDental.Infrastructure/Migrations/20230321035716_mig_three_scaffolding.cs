using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EfficiencyDental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_three_scaffolding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "appointment_id",
                table: "users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "position_id",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "appointment_statuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    color = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_appointment_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "appointment_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_appointment_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "insurances",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_insurances", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "positions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_positions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_services", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    insured = table.Column<bool>(type: "boolean", nullable: false),
                    social_security_number = table.Column<string>(type: "text", nullable: false),
                    insurance_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_patients", x => x.id);
                    table.ForeignKey(
                        name: "fk_patients_insurances_insurance_id",
                        column: x => x.insurance_id,
                        principalTable: "insurances",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    start_time_utc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    length_in_minutes = table.Column<int>(type: "integer", nullable: false),
                    projected_end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    patient_id = table.Column<int>(type: "integer", nullable: false),
                    provider_id = table.Column<int>(type: "integer", nullable: false),
                    office_id = table.Column<int>(type: "integer", nullable: false),
                    room_id = table.Column<int>(type: "integer", nullable: false),
                    appointment_status_id = table.Column<int>(type: "integer", nullable: false),
                    appointment_type_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_appointments", x => x.id);
                    table.ForeignKey(
                        name: "fk_appointments_appointment_statuses_appointment_status_id",
                        column: x => x.appointment_status_id,
                        principalTable: "appointment_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_appointments_appointment_types_appointment_type_id",
                        column: x => x.appointment_type_id,
                        principalTable: "appointment_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_appointments_offices_office_id",
                        column: x => x.office_id,
                        principalTable: "offices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_appointments_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_appointments_rooms_room_id",
                        column: x => x.room_id,
                        principalTable: "rooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_appointments_users_provider_id",
                        column: x => x.provider_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_users_appointment_id",
                table: "users",
                column: "appointment_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_position_id",
                table: "users",
                column: "position_id");

            migrationBuilder.CreateIndex(
                name: "ix_appointments_appointment_status_id",
                table: "appointments",
                column: "appointment_status_id");

            migrationBuilder.CreateIndex(
                name: "ix_appointments_appointment_type_id",
                table: "appointments",
                column: "appointment_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_appointments_office_id",
                table: "appointments",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "ix_appointments_patient_id",
                table: "appointments",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "ix_appointments_provider_id",
                table: "appointments",
                column: "provider_id");

            migrationBuilder.CreateIndex(
                name: "ix_appointments_room_id",
                table: "appointments",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "ix_patients_insurance_id",
                table: "patients",
                column: "insurance_id");

            migrationBuilder.AddForeignKey(
                name: "fk_users_appointments_appointment_id",
                table: "users",
                column: "appointment_id",
                principalTable: "appointments",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_users_positions_position_id",
                table: "users",
                column: "position_id",
                principalTable: "positions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_appointments_appointment_id",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "fk_users_positions_position_id",
                table: "users");

            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "positions");

            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.DropTable(
                name: "appointment_statuses");

            migrationBuilder.DropTable(
                name: "appointment_types");

            migrationBuilder.DropTable(
                name: "patients");

            migrationBuilder.DropTable(
                name: "insurances");

            migrationBuilder.DropIndex(
                name: "ix_users_appointment_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_users_position_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "appointment_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "position_id",
                table: "users");
        }
    }
}
