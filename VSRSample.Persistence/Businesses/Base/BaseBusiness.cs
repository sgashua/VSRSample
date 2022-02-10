using VSRSample.Application.Businesses;
using VSRSample.Persistence.Context;

namespace VSRSample.Persistence.Businesses
{
    public class BaseBusiness : IBaseBusiness
    {
        private readonly DatabaseContext _context;
        public BaseBusiness(DatabaseContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
