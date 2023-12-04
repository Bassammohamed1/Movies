using Movies.Areas.Cart.Models;

namespace Movies.Repository.Interfaces
{
    public interface IOrdersRepository
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
    }
}
