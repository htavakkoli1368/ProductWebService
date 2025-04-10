
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductWebService.Infrastructure.Context;
using ProductWebService.Model.Services;
using System.Globalization;

namespace ProductWebService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            // Set the default culture explicitly
              // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ProductDatabaseContext>(p => p.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddTransient<IProductService, ProductService>();
            builder.Services.AddTransient<ICategoryService, CategoryService>();
            builder.Services.AddControllers();
            builder.Services.AddAuthorization();
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
