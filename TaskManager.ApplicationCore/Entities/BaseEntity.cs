using System.ComponentModel.DataAnnotations;

namespace TaskManager.ApplicationCore.Entities;

public abstract class BaseEntity<T>
{
	/// <summary>
	/// This is the base entity. it contains an Id property that will be the primary key for the enitities
	/// </summary>
	[Key]
	public virtual T Id { get; set; }
}
