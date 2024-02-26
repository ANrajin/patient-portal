using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PatientPortal.Domain.Migrations
{
    /// <inheritdoc />
    public partial class CreateApplicationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiseaseInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NCDs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCDs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DiseaseInformationId = table.Column<int>(type: "int", nullable: false),
                    IsEpilepsy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_DiseaseInformations_DiseaseInformationId",
                        column: x => x.DiseaseInformationId,
                        principalTable: "DiseaseInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllergiesDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    AllergyId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergiesDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllergiesDetails_Allergies_AllergyId",
                        column: x => x.AllergyId,
                        principalTable: "Allergies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllergiesDetails_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NCDDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    NCDId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCDDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NCDDetails_NCDs_NCDId",
                        column: x => x.NCDId,
                        principalTable: "NCDs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NCDDetails_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Allergies",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 25, 11, 30, 0, 0, DateTimeKind.Utc), "Drugs - Penicillin", null },
                    { 2, new DateTime(2024, 2, 25, 11, 30, 0, 0, DateTimeKind.Utc), "Drug - Others", null },
                    { 3, new DateTime(2024, 2, 25, 11, 30, 0, 0, DateTimeKind.Utc), "Animals", null },
                    { 4, new DateTime(2024, 2, 25, 11, 30, 0, 0, DateTimeKind.Utc), "Food", null },
                    { 5, new DateTime(2024, 2, 25, 11, 30, 0, 0, DateTimeKind.Utc), "Oinments", null },
                    { 6, new DateTime(2024, 2, 25, 11, 30, 0, 0, DateTimeKind.Utc), "Plant", null },
                    { 7, new DateTime(2024, 2, 25, 11, 30, 0, 0, DateTimeKind.Utc), "Sprays", null },
                    { 8, new DateTime(2024, 2, 25, 11, 30, 0, 0, DateTimeKind.Utc), "Others", null },
                    { 9, new DateTime(2024, 2, 25, 11, 30, 0, 0, DateTimeKind.Utc), "No Allergies", null }
                });

            migrationBuilder.InsertData(
                table: "DiseaseInformations",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 25, 11, 30, 0, 0, DateTimeKind.Utc), "Hypertension", null },
                    { 2, new DateTime(2024, 2, 25, 11, 30, 0, 0, DateTimeKind.Utc), "Influenza", null },
                    { 3, new DateTime(2024, 2, 25, 11, 30, 0, 0, DateTimeKind.Utc), "Arthritis", null },
                    { 4, new DateTime(2024, 2, 25, 11, 30, 0, 0, DateTimeKind.Utc), "Migraine", null },
                    { 5, new DateTime(2024, 2, 25, 11, 30, 0, 0, DateTimeKind.Utc), "Coronary Artery Disease", null }
                });

            migrationBuilder.InsertData(
                table: "NCDs",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 25, 11, 30, 0, 0, DateTimeKind.Utc), "Asthma", null },
                    { 2, new DateTime(2024, 2, 25, 11, 30, 0, 0, DateTimeKind.Utc), "Cancer", null },
                    { 3, new DateTime(2024, 2, 25, 11, 30, 0, 0, DateTimeKind.Utc), "Disorders of ear", null },
                    { 4, new DateTime(2024, 2, 25, 11, 30, 0, 0, DateTimeKind.Utc), "Disorder of eye", null },
                    { 5, new DateTime(2024, 2, 25, 11, 30, 0, 0, DateTimeKind.Utc), "Mental illness", null },
                    { 6, new DateTime(2024, 2, 25, 11, 30, 0, 0, DateTimeKind.Utc), "Oral health problems", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllergiesDetails_AllergyId",
                table: "AllergiesDetails",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_AllergiesDetails_PatientId",
                table: "AllergiesDetails",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_NCDDetails_NCDId",
                table: "NCDDetails",
                column: "NCDId");

            migrationBuilder.CreateIndex(
                name: "IX_NCDDetails_PatientId",
                table: "NCDDetails",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DiseaseInformationId",
                table: "Patients",
                column: "DiseaseInformationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllergiesDetails");

            migrationBuilder.DropTable(
                name: "NCDDetails");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "NCDs");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "DiseaseInformations");
        }
    }
}
