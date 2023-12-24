using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Movies.Data.Consts;

namespace Movies.Models
{
    public class MovieViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Bio { get; set; }
        [Required]
        public double price { get; set; }
        [Required, DisplayName("Category")]
        public MoiveCategory MoiveCategory { get; set; }
        [NotMapped]
        public IFormFile clientFile { get; set; }
        public byte[]? dbImage { get; set; }
        [DisplayName("Producer")]
        public int ProducerId { get; set; }
        [DisplayName("Actors")]
        public List<int> ActorsId { get; set; }
    }
}
