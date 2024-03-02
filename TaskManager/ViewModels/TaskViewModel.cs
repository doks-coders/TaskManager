using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TaskManager.ApplicationCore.Constants;
using TaskManager.Models;


namespace TaskManager.ViewModels;

/// <summary>
/// This model is used in the Edit and Create Views. It represents all the fields that should be filled and sent to the database
/// </summary>
public class TaskViewModel
{
	public int? Id { get; set; }
	[Required]
	[DisplayName("Task Message")]
	public string? TaskMessage { get; set; }
	[DisplayName("Date Chosen")]
	public DateTime DateChosen { get; set; } = DateTime.UtcNow;
	public bool Recurring { get; set; } = false;
	public string? CategoryId { get; set; }
	public List<CheckboxInput> Days { get; set; } = DaysOfWeek.Days().ConvertAll(e => new CheckboxInput { Text = e });
	[ValidateNever]
	public List<SelectListItem>? Categories { get; set; }
	public string DaysSelected { get; set; } = "";


	public void SetSelectedDays()
	{
		var days = DaysSelected.Split(',').ToList();
		if (!string.IsNullOrEmpty(DaysSelected) && DaysSelected.IndexOf(',') > 0)
		{
			Days = Days.Select((e, Index) =>
			{
				if (days.Contains(e.Text))
				{
					return new CheckboxInput() { IsChecked = true, Text = e.Text };
				}
				else
				{
					return new CheckboxInput() { IsChecked = false, Text = e.Text };
				}
			}).ToList();
		}

	}
}
