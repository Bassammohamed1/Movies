using CoreLayer.Interfaces;
using CoreLayer.Models;
using InfrastructureLayer.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace InfrastructureLayer.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UnitOfWork(AppDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            Actors = new Repository<Actor>(_context);
            Producers = new Repository<Producer>(_context);
            Movies = new MoviesRepository(_context);
            Carts = new CartRepository(_context, _httpContextAccessor, _userManager);
            Orders = new OrdersRepository(_context);
        }
        public IRepository<Actor> Actors { get; private set; }

        public IRepository<Producer> Producers { get; private set; }

        public IMoviesRepository Movies { get; private set; }
        public ICartRepository Carts { get; private set; }
        public IOrdersRepository Orders { get; private set; }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
