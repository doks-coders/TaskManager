using TaskManager.ApplicationCore.Interfaces;

namespace TaskManager.ApplicationCore.Entities;

public class Category : BaseEntity<int>, IAggregateRoot
{
	/// <summary>
	/// This is the category entity
	/// </summary>
	public string Name { get; private set; }
	public List<TaskItem> MyTasks { get; private set; }

	public Category(string name)
	{
		Name = name;
	}



}
