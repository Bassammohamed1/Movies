using CoreLayer.Interfaces;
using CoreLayer.Models.Cart;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly AppDbContext _db;
        public OrdersRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Order>> UserOrders()
        {
            var orders = await _db.Orders
                            .Include(x => x.OrderStatus)
                            .Include(x => x.OrderDetail)
                            .ThenInclude(x => x.Movie)
                            .ThenInclude(x => x.Producer)
                            .ToListAsync();
            return orders;
        }
    }
}