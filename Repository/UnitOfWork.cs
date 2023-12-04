using Movies.Models;
using Movies.Repository.Interfaces;

namespace Movies.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Actors = new Repository<Actor>(_context);
            Producers = new Repository<Producer>(_context);
            Movies = new MoviesRepository(_context);
            Orders = new OrdersRepository(_context);
        }
        public IRepository<Actor> Actors { get; private set; }

        public IRepository<Producer> Producers { get; private set; }

        public IMoviesRepository Movies { get; private set; }
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
