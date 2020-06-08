using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    PlaceId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    Country = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.PlaceId);
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "PlaceId", "City", "Country", "Description", "ImageUrl", "Rating" },
                values: new object[] { 1, "Heraklion", "Greece", "A beautiful scenic place with delicious food surrounded by warm Aegean waters.", "https://www.themediterraneantraveller.com/wp-content/uploads/2018/11/greece-heraklion-00032.jpg", 5 });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "PlaceId", "City", "Country", "Description", "ImageUrl", "Rating" },
                values: new object[] { 2, "Istanbul", "Turkey", " Go to Istanbul if you just have to choose one City in the entire World. All famous tourist attraction in 2 miles diameter. Don't need even transport to go to different attractions. Just walk", "https://cdn.travelpulse.com/images/65aaedf4-a957-df11-b491-006073e71405/c8f899f1-a4af-4ea3-b5dd-447ebbaeb40e/630x355.jpg", 8 });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "PlaceId", "City", "Country", "Description", "ImageUrl", "Rating" },
                values: new object[] { 3, "Fes", "Morocco", " Good place to visit if you are already visiting Tangier in Morocco. But do visit Karaveen university that is the oldest university still operational in the World. It started functuning around late 700's. And Yep still going after 1300 years", "https://www.toursbylocals.com/images/guides/46/46460/202027064423775.jpg", 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Places");
        }
    }
}
