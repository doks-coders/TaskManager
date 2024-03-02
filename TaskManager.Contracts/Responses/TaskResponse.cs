namespace TaskManager.Contracts.Responses;

public class TaskResponse
{
	public int Id { get; set; }
	public string UserId { get; set; } = string.Empty;
	public string TaskMessage { get; set; } = string.Empty;
	public bool Completed { get; set; }
	public DateTime DateChosen { get; set; }
	public bool Recurring { get; set; }
	public string DaysSelected { get; set; } = string.Empty;
	public DateTime DateCreated { get; set; }
	public DateTime DateUpdated { get; set; }
	public int CategoryId { get; set; }
	public CategoriesResponse Category { get; set; } = new();
}
