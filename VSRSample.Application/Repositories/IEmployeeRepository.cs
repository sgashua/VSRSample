using System.Linq.Expressions;
using VSRSample.Domain.Entities;

namespace VSRSample.Application.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Employee Get(Expression<Func<Employee, bool>> predicates);
        IQueryable<Employee> GetAll(Expression<Func<Employee, bool>> predicates = null!);
    }
}