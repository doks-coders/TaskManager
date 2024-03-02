using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Contracts.Responses;

namespace TaskManager.ApplicationCore.Mediators.GetTasksByUsernameMediator
{
	public class TaskByUsernameResponse
	{
		public List<TaskResponse> Tasks { get; set; } = new();
	}
}
