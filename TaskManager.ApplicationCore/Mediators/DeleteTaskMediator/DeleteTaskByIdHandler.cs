using MediatR;
using TaskManager.ApplicationCore.Entities;
using TaskManager.ApplicationCore.Interfaces;


namespace TaskManager.ApplicationCore.Mediators.DeleteTaskMediator
{
	/// <summary>
	/// This contains the handler for the DeleteTaskById. It will be used for 
	/// registering our DeleteTaskByIdRequest and DeleteTaskByIdResponse
	/// </summary>
	/// 
	public class DeleteTaskByIdHandler : IRequestHandler<DeleteTaskByIdRequest, DeleteTaskByIdResponse>
	{
		private readonly IRepository<TaskItem> _taskRepository;
		public DeleteTaskByIdHandler(IRepository<TaskItem> taskRepository)
		{
			_taskRepository = taskRepository;
		}

		public async Task<DeleteTaskByIdResponse> Handle(DeleteTaskByIdRequest request, CancellationToken cancellationToken)
		{
			var task = await _taskRepository.GetByIdAsync(request.Id);
			if (task == null) return new DeleteTaskByIdResponse
			{
				TaskDeleted = false
			};
			await _taskRepository.DeleteAsync(task);
			return new DeleteTaskByIdResponse
			{
				TaskDeleted = true
			};
		}
	}
}
