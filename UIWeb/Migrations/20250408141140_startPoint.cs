using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UIWeb.Migrations
{
    public partial class startPoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[,]
                {
                    { 1, "HTML bir işaretleme dilidir.", "HTML" },
                    { 2, "CSS bir işaretleme dilidir ve HTML etiketlerine görsellik eklemek için kullanılır.", "CSS" },
                    { 3, "Javascript bir programlama dilidir. HTML ve CSS ile oluşturulmuş sayfalara etkileşim ve hareket katmak için kullanılır.", "Javascript" },
                    { 4, "C# geniş kapsamlı bir programlama dilidir. İnternet siteleri, Windows uygulamaları veya oyunları yapmak için sıkça kullanılır.", "C#" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
