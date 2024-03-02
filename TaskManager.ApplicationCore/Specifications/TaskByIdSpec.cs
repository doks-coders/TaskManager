using Ardalis.Specification;
using TaskManager.ApplicationCore.Entities;



namespace TaskManager.ApplicationCore.Specifications;


public class TaskByIdSpec : Specification<TaskItem>
{
	public TaskByIdSpec(int taskId)
	{
		Query
			.Where(task => task.Id == taskId);
	}
}
