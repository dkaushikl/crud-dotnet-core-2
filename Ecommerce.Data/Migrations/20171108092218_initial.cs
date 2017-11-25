using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Category",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>("nvarchar(max)", nullable: true),
                    Sequence = table.Column<int>("int", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Category", x => x.Id); });

            migrationBuilder.CreateTable(
                "Product",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>("int", nullable: false),
                    Color = table.Column<string>("nvarchar(max)", nullable: true),
                    Description = table.Column<string>("nvarchar(max)", nullable: true),
                    Name = table.Column<string>("nvarchar(max)", nullable: true),
                    Size = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Product", x => x.Id); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Category");

            migrationBuilder.DropTable(
                "Product");
        }
    }
}