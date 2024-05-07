using CoreLayer.Models.Cart;

namespace CoreLayer.Interfaces
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Order>> UserOrders();
    }
}
