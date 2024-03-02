
using TaskManager.ApplicationCore.Entities;
using TaskManager.ApplicationCore.Interfaces;
namespace TaskManager.ApplicationCore.Services;

public class CategoryService : ICategoryService
{
	private readonly IRepository<Category> _repository;
	public CategoryService(IRepository<Category> repository)
	{
		_repository = repository;
	}

	public async Task<List<Category>> GetCategoriesAsync()
	{
		return await _repository.ListAsync();
	}

}
