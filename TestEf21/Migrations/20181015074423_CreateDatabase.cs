using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestEf21.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    Key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    Key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CanView = table.Column<bool>(nullable: false),
                    ParentKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Children_Parents_ParentKey",
                        column: x => x.ParentKey,
                        principalTable: "Parents",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "Key", "Name" },
                values: new object[] { 1, "Object1" });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "Key", "Name" },
                values: new object[] { 2, "Object2" });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Key", "CanView", "ParentKey" },
                values: new object[,]
                {
                    { 1, true, 1 },
                    { 2, false, 1 },
                    { 3, false, 2 },
                    { 4, false, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Children_ParentKey",
                table: "Children",
                column: "ParentKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Parents");
        }
    }
}
