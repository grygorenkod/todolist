using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ToDoList.BLL;
using ToDoList.BLL.Interfaces;
using ToDoList.DAL;
using ToDoList.DAL.Interfaces;

namespace ToDoList.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string? connection = builder.Configuration.GetConnectionString("DBConnection");
            builder.Services.AddDbContext<ToDoListDBContext>(options => options.UseSqlServer(connection));

            //Add services to the container
            //builder.Services.AddBLLDependencies(builder.Configuration);
            builder.Services.AddScoped<ICategoryBLL, CategoryBLL>();
            builder.Services.AddScoped<IToDoBLL, ToDoBLL>();
            builder.Services.AddScoped<ICategoryDAL, CategoryDAL>();
            builder.Services.AddScoped<IToDoDAL, ToDoDAL>();
            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
                options.AddDefaultPolicy(
                builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDoList", Version = "v1" });
            });


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDoList v1");
                options.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}