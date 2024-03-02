using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Contracts.Responses;

namespace TaskManager.ApplicationCore.Mediators.GetTaskMediator
{
	public class TaskByIdResponse
	{
		public TaskResponse TaskItem { get; set; } = new();
	}
}
