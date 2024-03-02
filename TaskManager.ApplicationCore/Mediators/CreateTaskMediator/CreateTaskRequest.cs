using MediatR;

namespace TaskManager.ApplicationCore.Mediators.CreateTaskMediator
{
	public class CreateTaskRequest : IRequest<CreateTaskResponse>
	{
		public required string UserId { get; set; }
		public required string TaskMessage { get; set; }
		public DateTime DateChosen { get; set; }
		public bool Recurring { get; set; } = false;
		public required string DaysSelected { get; set; }
		public int CategoryId { get; set; }
	}
}
