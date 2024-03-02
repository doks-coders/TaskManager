using MediatR;
using TaskManager.ApplicationCore.Entities;
using TaskManager.ApplicationCore.Interfaces;

namespace TaskManager.ApplicationCore.Mediators.UpdateTaskMediator
{
	/// <summary>
	/// This contains the handler for the UpdateTask. It will be used for 
	/// registering our updateTaskRequest and UpdateTaskResponse
	/// </summary>
	public class UpdateTaskHandler : IRequestHandler<UpdateTaskRequest, UpdateTaskResponse>
	{
		private readonly IRepository<TaskItem> _taskRepository;
		public UpdateTaskHandler(IRepository<TaskItem> taskRepository)
		{
			_taskRepository = taskRepository;
		}

		public async Task<UpdateTaskResponse> Handle(UpdateTaskRequest request, CancellationToken cancellationToken)
		{
			var task = await _taskRepository.GetByIdAsync(request.Id);
			request.DateCreated = task.DateCreated;
			task.UpdateTask(request);
			await _taskRepository.UpdateAsync(task);

			return new UpdateTaskResponse
			{
				TaskUpdated = true
			};
		}
	}
}
