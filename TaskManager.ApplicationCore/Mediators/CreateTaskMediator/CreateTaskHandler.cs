using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ApplicationCore.Entities;
using TaskManager.ApplicationCore.Interfaces;


namespace TaskManager.ApplicationCore.Mediators.CreateTaskMediator
{
	public class CreateTaskHandler : IRequestHandler<CreateTaskRequest, CreateTaskResponse>
	{
		private readonly IRepository<TaskItem> _taskRepository;
		private readonly IMapper _mapper;
		public CreateTaskHandler(IMapper mapper, IRepository<TaskItem> taskRepository)
		{
			_mapper = mapper;
			_taskRepository = taskRepository;
		}

		public async Task<CreateTaskResponse> Handle(CreateTaskRequest request, CancellationToken cancellationToken)
		{
			var task = new TaskItem();
			task.CreateTask(request);
			var res = await _taskRepository.AddAsync(task);
			if (res != null)
			{
				return new CreateTaskResponse
				{
					TaskCreated = true
				};
			}
			return new CreateTaskResponse
			{
				TaskCreated = false
			};

		}
	}
}
