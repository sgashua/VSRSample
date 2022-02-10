using VSRSample.Application.Repositories;
using VSRSample.Domain.Entities;
using VSRSample.Persistence.Context;

namespace VSRSample.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DatabaseContext _context;
        public BaseRepository(DatabaseContext context)
        {
            _context = context;
        }

        // Both Insert & Update
        public void Save(T obj, bool IsCommit = true)
        {
            if ((obj as BaseEntity).Id == 0)
            {
                _context.Set<T>().Add(obj);
            }

            if (IsCommit)
            {
                _context.SaveChanges();
            }
        }

        public void Delete(T obj, bool IsCommit = true)
        {
            _context.Set<T>().Remove(obj);

            if (IsCommit)
            {
                _context.SaveChanges();
            }
        }
    }
}
