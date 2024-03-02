using Ardalis.Specification.EntityFrameworkCore;
using TaskManager.ApplicationCore.Interfaces;

namespace TaskManager.Infrastructure.Data;

public class EfRepository<T> : RepositoryBase<T>, IRepository<T> where T : class, IAggregateRoot
{
	public EfRepository(ApplicationDbContext dbContext) : base(dbContext)
	{
	}
}
