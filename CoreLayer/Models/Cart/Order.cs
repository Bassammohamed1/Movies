using System.ComponentModel.DataAnnotations;

namespace CoreLayer.Models.Cart
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        [Required]
        public int OrderStatusId { get; set; }
        public bool IsDeleted { get; set; } = false;

        public OrderStatus? OrderStatus { get; set; }
        public List<OrderDetail>? OrderDetail { get; set; }
    }
}
