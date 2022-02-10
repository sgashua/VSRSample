using VSRSample.Application.Repositories;

namespace VSRSample.Application.Businesses
{
    public interface ISharedBusiness : IBaseBusiness
    {
        ICompanyRepository Company { get; }
        IEmployeeRepository Employee { get; }
    }
}