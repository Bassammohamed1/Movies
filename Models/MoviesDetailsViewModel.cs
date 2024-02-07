namespace Movies.Models
{
    public class MoviesDetailsViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Movie>? Movies { get; set; }
    }
}