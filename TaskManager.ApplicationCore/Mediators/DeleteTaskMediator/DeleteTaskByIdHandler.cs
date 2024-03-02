using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ApplicationCore.Entities;
using TaskManager.ApplicationCore.Interfaces;


namespace TaskManager.ApplicationCore.Mediators.DeleteTaskMediator
{
	public class DeleteTaskByIdHandler:IRequestHandler<DeleteTaskByIdRequest,DeleteTaskByIdResponse>
	{
		private readonly IRepository<TaskItem> _taskRepository;
		private readonly IMapper _mapper;
		public DeleteTaskByIdHandler(IMapper mapper, IRepository<TaskItem> taskRepository)
		{
			_mapper = mapper;
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
