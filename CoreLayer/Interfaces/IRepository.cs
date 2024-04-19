using System.Linq.Expressions;

namespace CoreLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> data);
        void Add(T data);
        void Update(T data);
        void Delete(T data);
        void AddAll(List<T> data);
        void UpdateAll(List<T> data);
        void DeleteAll(List<T> data);
    }
}
