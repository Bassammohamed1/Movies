using CoreLayer.Models.Cart;

namespace CoreLayer.Interfaces
{
    public interface ICartRepository
    {
        Task<int> AddItem(int movieId, int qty);
        Task<int> RemoveItem(int movieId);
        Task<ShoppingCart> GetUserCart();
        Task<int> GetCartItemCount(string userId = "");
        Task<bool> DoCheckout();
    }
}
