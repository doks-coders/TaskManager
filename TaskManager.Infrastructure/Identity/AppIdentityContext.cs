using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Infrastructure.Identity;

/// <summary>
/// This dbContext contains all our Users tables
/// </summary>
public class AppIdentityContext : IdentityDbContext<IdentityUser>
{
	public AppIdentityContext(DbContextOptions<AppIdentityContext> options) : base(options)
	{

	}

	public DbSet<IdentityUser> Users { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
	}
}
