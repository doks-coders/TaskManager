using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.ApplicationCore.Entities;

namespace TaskManager.Infrastructure.Config;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		builder.Property(x => x.Name).IsRequired();
		builder.HasMany(u => u.MyTasks)
			.WithOne(u => u.Category)
			.HasForeignKey("CategoryId");
	}
}
