using Movies.Models;

namespace Movies.Repository.Interfaces
{
    public interface IMoviesRepository : IRepository<Movie>
    {
        public Movie GetMovieById(int id);
        public void AddMovie(MovieViewModel data);
        public void UpdateMovie(MovieViewModel data);
    }
}
