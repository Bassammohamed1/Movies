using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using CoreLayer.Enums;
using Microsoft.AspNetCore.Http;

namespace CoreLayer.Models.ViewModels
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
        public double Price { get; set; }
        [Required, DisplayName("Category")]
        public MovieCategory MovieCategory { get; set; }
        [NotMapped]
        public IFormFile clientFile { get; set; }
        public byte[]? dbImage { get; set; }
        [DisplayName("Producer")]
        public int ProducerId { get; set; }
        [DisplayName("Actors")]
        public List<int> ActorsId { get; set; }
        [DisplayName("Is Series")]
        public bool IsSeries { get; set; }
        public int? MoviePart { get; set; }
    }
}
