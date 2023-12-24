using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Movies.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Src",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "Src",
                table: "Actors");

            migrationBuilder.AddColumn<byte[]>(
                name: "dbImage",
                table: "Producers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "dbImage",
                table: "Actors",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dbImage",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "dbImage",
                table: "Actors");

            migrationBuilder.AddColumn<string>(
                name: "Src",
                table: "Producers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Src",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
        }
    }
}
