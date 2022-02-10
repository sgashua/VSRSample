using VSRSample.Application.Businesses;
using VSRSample.Persistence.Context;

namespace VSRSample.Persistence.Businesses
{
    public class HomeBusiness : SharedBusiness, IHomeBusiness
    {
        private readonly DatabaseContext _context;
        public HomeBusiness(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        //Customised methods here for Home Controller
    }
}
