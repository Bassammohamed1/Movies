using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movies.Areas.Cart.Models;

namespace Movies.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(x => x.ProviderKey);
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(x => x.UserId);

            modelBuilder.Entity<ActorMovie>().HasKey(k => new { k.MovieId, k.ActorId });
            modelBuilder.Entity<ActorMovie>().HasOne(o => o.Actor).WithMany(m => m.ActorMovies).HasForeignKey(o => o.ActorId);
            modelBuilder.Entity<ActorMovie>().HasOne(o => o.Movie).WithMany(m => m.ActorMovies).HasForeignKey(o => o.MovieId);

            modelBuilder.Entity<Producer>().HasData(
                new Producer { Id = 1, Name = "Christopher Nolan", Bio = "Christopher Edward Nolan CBE is a British and American filmmaker. Known for his Hollywood blockbusters with complex storytelling, Nolan is considered a leading filmmaker of the 21st century. His films have grossed $5 billion worldwide.", Src = "https://encrypted-tbn1.gstatic.com/licensed-image?q=tbn:ANd9GcTfWsTYHBYRh-5_YJxaKqZaqcxNp0GCoL-CQcdtqoX0ROYto2I8MwHcQoEypJTUlnDzUMsvCeFnUHZ1ID0" }
                );

           /* modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Name = "Interstellar", Bio = "When Earth becomes uninhabitable in the future, a farmer and ex-NASA pilot, Joseph Cooper, is tasked to pilot a spacecraft, along with a team of researchers, to find a new planet for humans.", price = 150, MoiveCategory = Data.Consts.MoiveCategory.Drama, ProducerId = 1, Src = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRf61mker2o4KH3CbVE7Zw5B1-VogMH8LfZHEaq3UdCMLxARZAB" },
                new Movie { Id = 2, Name = "The Dark Knight", Bio = "After Gordon, Dent and Batman begin an assault on Gotham's organised crime, the mobs hire the Joker, a psychopathic criminal mastermind who offers to kill Batman and bring the city to its knees.", price = 100, MoiveCategory = Data.Consts.MoiveCategory.Action, ProducerId = 1, Src = "https://contentserver.com.au/assets/598411_p173378_p_v8_au.jpg" },
                new Movie { Id = 3, Name = "Oppenheimer", Bio = "During World War II, Lt. Gen. Leslie Groves Jr. appoints physicist J. Robert Oppenheimer to work on the top-secret Manhattan Project. Oppenheimer and a team of scientists spend years developing and designing the atomic bomb. Their work comes to fruition on July 16, 1945, as they witness the world's first nuclear explosion, forever changing the course of history.", price = 200, MoiveCategory = Data.Consts.MoiveCategory.Drama, ProducerId = 1, Src = "https://pbs.twimg.com/media/FvUVt3hXgAAxP1H?format=jpg&name=900x900" }
                );*/

            modelBuilder.Entity<Actor>().HasData(
            new Actor { Id = 1, Name = "Cillian Murphy", Bio = "Cillian Murphy is an Irish actor. He made his professional debut in Enda Walsh's 1996 play Disco Pigs, a role he later reprised in the 2001 screen adaptation.", Src = "https://encrypted-tbn1.gstatic.com/licensed-image?q=tbn:ANd9GcTzsv2mdNgXUg6UHxeW-C9awUeI2073Chv_rPRJca3NcOgo0UKqGAxOr0O39ILt708Q2ve9E1MxrNMPaJA" },
            new Actor { Id = 2, Name = "Robert Downey Jr.", Bio = "Robert John Downey Jr. is an American actor. His career has been characterized by critical success in his youth, followed by a period of substance abuse and legal troubles, and a surge in popular and commercial success later in his career.", Src = "https://encrypted-tbn0.gstatic.com/licensed-image?q=tbn:ANd9GcTof5XGzxuO6J2TdrCnII3RFqhj3jj_X4Qzwe52Ebo7veL-6y4ZPSzAJIIsKZVv662aOS8w4QBrmD3p6Bc" },
            new Actor { Id = 3, Name = "Matthew McConaughey", Bio = "Matthew David McConaughey is an American actor. He had his breakout role with a supporting performance in the coming-of-age comedy Dazed and Confused. After a number of supporting roles, his first success as a leading man came in the legal drama A Time to Kill.", Src = "https://encrypted-tbn1.gstatic.com/licensed-image?q=tbn:ANd9GcS03vLTavK8Bw69E-firOBBRMbM4nt2FThIqBQFRcwDVyh48hpa09uYVCcwhGNDxtSR-nMc_19O2RAhr9s" },
            new Actor { Id = 4, Name = "Jessica Chastain", Bio = "Jessica Chastain is an American actress of film, television, and stage. As a final-year student at the Juilliard School, she was signed on for a talent holding deal by the television producer John Wells.", Src = "https://encrypted-tbn2.gstatic.com/licensed-image?q=tbn:ANd9GcRwFmx29NKSIJl6qaTO1DT7sJjoOOBQi3W9WEdjV88H-3ceQ12rhEIomrUl52sA118ZWoIFFDXruKpKgrM" },
            new Actor { Id = 5, Name = "Christian Bale", Bio = "hristian Charles Philip Bale is an English actor. Known for his versatility and physical transformations for his roles, he has been a leading man in films of several genres. He has received various accolades, including an Academy Award and two Golden Globe Awards. ", Src = "https://encrypted-tbn2.gstatic.com/licensed-image?q=tbn:ANd9GcTgwC2GrtpVJp6H4hd49UtRWqHW1yCWW7O6a2lOwTp3VLLwy9G_YOnLpJb_Tp1UHGUviCy1_36EmM-vFiw" },
            new Actor { Id = 6, Name = "Heath Ledger", Bio = "Heath Andrew Ledger was an Australian actor. After playing roles in several Australian television and film productions during the 1990s, Ledger moved to the United States in 1998 to develop his film career further.", Src = "https://encrypted-tbn3.gstatic.com/licensed-image?q=tbn:ANd9GcR3VUtiCinec9LWn0cGBfgQEnMGGLEAWC6sZtYbMO7HMjYRPmANwQ6NFNLzG8xQVMZftTUHSIqasTHsJ0k" }
                );

            modelBuilder.Entity<ActorMovie>().HasData(
                new ActorMovie { ActorId = 1, MovieId = 3 },
                new ActorMovie { ActorId = 2, MovieId = 3 },
                new ActorMovie { ActorId = 3, MovieId = 1 },
                new ActorMovie { ActorId = 4, MovieId = 1 },
                new ActorMovie { ActorId = 5, MovieId = 2 },
                new ActorMovie { ActorId = 6, MovieId = 2 }
                );
        }
    }
}