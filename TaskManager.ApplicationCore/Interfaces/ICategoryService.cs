

using TaskManager.ApplicationCore.Entities;

namespace TaskManager.ApplicationCore.Interfaces;

/// <summary>
/// This is the service for the Category table
/// </summary>
public interface ICategoryService
{
	Task<List<Category>> GetCategoriesAsync();
}
