using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UIWeb.Migrations
{
    public partial class PostSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
