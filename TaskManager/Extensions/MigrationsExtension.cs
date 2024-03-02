using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManager.Infrastructure.Data;
using TaskManager.Infrastructure.Identity;
using TaskManager.Infrastructure.Seed;

namespace TaskManager.Extensions;

public static class MigrationsExtension
{
	/// <summary>
	/// This contains the migration code for the application
	/// </summary>
	/// <param name="app">
	/// The Microsoft.AspNetCore.Builder.IApplicationBuilder to add the middleware to.
	/// </param>
	/// <returns>A reference to app after the operation has completed</returns>
	public static async Task<WebApplication> Migrate(this WebApplication app)
	{
		using (var program = app.Services.CreateScope())
		{
			var service = program.ServiceProvider;

			var logger = service.GetService<ILogger<Program>>();
			try
			{
				var applicationDbContext = service.GetRequiredService<ApplicationDbContext>();
				var appIdentityContext = service.GetRequiredService<AppIdentityContext>();
				var userManager = service.GetRequiredService<UserManager<IdentityUser>>();
				var rolesManager = service.GetRequiredService<RoleManager<IdentityRole>>();
				await appIdentityContext.Database.MigrateAsync();
				await applicationDbContext.Database.MigrateAsync();

				await ApplicationSeed.SeedDatabase(userManager, rolesManager, applicationDbContext, logger);
			}
			catch (Exception ex)
			{
				logger.LogError(ex.Message, ex);

			}


		}
		return app;
	}
}
