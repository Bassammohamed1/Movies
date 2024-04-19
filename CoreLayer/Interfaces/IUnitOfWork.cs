using CoreLayer.Models;

namespace CoreLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Actor> Actors { get; }
        public IRepository<Producer> Producers { get; }
        public IOrdersRepository Orders { get; }
        public IMoviesRepository Movies { get; }
        public void Commit();
    }
}