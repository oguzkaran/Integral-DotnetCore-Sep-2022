using Integral.CRM.Data.DAL;
using Microsoft.Extensions.DependencyInjection;

namespace Integral.CRM.Data.Repository;

public static class RepositoryDependencyInjectionExtensions
{
    public static void AddRepositoryDependencies(this IServiceCollection services)
    {
        services.AddSingleton<IntegralCrmdbContext>();
        services.AddSingleton<ICustomerRepository, CustomerRepository>();
        services.AddSingleton<ICustomerInfoRepository, CustomerInfoRepository>();
        services.AddSingleton<IntegralCRMAppHelper>();        
    }
}
