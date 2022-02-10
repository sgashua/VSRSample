using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VSRSample.Application.Repositories;
using VSRSample.Domain.Entities;
using VSRSample.Persistence.Context;

namespace VSRSample.Persistence.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        private readonly DatabaseContext _context;
        public CompanyRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Company> GetAll(Expression<Func<Company, bool>> predicates = null!)
        {
            if (predicates == null)
            {
                return _context.Companies.Include(x => x.Employees);
            }

            return _context.Companies.Where(predicates).Include(x => x.Employees);
        }

        public Company Get(Expression<Func<Company, bool>> predicates)
            => _context.Companies.Include(x => x.Employees).Where(predicates).FirstOrDefault();
    }
}
