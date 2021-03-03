using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewPostgresApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Writers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    WriterId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Posts_Writers_WriterId",
                        column: x => x.WriterId,
                        principalTable: "Writers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Writers",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("15a96f15-5ebb-4764-8213-11dce2002ef5"), "Adam" },
                    { new Guid("630e64fc-2334-468b-af6d-d08d753af05e"), "Bob" },
                    { new Guid("25e5551c-529b-4d81-9ded-fbda38a1f039"), "Charlie" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "ID", "Content", "Name", "WriterId" },
                values: new object[,]
                {
                    { new Guid("b72dcaf0-0769-4693-903d-dd76025e4ec3"), "111", "First post", new Guid("15a96f15-5ebb-4764-8213-11dce2002ef5") },
                    { new Guid("ffad56dc-4f39-4bf2-b85a-d766c06cf7a8"), "222", "Second post", new Guid("15a96f15-5ebb-4764-8213-11dce2002ef5") },
                    { new Guid("a32dfd24-03de-40de-bd77-ae04e0442561"), "333", "Third post", new Guid("15a96f15-5ebb-4764-8213-11dce2002ef5") },
                    { new Guid("b89989ae-9d08-49f8-a447-437bc496f694"), "444", "Fourth post", new Guid("630e64fc-2334-468b-af6d-d08d753af05e") },
                    { new Guid("c7cfbb47-8712-4588-aee2-cd51be2bc166"), "555", "Fifth post", new Guid("630e64fc-2334-468b-af6d-d08d753af05e") },
                    { new Guid("2f0763e0-f94b-492b-a516-6bb958a1fc65"), "6*6", "Sixth post", new Guid("630e64fc-2334-468b-af6d-d08d753af05e") },
                    { new Guid("e043c690-1a3b-4391-8cb3-bfb7aee97c6f"), "777", "Seventh post", new Guid("25e5551c-529b-4d81-9ded-fbda38a1f039") },
                    { new Guid("1c9ddf72-ca59-4a0e-ac55-4d1385fa3c98"), "888", "Eighth post", new Guid("25e5551c-529b-4d81-9ded-fbda38a1f039") },
                    { new Guid("1bbcc368-7c27-4e2c-a9dd-36c1d7f0bf7a"), "999", "Ninth post", new Guid("25e5551c-529b-4d81-9ded-fbda38a1f039") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_WriterId",
                table: "Posts",
                column: "WriterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Writers");
        }
    }
}
