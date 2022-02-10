using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VSRSample.Application.Businesses;
using VSRSample.Persistence.Businesses;
using VSRSample.Persistence.Context;

namespace VSRSample.Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }

        public static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IBaseBusiness, BaseBusiness>();
            services.AddTransient<ISharedBusiness, SharedBusiness>();
            services.AddTransient<IHomeBusiness, HomeBusiness>();
        }
    }
}
