using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kirusha_crud_asp.net.Migrations
{
    /// <inheritdoc />
    public partial class dentist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dentist",
                columns: table => new
                {
                    dentist_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    specialty = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    name_first = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    name_middle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    name_last = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    house_number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    postcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dentist", x => x.dentist_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dentist");
        }
    }
}
