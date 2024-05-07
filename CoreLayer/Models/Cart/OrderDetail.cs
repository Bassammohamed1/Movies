using CoreLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace CoreLayer.Models.Cart
{
    public class OrderDetail
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        public Order? Order { get; set; }
        public Movie? Movie { get; set; }
    }
}
