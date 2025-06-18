using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kirusha_crud_asp.net.Migrations
{
    /// <inheritdoc />
    public partial class DentistSetNullOnDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Appointment_dentist_id",
                table: "Appointment",
                column: "dentist_id");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_patient_id",
                table: "Appointment",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_treatment_id",
                table: "Appointment",
                column: "treatment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Dentist_dentist_id",
                table: "Appointment",
                column: "dentist_id",
                principalTable: "Dentist",
                principalColumn: "dentist_id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Patient_patient_id",
                table: "Appointment",
                column: "patient_id",
                principalTable: "Patient",
                principalColumn: "patient_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Treatment_treatment_id",
                table: "Appointment",
                column: "treatment_id",
                principalTable: "Treatment",
                principalColumn: "treatment_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Dentist_dentist_id",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Patient_patient_id",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Treatment_treatment_id",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_dentist_id",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_patient_id",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_treatment_id",
                table: "Appointment");
        }
    }
}
