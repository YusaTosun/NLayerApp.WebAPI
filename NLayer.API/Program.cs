using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repository;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository;
using NLayer.Repository.UnitOfWorks;
using System.Reflection;
using NLayer.Core;
using NLayer.Repository.Repositories;
using NLayer.Core.Services;
using NLayer.Services.Services;
using NLayer.Services.Mapping;
using FluentValidation.AspNetCore;
using NLayer.Core.DTOs;
using NLayer.Services.Validations;

namespace NLayer.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddScoped<IUnitOfWorks, UnitOfWork>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            builder.Services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>

                option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name));
            });
            builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
            builder.Services.AddAutoMapper(typeof(MapProfile)); /// todo: Buras� Profile da yap�labilir miydi ?? 


            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

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