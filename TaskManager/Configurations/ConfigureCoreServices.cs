using Microsoft.EntityFrameworkCore;
using TaskManager.ApplicationCore.Interfaces;
using TaskManager.ApplicationCore.Mediators.TaskMediators;
using TaskManager.ApplicationCore.Services;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Configurations;

public static class ConfigureCoreServices
{
	public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration config)
	{
		services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
		services.AddScoped<ICategoryService, CategoryService>();
		services.AddMediatR(cfg =>
		cfg.RegisterServicesFromAssembly(typeof(TaskByIdHandler).Assembly));


		services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
		return services;
	}
}
