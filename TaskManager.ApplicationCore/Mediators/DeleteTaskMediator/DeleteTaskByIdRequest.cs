using MediatR;

namespace TaskManager.ApplicationCore.Mediators.DeleteTaskMediator
{
	public class DeleteTaskByIdRequest : IRequest<DeleteTaskByIdResponse>
	{
		public int Id { get; set; }
		public DeleteTaskByIdRequest(int id)
		{
			Id = id;
		}
	}
}
