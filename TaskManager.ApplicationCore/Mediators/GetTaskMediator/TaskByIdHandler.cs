using AutoMapper;
using MediatR;
using TaskManager.ApplicationCore.Entities;
using TaskManager.ApplicationCore.Interfaces;
using TaskManager.ApplicationCore.Mediators.GetTaskMediator;
using TaskManager.ApplicationCore.Specifications;
using TaskManager.Contracts.Requests;
using TaskManager.Contracts.Responses;


namespace TaskManager.ApplicationCore.Mediators.TaskMediators;

public class TaskByIdHandler : IRequestHandler<TaskByIdRequest, TaskByIdResponse?>

{
	private readonly IRepository<TaskItem> _taskRepository;
	private readonly IMapper _mapper;

	public TaskByIdHandler(IRepository<TaskItem> taskRepository, IMapper mapper)
	{
		_taskRepository = taskRepository;
		_mapper = mapper;
	}

	//Get Specific Task
	public async Task<TaskByIdResponse?> Handle(TaskByIdRequest request,
		CancellationToken cancellationToken)
	{
		var spec = new TaskByIdSpec(request.Id);
		var task = await _taskRepository.FirstOrDefaultAsync(spec, cancellationToken);
		var convertedTask = _mapper.Map<TaskResponse>(task);
		if (task == null)
		{
			return null;
		}

		return new TaskByIdResponse
		{
			TaskItem = convertedTask
		};
	}

}
