using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskManager.ApplicationCore.Entities;
using TaskManager.Infrastructure.Data;
using TaskManager.Infrastructure.Identity;

namespace TaskManager.Infrastructure.Seed;

public static class ApplicationSeed
{
	/// <summary>
	/// This method seeds into the database, whenever the database is empty
	/// </summary>
	/// <param name="userManager"></param>
	/// <param name="roleManager"></param>
	/// <param name="context"></param>
	/// <param name="logger"></param>
	/// <returns></returns>
	public static async Task SeedDatabase(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context, ILogger logger)
	{
		if (!await userManager.Users.AnyAsync())
		{
			logger.LogInformation("Seed begins");
			//Add Roles
			List<string> roles = new() { "Admin", "Customer" };
			var IdentityRoles = roles.ConvertAll(x => new IdentityRole()
			{
				Name = x
			});

			foreach (var role in IdentityRoles)
			{
				await roleManager.CreateAsync(role);
				logger.LogInformation($"{role.Name} Roles Added");
			}

			ApplicationUser user = new();
			user.Email = "admin@mail.com";
			user.PhoneNumber = "898989942";
			user.UserName = "admin@mail.com";
			//HACK! Will make the password secret
			var result = await userManager.CreateAsync(user, "Password1234&");
			await userManager.AddToRolesAsync(user, new[] { "Admin", "Customer" });
			logger.LogInformation($"{user.UserName} User Added");

			var categories = new List<Category>() {
				new Category("Exercise"),
				new Category("Study"),
				new Category("Entertainment"),
				new Category("Self/Care")
			};
			await context.Categories.AddRangeAsync(categories);
			await context.SaveChangesAsync();


		}
		else
			logger.LogInformation("Seed Should not begin");

	}
}
