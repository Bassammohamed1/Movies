using CoreLayer.Models;
using CoreLayer.Models.ViewModels;

namespace CoreLayer.Interfaces
{
    public interface IMoviesRepository : IRepository<Movie>
    {
        public Movie GetMovieById(int id);
        public void AddMovie(MovieViewModel data);
        public void UpdateMovie(MovieViewModel data);
    }
}
