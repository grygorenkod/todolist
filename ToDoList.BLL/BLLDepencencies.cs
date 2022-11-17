using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.DAL;
using ToDoList.DAL.Interfaces;

namespace ToDoList.BLL
{
    public static class BLLDepencencies
    {
        public static IServiceCollection AddBLLDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbDependencies(configuration);
            services.AddScoped<ICategoryDAL, CategoryDAL>();
            services.AddScoped<IToDoDAL, ToDoDAL>();
            return services;
        }
    }
}
