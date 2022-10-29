using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VechileApplication.Migrations
{
    public partial class CreateVehicleDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Make",
                columns: table => new
                {
                    make_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    make_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Make", x => x.make_id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    model_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    model_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    make_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.model_id);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    price_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    v_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.price_id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    v_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    v_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    make_id = table.Column<int>(type: "int", nullable: false),
                    model_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.v_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Make");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
