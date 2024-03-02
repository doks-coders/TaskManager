using MediatR;
using TaskManager.ApplicationCore.Entities;
using TaskManager.ApplicationCore.Interfaces;
using TaskManager.ApplicationCore.Specifications;
using TaskManager.Contracts.Requests;
using TaskManager.Contracts.Responses;


namespace TaskManager.ApplicationCore.Mediators.GetTasksByUsernameMediator
{
	/// <summary>
	/// This contains the handler for the TaskByUsername. It will be used for 
	/// registering our TaskByUsernameRequest and TaskByUsernameResponse
	/// </summary>
	public class TaskByUsernameHandler : IRequestHandler<TaskByUsernameRequest, TaskByUsernameResponse>
	{
		private readonly IRepository<TaskItem> _taskRepository;
		public TaskByUsernameHandler(IRepository<TaskItem> taskRepository)
		{
			_taskRepository = taskRepository;
		}
		public async Task<TaskByUsernameResponse> Handle(TaskByUsernameRequest request, CancellationToken cancellationToken)
		{
			var spec = new TaskByUserIdSpec(request.UserId);
			var tasks = await _taskRepository.ListAsync(spec, cancellationToken);

			var convertedTasks = _mapper.Map<List<TaskResponse>>(tasks);

			if (tasks == null)
			{
				return null;
			}

			return new TaskByUsernameResponse
			{
				Tasks = convertedTasks
			};
		}
	}
}
