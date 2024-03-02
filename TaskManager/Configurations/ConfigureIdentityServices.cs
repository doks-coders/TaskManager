using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManager.Infrastructure.Identity;

namespace TaskManager.Configurations;

public static class ConfigureIdentityServices
{
	public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("AppIdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'AppIdentityContextConnection' not found.");

		services.AddDbContext<AppIdentityContext>(options => options.UseSqlServer(connectionString));

		services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityContext>().AddDefaultTokenProviders();

		return services;
	}
}
