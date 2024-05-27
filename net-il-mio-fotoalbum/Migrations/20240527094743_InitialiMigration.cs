using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace net_il_mio_fotoalbum.Migrations
{
    /// <inheritdoc />
    public partial class InitialiMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryPhoto",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    PhotoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPhoto", x => new { x.CategoriesId, x.PhotoId });
                    table.ForeignKey(
                        name: "FK_CategoryPhoto_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryPhoto_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Nature" },
                    { 2, "Urban" },
                    { 3, "Portrait" },
                    { 4, "Wildlife" },
                    { 5, "Abstract" }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "Description", "Image", "IsVisible", "Title" },
                values: new object[,]
                {
                    { 1, "A beautiful sunset over the mountain range.", "https://media.istockphoto.com/id/1136834574/photo/watzmann-in-alps-dramatic-reflection-at-sunset-national-park-berchtesgaden.jpg?s=612x612&w=0&k=20&c=TpbhKprAFth2Lss7ZCiK7R4d2N-YKt0d9Kh3BSpg9eI=", true, "Sunset in the Mountains" },
                    { 2, "A bustling city skyline at night.", "https://img.freepik.com/premium-photo/captivating-aerial-shot-bustling-city-illuminated-by-mesmerizing-glow-its-nighttime-skyline-city-glowing-evening-skyline-from-ai-generated_538213-19212.jpg", true, "City Skyline" },
                    { 3, "A serene pathway through the forest.", "https://static.vecteezy.com/system/resources/previews/031/579/834/large_2x/winding-path-through-serene-forest-generative-ai-photo.jpeg", true, "Forest Pathway" },
                    { 4, "A majestic tiger in the wild.", "https://media.4-paws.org/5/4/4/c/544c2b2fd37541596134734c42bf77186f0df0ae/VIER%20PFOTEN_2017-10-20_164-3854x2667-1920x1329.jpg", true, "Wild Tiger" },
                    { 5, "An abstract piece of modern art.", "https://www.paulkenton.com/wp-content/uploads/2020/12/expanse-background.jpg", true, "Modern Art" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPhoto_PhotoId",
                table: "CategoryPhoto",
                column: "PhotoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryPhoto");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Photos");
        }
    }
}
