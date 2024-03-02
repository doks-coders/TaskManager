using MediatR;
using TaskManager.ApplicationCore.Mediators.GetTasksByUsernameMediator;


namespace TaskManager.Contracts.Requests;



public class TaskByUsernameRequest : IRequest<TaskByUsernameResponse>
{
	public string UserId { get; private set; }

	public TaskByUsernameRequest(string userId)
	{
		UserId = userId;
	}
}
