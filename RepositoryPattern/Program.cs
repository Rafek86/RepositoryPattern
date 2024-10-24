
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Core.IConfiguration;
using RepositoryPattern.Data;

namespace RepositoryPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<AppDbContext>(
                option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                );

            //Adding The Usni Of Work to the DI Container
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            
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
