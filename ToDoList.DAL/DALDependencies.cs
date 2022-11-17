using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.DAL
{
    public static class DALDependencies
    {
        public static IServiceCollection AddDbDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<ToDoListDBContext>(
            options =>
            {
                string connection = configuration.GetConnectionString("DBConnection");
                options.UseMySql("server=localhost\\SQLEXPRESS;database=library;encrypt=false;",
                    ServerVersion.AutoDetect(connection));
            });
            return services;
        }
    }
}
