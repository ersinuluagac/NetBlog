using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UIWeb.Migrations
{
    public partial class tryEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
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
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Posts_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Likes_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 4, 17, 22, 21, 231, DateTimeKind.Local).AddTicks(2746), false, "Yazılım", null },
                    { 2, new DateTime(2025, 5, 4, 17, 22, 21, 231, DateTimeKind.Local).AddTicks(2755), false, "Teknoloji", null },
                    { 3, new DateTime(2025, 5, 4, 17, 22, 21, 231, DateTimeKind.Local).AddTicks(2756), false, "Oyun", null },
                    { 4, new DateTime(2025, 5, 4, 17, 22, 21, 231, DateTimeKind.Local).AddTicks(2757), false, "Yapay Zeka", null },
                    { 5, new DateTime(2025, 5, 4, 17, 22, 21, 231, DateTimeKind.Local).AddTicks(2758), false, "Sağlık", null },
                    { 6, new DateTime(2025, 5, 4, 17, 22, 21, 231, DateTimeKind.Local).AddTicks(2760), false, "İş Dünyası", null },
                    { 7, new DateTime(2025, 5, 4, 17, 22, 21, 231, DateTimeKind.Local).AddTicks(2804), false, "Finans Dünyası", null },
                    { 8, new DateTime(2025, 5, 4, 17, 22, 21, 231, DateTimeKind.Local).AddTicks(2805), false, "Tarih", null },
                    { 9, new DateTime(2025, 5, 4, 17, 22, 21, 231, DateTimeKind.Local).AddTicks(2807), false, "Sanat", null },
                    { 10, new DateTime(2025, 5, 4, 17, 22, 21, 231, DateTimeKind.Local).AddTicks(2808), false, "Kişisel Gelişim", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "UserName" },
                values: new object[,]
                {
                    { 1, "Arbores" },
                    { 2, "Surgens" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedAt", "ImageUrl", "IsDeleted", "Summary", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "HTML bir işaretleme dilidir.", new DateTime(2025, 5, 4, 17, 22, 21, 231, DateTimeKind.Local).AddTicks(5773), "/images/html.png", false, "Etiketleme", "HTML", null, 1 },
                    { 2, 1, "CSS bir işaretleme dilidir ve HTML etiketlerine görsellik eklemek için kullanılır.", new DateTime(2025, 5, 4, 17, 22, 21, 231, DateTimeKind.Local).AddTicks(5779), "/images/css.png", false, "Renklendirme", "CSS", null, 2 },
                    { 3, 1, "Javascript bir programlama dilidir. HTML ve CSS ile oluşturulmuş sayfalara etkileşim ve hareket katmak için kullanılır.", new DateTime(2025, 5, 4, 17, 22, 21, 231, DateTimeKind.Local).AddTicks(5781), null, false, "Hareketlendirme", "Javascript", null, 1 },
                    { 4, 2, "Doğu Roma'nın ve Osmanlı'nın başkentidir. Önemli bir yarımadadır.", new DateTime(2025, 5, 4, 17, 22, 21, 231, DateTimeKind.Local).AddTicks(5782), null, false, "Megakent", "İstanbul", null, 2 },
                    { 5, 2, "Tam olarak bilinmemekle birlikte kökenlerine dair iki farklı görüş vardır.", new DateTime(2025, 5, 4, 17, 22, 21, 231, DateTimeKind.Local).AddTicks(5784), null, false, "Slav ülkesi", "Rusya", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "IsDeleted", "PostId", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, "Çok güzel bir yazı olmuş.", new DateTime(2025, 5, 4, 17, 22, 21, 231, DateTimeKind.Local).AddTicks(3512), false, 3, "Harika!", null, 1 },
                    { 2, "Gönderiyi hiç beğenmedim.", new DateTime(2025, 5, 4, 17, 22, 21, 231, DateTimeKind.Local).AddTicks(3517), false, 3, "Berbat", null, 2 },
                    { 3, "İlginç bir fikir.", new DateTime(2025, 5, 4, 17, 22, 21, 231, DateTimeKind.Local).AddTicks(3519), false, 2, "İlginç", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "PostId", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 4, 17, 22, 21, 231, DateTimeKind.Local).AddTicks(3835), false, 2, null, 1 },
                    { 2, new DateTime(2025, 5, 4, 17, 22, 21, 231, DateTimeKind.Local).AddTicks(3838), false, 2, null, 2 },
                    { 3, new DateTime(2025, 5, 4, 17, 22, 21, 231, DateTimeKind.Local).AddTicks(3839), false, 1, null, 1 },
                    { 4, new DateTime(2025, 5, 4, 17, 22, 21, 231, DateTimeKind.Local).AddTicks(3840), false, 3, null, 2 },
                    { 5, new DateTime(2025, 5, 4, 17, 22, 21, 231, DateTimeKind.Local).AddTicks(3841), false, 4, null, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostId",
                table: "Likes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
