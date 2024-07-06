using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenPar2.Migrations
{
    /// <inheritdoc />
    public partial class PrimerMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "skin",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    imageUrl = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    category = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Skin__3214EC07D9BFD537", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "skin");
        }
    }
}
