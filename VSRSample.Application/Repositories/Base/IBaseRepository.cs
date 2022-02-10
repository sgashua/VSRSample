using VSRSample.Domain.Entities;

namespace VSRSample.Application.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Delete(T obj, bool IsCommit = true);
        void Save(T obj, bool IsCommit = true);
    }
}