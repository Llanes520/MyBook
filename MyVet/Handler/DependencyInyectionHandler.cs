using MyVet.Domain.Services.Interface;
using MyVet.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Common.Utils.RestServices.Interfaces;
using Common.Utils.RestServices;

namespace MyVet.Handler
{
    public static class DependencyInyectionHandler
    {
        public static void DependencyInyectionConfig(IServiceCollection services)
        {
            // Repository await UnitofWork parameter ctor explicit
            //services.AddScoped<UnitOfWork, UnitOfWork>();


            // Infrastructure
            //services.AddTransient<IUnitOfWork, UnitOfWork>();

            //services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            //services.AddTransient<SeedDb>();

            //Domain
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IRolServices, RolServices>();
            services.AddTransient<IBookServices, BookServices>();
            services.AddTransient<IEditorialService, EditorialService>();
            services.AddTransient<IAuthorService, AuthorsService>();

            //RestService
            services.AddTransient<IRestServices, RestServices>();
        }
    } 
}
