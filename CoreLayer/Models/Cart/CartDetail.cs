using CoreLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace CoreLayer.Models.Cart
{
    public class CartDetail
    {
        public int Id { get; set; }
        [Required]
        public int ShoppingCartId { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public Movie? Movie { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }
    }
}
