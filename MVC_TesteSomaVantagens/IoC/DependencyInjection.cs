using IntermediateModels.Repositories;
using IntermediateModels.Repositories.Interfaces;
using IntermediateModels.UnitOfWork.Interfaces;
using IntermediateModels.UnitOfWork;
using IntermediateModels.Services.Interfaces;
using IntermediateModels.Services;

namespace IntermediateModels.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services,
                                                          IConfiguration configuration)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWorkImplementation>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}
