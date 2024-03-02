using MediatR;
using TaskManager.ApplicationCore.Mediators.GetTaskMediator;

namespace TaskManager.Contracts.Requests;

public class TaskByIdRequest : IRequest<TaskByIdResponse>
{
	public int Id { get; set; }
	public TaskByIdRequest(int id)
	{
		Id = id;
	}
}
