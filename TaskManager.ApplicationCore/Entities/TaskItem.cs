using TaskManager.ApplicationCore.Interfaces;
using TaskManager.ApplicationCore.Mediators.CreateTaskMediator;
using TaskManager.ApplicationCore.Mediators.UpdateTaskMediator;

namespace TaskManager.ApplicationCore.Entities;

public class TaskItem : BaseEntity<int>, IAggregateRoot
{
	/// <summary>
	/// This is the task item entity
	/// </summary>
	#region TaskItem fields
	public string UserId { get; private set; }
	public string TaskMessage { get; private set; }
	public bool Completed { get; private set; }
	public DateTime DateChosen { get; private set; }
	public bool Recurring { get; private set; } = false;
	public string DaysSelected { get; private set; }
	public DateTime DateCreated { get; private set; } = DateTime.UtcNow;
	public DateTime DateUpdated { get; private set; } = DateTime.UtcNow;
	public int CategoryId { get; private set; }
	public Category Category { get; set; }
	#endregion


	public void CreateTask(CreateTaskRequest createTaskRequest)
	{
		UserId = createTaskRequest.UserId;
		TaskMessage = createTaskRequest.TaskMessage;
		Completed = false;
		CategoryId = createTaskRequest.CategoryId;
		DateChosen = createTaskRequest.DateChosen;
		DaysSelected = createTaskRequest.DaysSelected;
	}

	public void UpdateTask(UpdateTaskRequest updateTaskRequest)
	{
		TaskMessage = updateTaskRequest.TaskMessage;
		Completed = updateTaskRequest.Completed;
		CategoryId = updateTaskRequest.CategoryId;
		DateUpdated = DateTime.UtcNow;
		DateCreated = updateTaskRequest.DateCreated;
		DateChosen = updateTaskRequest.DateChosen;
		DaysSelected = updateTaskRequest.DaysSelected;
		Recurring = updateTaskRequest.Recurring;
	}
}
