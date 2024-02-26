using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatientPortal.Domain.Contexts;
using PatientPortal.Domain.Repositories.Allergies;
using PatientPortal.Domain.Repositories.DiseaseInformations;
using PatientPortal.Domain.Repositories.NCDs;
using PatientPortal.Domain.Repositories.Patients;
using PatientPortal.Domain.UnitOfWork;

namespace PatientPortal.Domain
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDomainServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            const string connectionStrName = "PatientPortalDb";

            var connectionString = configuration.GetConnectionString(connectionStrName);

            services.AddTransient<IApplicationDbContext>(provider =>
                provider.GetRequiredService<ApplicationDbContext>());

            services.AddSingleton<EntityInterceptor>();

            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                var entityInterceptor = sp.GetService<EntityInterceptor>()!;

                options.UseSqlServer(connectionString)
                    .AddInterceptors(entityInterceptor);
            }, ServiceLifetime.Transient);

            services.AddScoped<IUnitOfWorks, UnitOfWorks>();
            services.AddScoped<IPatientsRepository, PatientsRepository>();
            services.AddScoped<IAllergiesRepository, AllergiesRepository>();
            services.AddScoped<IDiseaseInformationsRepository, DiseaseInformationsRepository>();
            services.AddScoped<INCDsRepository, NCDsRepository>();

            return services;
        }
    }
}
