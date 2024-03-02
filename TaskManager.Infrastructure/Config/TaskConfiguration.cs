using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.ApplicationCore.Entities;


namespace TaskManager.Infrastructure.Config;

public class TaskConfiguration : IEntityTypeConfiguration<TaskItem>
{
	public void Configure(EntityTypeBuilder<TaskItem> builder)
	{
		builder.Property(x => x.CategoryId).IsRequired();
	}
}
