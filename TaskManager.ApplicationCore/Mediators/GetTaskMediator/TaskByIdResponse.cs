using TaskManager.Contracts.Responses;

namespace TaskManager.ApplicationCore.Mediators.GetTaskMediator
{
	public class TaskByIdResponse
	{
		public TaskResponse TaskItem { get; set; } = new();
	}
}
