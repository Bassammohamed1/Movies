using CoreLayer.Interfaces;
using CoreLayer.Models;
using CoreLayer.ViewModels;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Repository
{
    public class MoviesRepository : Repository<Movie>, IMoviesRepository
    {
        private readonly AppDbContext _context;
        public MoviesRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public Movie GetMovieById(int id)
        {
            return _context.Movies.Include(x => x.Producer).Include(y => y.ActorMovies).ThenInclude(z => z.Actor).FirstOrDefault(s => s.Id == id);
        }
        public void AddMovie(MovieViewModel data)
        {
            var movie = new Movie()
            {
                Id = data.Id,
                Name = data.Name,
                Bio = data.Bio,
                dbImage = data.dbImage,
                price = data.price,
                MovieCategory = data.MovieCategory,
                IsSeries = data.IsSeries,
                ProducerId = data.ProducerId,
            };
            _context.Movies.Add(movie);
            _context.SaveChanges();
            foreach (var i in data.ActorsId)
            {
                var result = new ActorMovie()
                {
                    MovieId = movie.Id,
                    ActorId = i
                };
                _context.ActorMovies.Add(result);
            }
            _context.SaveChanges();
        }
        public void UpdateMovie(MovieViewModel data)
        {
            var movie = _context.Movies.Find(data.Id);
            movie.Name = data.Name;
            movie.Bio = data.Bio;
            movie.dbImage = data.dbImage;
            movie.price = data.price;
            movie.MovieCategory = data.MovieCategory;
            movie.IsSeries = data.IsSeries;
            movie.ProducerId = data.ProducerId;
            _context.SaveChanges();
            foreach (var i in data.ActorsId)
            {
                var result = new ActorMovie()
                {
                    MovieId = movie.Id,
                    ActorId = i
                };
                _context.ActorMovies.Update(result);
            }
            _context.SaveChanges();
        }
    }
}
