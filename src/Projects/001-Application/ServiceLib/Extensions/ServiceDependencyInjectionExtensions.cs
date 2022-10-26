using CSD.Util.Mappers;
using CSD.Util.Mappers.Mapster;


using Microsoft.Extensions.DependencyInjection;

using Integral.CRM.Data.Repository;

namespace Integral.CRM.Data.Service;

public static class ServiceDependencyInjectionExtensions
{
    public static void AddServiceDependencies(this IServiceCollection services)
    {
        services.AddRepositoryDependencies();
        services.AddSingleton<IMapper, Mapper>();
        services.AddSingleton<IntegralCrmDbAppService>();
    }
}
