namespace StudentDemoForGuid.Repositories
{
    public interface IRepository<T>
    {
        public IQueryable<T> GetAll();
        public T GetById(Guid id);
        public void Add(T entity);
    }
}
