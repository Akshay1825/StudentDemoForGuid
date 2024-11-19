
using Microsoft.EntityFrameworkCore;
using StudentDemoForGuid.Data;

namespace StudentDemoForGuid.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly StudentContext _context;
        private readonly DbSet<T> _table;

        public Repository(StudentContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _table.Add(entity);
            _context.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }

        public T GetById(Guid id)
        {
            var entity = _table.Find(id);
            return entity;
        }
    }
}
