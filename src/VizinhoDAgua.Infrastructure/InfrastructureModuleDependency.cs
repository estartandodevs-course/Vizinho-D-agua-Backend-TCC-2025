using Microsoft.Extensions.DependencyInjection;
using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Infrastructure.Repositories;

namespace VizinhoDAgua.Infrastructure
{
    public static class InfrastructureModuleDependency
    {
        public static void AddInfrastructureModule(this IServiceCollection services)
        {
            services.AddScoped<ICommunityRepository, CommunityRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IEducationContentRepository, EducationContentRepository>();
            services.AddScoped<ICommunityPostRepository, CommunityPostRepository>();
        }
    }
}