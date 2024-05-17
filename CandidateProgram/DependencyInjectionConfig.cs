using CandidateProgram.DataContext;
using CandidateProgram.Interfaces;
using CandidateProgram.Repositories;
using CandidateProgram.Services;

namespace CandidateProgram
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<CosmosDbContext>();

            services.AddScoped<IProgramService, ProgramService>();

            services.AddScoped<IProgramRepository, ProgramRepository>();

            return services;
        }
    }
}
