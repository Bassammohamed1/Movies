using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Movies.Migrations
{
    /// <inheritdoc />
    public partial class AddModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    MoiveCategory = table.Column<int>(type: "int", nullable: false),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProducerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Producers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActorMovies",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovies", x => new { x.MovieId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_ActorMovies_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Bio", "Name", "Src" },
                values: new object[,]
                {
                    { 1, "Cillian Murphy is an Irish actor. He made his professional debut in Enda Walsh's 1996 play Disco Pigs, a role he later reprised in the 2001 screen adaptation.", "Cillian Murphy", "https://encrypted-tbn1.gstatic.com/licensed-image?q=tbn:ANd9GcTzsv2mdNgXUg6UHxeW-C9awUeI2073Chv_rPRJca3NcOgo0UKqGAxOr0O39ILt708Q2ve9E1MxrNMPaJA" },
                    { 2, "Robert John Downey Jr. is an American actor. His career has been characterized by critical success in his youth, followed by a period of substance abuse and legal troubles, and a surge in popular and commercial success later in his career.", "Robert Downey Jr.", "https://encrypted-tbn0.gstatic.com/licensed-image?q=tbn:ANd9GcTof5XGzxuO6J2TdrCnII3RFqhj3jj_X4Qzwe52Ebo7veL-6y4ZPSzAJIIsKZVv662aOS8w4QBrmD3p6Bc" },
                    { 3, "Matthew David McConaughey is an American actor. He had his breakout role with a supporting performance in the coming-of-age comedy Dazed and Confused. After a number of supporting roles, his first success as a leading man came in the legal drama A Time to Kill.", "Matthew McConaughey", "https://encrypted-tbn1.gstatic.com/licensed-image?q=tbn:ANd9GcS03vLTavK8Bw69E-firOBBRMbM4nt2FThIqBQFRcwDVyh48hpa09uYVCcwhGNDxtSR-nMc_19O2RAhr9s" },
                    { 4, "Jessica Chastain is an American actress of film, television, and stage. As a final-year student at the Juilliard School, she was signed on for a talent holding deal by the television producer John Wells.", "Jessica Chastain", "https://encrypted-tbn2.gstatic.com/licensed-image?q=tbn:ANd9GcRwFmx29NKSIJl6qaTO1DT7sJjoOOBQi3W9WEdjV88H-3ceQ12rhEIomrUl52sA118ZWoIFFDXruKpKgrM" },
                    { 5, "hristian Charles Philip Bale is an English actor. Known for his versatility and physical transformations for his roles, he has been a leading man in films of several genres. He has received various accolades, including an Academy Award and two Golden Globe Awards. ", "Christian Bale", "https://encrypted-tbn2.gstatic.com/licensed-image?q=tbn:ANd9GcTgwC2GrtpVJp6H4hd49UtRWqHW1yCWW7O6a2lOwTp3VLLwy9G_YOnLpJb_Tp1UHGUviCy1_36EmM-vFiw" },
                    { 6, "Heath Andrew Ledger was an Australian actor. After playing roles in several Australian television and film productions during the 1990s, Ledger moved to the United States in 1998 to develop his film career further.", "Heath Ledger", "https://encrypted-tbn3.gstatic.com/licensed-image?q=tbn:ANd9GcR3VUtiCinec9LWn0cGBfgQEnMGGLEAWC6sZtYbMO7HMjYRPmANwQ6NFNLzG8xQVMZftTUHSIqasTHsJ0k" }
                });

            migrationBuilder.InsertData(
                table: "Producers",
                columns: new[] { "Id", "Bio", "Name", "Src" },
                values: new object[] { 1, "Christopher Edward Nolan CBE is a British and American filmmaker. Known for his Hollywood blockbusters with complex storytelling, Nolan is considered a leading filmmaker of the 21st century. His films have grossed $5 billion worldwide.", "Christopher Nolan", "https://encrypted-tbn1.gstatic.com/licensed-image?q=tbn:ANd9GcTfWsTYHBYRh-5_YJxaKqZaqcxNp0GCoL-CQcdtqoX0ROYto2I8MwHcQoEypJTUlnDzUMsvCeFnUHZ1ID0" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Bio", "MoiveCategory", "Name", "ProducerId", "Src", "price" },
                values: new object[,]
                {
                    { 1, "When Earth becomes uninhabitable in the future, a farmer and ex-NASA pilot, Joseph Cooper, is tasked to pilot a spacecraft, along with a team of researchers, to find a new planet for humans.", 1, "Interstellar", 1, "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRf61mker2o4KH3CbVE7Zw5B1-VogMH8LfZHEaq3UdCMLxARZAB", 150.0 },
                    { 2, "After Gordon, Dent and Batman begin an assault on Gotham's organised crime, the mobs hire the Joker, a psychopathic criminal mastermind who offers to kill Batman and bring the city to its knees.", 0, "The Dark Knight", 1, "https://contentserver.com.au/assets/598411_p173378_p_v8_au.jpg", 100.0 },
                    { 3, "During World War II, Lt. Gen. Leslie Groves Jr. appoints physicist J. Robert Oppenheimer to work on the top-secret Manhattan Project. Oppenheimer and a team of scientists spend years developing and designing the atomic bomb. Their work comes to fruition on July 16, 1945, as they witness the world's first nuclear explosion, forever changing the course of history.", 1, "Oppenheimer", 1, "https://pbs.twimg.com/media/FvUVt3hXgAAxP1H?format=jpg&name=900x900", 200.0 }
                });

            migrationBuilder.InsertData(
                table: "ActorMovies",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 2 },
                    { 6, 2 },
                    { 1, 3 },
                    { 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovies_ActorId",
                table: "ActorMovies",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ProducerId",
                table: "Movies",
                column: "ProducerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMovies");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Producers");
        }
    }
}
