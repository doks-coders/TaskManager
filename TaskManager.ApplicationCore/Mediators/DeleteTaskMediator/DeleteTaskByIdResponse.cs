using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationCore.Mediators.DeleteTaskMediator
{
	public class DeleteTaskByIdResponse
	{
		public bool TaskDeleted { get; set; } = new();
	}
}
