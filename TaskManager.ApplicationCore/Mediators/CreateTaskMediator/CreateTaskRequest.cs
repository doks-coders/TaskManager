using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationCore.Mediators.CreateTaskMediator
{
	public class CreateTaskRequest:IRequest<CreateTaskResponse>
	{
		public required string UserId { get; set; }
		public required string TaskMessage { get; set; }
		public DateTime DateChosen { get; set; }
		public bool Recurring { get; set; } = false;
		public required string DaysSelected { get; set; }
		public int CategoryId { get; set; }
	}
}
