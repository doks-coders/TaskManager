using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationCore.Mediators.CreateTaskMediator
{
	public class CreateTaskResponse
	{
		public bool TaskCreated { get; set; } = new();
	}
}
