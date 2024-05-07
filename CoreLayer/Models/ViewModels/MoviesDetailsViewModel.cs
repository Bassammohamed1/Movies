using CoreLayer.Models;

namespace CoreLayer.Models.ViewModels
{
    public class MoviesDetailsViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Movie>? Movies { get; set; }
    }
}