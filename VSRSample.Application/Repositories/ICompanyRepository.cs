using System.Linq.Expressions;
using VSRSample.Domain.Entities;

namespace VSRSample.Application.Repositories
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        Company Get(Expression<Func<Company, bool>> predicates);
        IQueryable<Company> GetAll(Expression<Func<Company, bool>> predicates = null!);
    }
}