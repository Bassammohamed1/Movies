using System.ComponentModel.DataAnnotations;

namespace CoreLayer.Models.Cart
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public bool IsDeleted { get; set; } = false;

        public ICollection<CartDetail>? CartDetails { get; set; }
    }
}
