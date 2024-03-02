using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskManager.ApplicationCore.Entities;

namespace TaskManager.Infrastructure.Data;

/// <summary>
/// This DbContext will contain all the tables for our Categories and Tasks
/// </summary>
public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{

	}

	public DbSet<Category> Categories { get; set; }
	public DbSet<TaskItem> TaskItems { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}
