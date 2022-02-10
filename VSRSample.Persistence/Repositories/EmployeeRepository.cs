using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VSRSample.Application.Repositories;
using VSRSample.Domain.Entities;
using VSRSample.Persistence.Context;

namespace VSRSample.Persistence.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly DatabaseContext _context;
        public EmployeeRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Employee> GetAll(Expression<Func<Employee, bool>> predicates = null!)
        {
            if (predicates == null)
            {
                return _context.Employees.Include(x => x.Company);
            }

            return _context.Employees.Where(predicates).Include(x => x.Company);
        }

        public Employee Get(Expression<Func<Employee, bool>> predicates)
            => _context.Employees.Include(x => x.Company).Where(predicates).FirstOrDefault();
    }
}
