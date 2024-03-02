using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ApplicationCore.Entities;
using TaskManager.ApplicationCore.Interfaces;
using TaskManager.ApplicationCore.Specifications;
using TaskManager.Contracts.Requests;
using TaskManager.Contracts.Responses;


namespace TaskManager.ApplicationCore.Mediators.GetTasksByUsernameMediator
{
	public class TaskByUsernameHandler : IRequestHandler<TaskByUsernameRequest, TaskByUsernameResponse>
	{
		private readonly IRepository<TaskItem> _taskRepository;
		private readonly IMapper _mapper;
		public TaskByUsernameHandler(IMapper mapper,IRepository<TaskItem> taskRepository)
		{
			_mapper = mapper;
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
