using Ardalis.Specification;
using TaskManager.ApplicationCore.Entities;

namespace TaskManager.ApplicationCore.Specifications;

public class TaskByUserIdSpec : Specification<TaskItem>
{
	public TaskByUserIdSpec(string userId)
	{
		Query.Where(u => u.UserId == userId).Include("Category");
	}
}
