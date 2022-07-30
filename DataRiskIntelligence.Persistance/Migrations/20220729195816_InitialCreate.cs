using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataRiskIntelligence.Persistance.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotes_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 1, "Andrew", "Hendrixson" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 2, "Coco", "Chanel" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 3, "Albert", "Einstein" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 4, "Brian", "Tracy" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 5, "Grace", "Coddington" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 6, "Henry David", "Thoreau" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 7, "Unknown", "Unknown" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 8, "Abraham", "Lincoln" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 9, "Robin", "Shaurma" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 10, "Anaïs", "Nin" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "PersonId", "Text" },
                values: new object[] { 1, 1, "Anyone who has ever made anything of importance was disciplined." });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "PersonId", "Text" },
                values: new object[] { 2, 2, "Don’t spend time beating on a wall, hoping to transform it into a door." });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "PersonId", "Text" },
                values: new object[] { 3, 3, "Creativity is intelligence having fun." });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "PersonId", "Text" },
                values: new object[] { 4, 4, "Optimism is the one quality more associated with success and happiness than any other." });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "PersonId", "Text" },
                values: new object[] { 5, 5, "Always keep your eyes open. Keep watching. Because whatever you see can inspire you." });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "PersonId", "Text" },
                values: new object[] { 6, 6, "What you get by achieving your goals is not as important as what you become by achieving your goals." });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "PersonId", "Text" },
                values: new object[] { 7, 7, "If the plan doesn’t work, change the plan, but never the goal." });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "PersonId", "Text" },
                values: new object[] { 8, 8, "I destroy my enemies when I make them my friends." });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "PersonId", "Text" },
                values: new object[] { 9, 9, "Don’t live the same year 75 times and call it a life." });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "PersonId", "Text" },
                values: new object[] { 10, 10, "You cannot save people, you can just love them." });

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_PersonId",
                table: "Quotes",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
