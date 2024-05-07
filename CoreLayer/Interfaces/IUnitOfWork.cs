using CoreLayer.Models;

namespace CoreLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Actor> Actors { get; }
        public IRepository<Producer> Producers { get; }
        public IMoviesRepository Movies { get; }
        ICartRepository Carts { get; }
        IOrdersRepository Orders { get; }
        public void Commit();
    }
}