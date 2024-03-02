using AutoMapper;
using MediatR;
using TaskManager.ApplicationCore.Entities;
using TaskManager.ApplicationCore.Interfaces;

namespace TaskManager.ApplicationCore.Mediators.UpdateTaskMediator
{
	public class UpdateTaskHandler : IRequestHandler<UpdateTaskRequest, UpdateTaskResponse>
	{
		private readonly IRepository<TaskItem> _taskRepository;
		private readonly IMapper _mapper;
		public UpdateTaskHandler(IMapper mapper, IRepository<TaskItem> taskRepository)
		{
			_mapper = mapper;
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
