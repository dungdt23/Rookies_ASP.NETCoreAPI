
using Rookies_ASP.NETCoreAPI.API.Dtos;
using Rookies_ASP.NETCoreAPI.API.Services;
using Rookies_ASP.NETCoreAPI.Infrastructure.Repositories;

namespace Rookies_ASP.NETCoreAPI.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton<ITaskRepository, TaskRepository>();
            builder.Services.AddSingleton<ITaskService, TaskService>();
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
