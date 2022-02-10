using VSRSample.Application.Businesses;
using VSRSample.Application.Repositories;
using VSRSample.Persistence.Context;
using VSRSample.Persistence.Repositories;

namespace VSRSample.Persistence.Businesses
{
    public class SharedBusiness : BaseBusiness, ISharedBusiness
    {
        private readonly DatabaseContext _context;
        #region Repository
        private ICompanyRepository _company;
        private IEmployeeRepository _employee;
        public ICompanyRepository Company { get => _company ??= new CompanyRepository(_context); }
        public IEmployeeRepository Employee { get => _employee ??= new EmployeeRepository(_context); }
        #endregion

        public SharedBusiness(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        //Customised methods here for all controllers to use
    }
}
