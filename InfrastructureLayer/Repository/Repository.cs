using CoreLayer.Interfaces;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InfrastructureLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public T Get(Expression<Func<T, bool>> data)
        {
            return _context.Set<T>().SingleOrDefault(data);
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Add(T data)
        {
            _context.Set<T>().Add(data);
        }
        public void AddAll(List<T> data)
        {
            _context.Set<T>().AddRange(data);
        }
        public void Update(T data)
        {
            _context.Set<T>().Update(data);
        }
        public void UpdateAll(List<T> data)
        {
            _context.Set<T>().UpdateRange(data);
        }
        public void Delete(T data)
        {
            _context.Set<T>().Remove(data);
        }
        public void DeleteAll(List<T> data)
        {
            _context.Set<T>().RemoveRange(data);
        }
    }
}