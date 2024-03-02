using TaskManager.Contracts.Responses;

namespace TaskManager.ApplicationCore.Mediators.GetTasksByUsernameMediator
{
	public class TaskByUsernameResponse
	{
		public List<TaskResponse> Tasks { get; set; } = new();
	}
}
