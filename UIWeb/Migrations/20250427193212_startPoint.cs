using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UIWeb.Migrations
{
    public partial class startPoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Yazılım" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Tarih" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "ImageUrl", "Summary", "Title" },
                values: new object[,]
                {
                    { 1, 1, "HTML bir işaretleme dilidir.", "/images/html.png", null, "HTML" },
                    { 2, 1, "CSS bir işaretleme dilidir ve HTML etiketlerine görsellik eklemek için kullanılır.", "/images/css.png", null, "CSS" },
                    { 3, 1, "Javascript bir programlama dilidir. HTML ve CSS ile oluşturulmuş sayfalara etkileşim ve hareket katmak için kullanılır.", null, null, "Javascript" },
                    { 4, 2, "Doğu Roma'nın ve Osmanlı'nın başkentidir. Önemli bir yarımadadır.", null, null, "İstanbul" },
                    { 5, 2, "Tam olarak bilinmemekle birlikte kökenlerine dair iki farklı görüş vardır.", null, null, "Rusya" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
