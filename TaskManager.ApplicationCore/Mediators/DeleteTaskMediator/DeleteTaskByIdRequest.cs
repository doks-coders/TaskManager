using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationCore.Mediators.DeleteTaskMediator
{
	public class DeleteTaskByIdRequest:IRequest<DeleteTaskByIdResponse>
	{
		public int Id { get; set; }
		public DeleteTaskByIdRequest(int id)
		{
			Id = id;
		}
	}
}
