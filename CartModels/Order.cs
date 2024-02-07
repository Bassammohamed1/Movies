using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using Movies.Models;

namespace Movies.CartModels
{
    public class Order
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string UserId { get; set; }
        public IdentityUser? User { get; set; }

        public List<OrderItem>? OrderItems { get; set; }
    }
}
