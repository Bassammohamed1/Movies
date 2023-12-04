using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Bio { get; set; }
        [Required, DisplayName("Image Src")]
        public string Src { get; set; }
        public List<ActorMovie>? ActorMovies { get; set; }
    }
}