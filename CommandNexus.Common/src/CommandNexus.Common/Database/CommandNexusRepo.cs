using Microsoft.EntityFrameworkCore;

namespace CommandNexus.Common.Database
{
    public class CommandNexusRepo<T> : IRepository<T>
        where T :class, IModel
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public CommandNexusRepo(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T? GetById(Guid id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Create(T entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));

            _dbSet.Add(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
