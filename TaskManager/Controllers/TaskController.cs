using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskManager.ApplicationCore.Extensions;
using TaskManager.ApplicationCore.Interfaces;
using TaskManager.ApplicationCore.Mediators.CreateTaskMediator;
using TaskManager.ApplicationCore.Mediators.DeleteTaskMediator;
using TaskManager.ApplicationCore.Mediators.GetTasksByUsernameMediator;
using TaskManager.ApplicationCore.Mediators.UpdateTaskMediator;
using TaskManager.Contracts.Requests;
using TaskManager.Models;
using TaskManager.ViewModels;

namespace TaskManager.Controllers;


[Authorize]
public class TaskController : Controller
{
	// GET: TaskController
	private readonly IMapper _mapper;
	private readonly ICategoryService _categoryService;
	private readonly IMediator _mediator;
	public TaskController(IMapper mapper, ICategoryService categoryService, IMediator mediator)
	{
		_mapper = mapper;
		_categoryService = categoryService;
		_mediator = mediator;
	}

	public async Task<IActionResult> Index()
	{
		var viewModel = new TaskByUsernameResponse();

		if (User.GetUserId() != null)
		{
			viewModel = await _mediator.Send(new TaskByUsernameRequest(User.GetUserId()));
		}

		return View(viewModel);

	}

	// GET: TaskController/Details/5
	public ActionResult Details(int id)
	{
		return View();
	}

	// GET: TaskController/Create
	public async Task<IActionResult> Create()
	{
		var vm = new TaskViewModel();
		vm.Categories = await GetAllCategories();

		return View(vm);
	}

	// POST: TaskController/Create

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create(TaskViewModel collection)
	{


		if (ModelState.IsValid)
		{
			CreateTaskRequest taskRequest = _mapper.Map<CreateTaskRequest>(collection);
			taskRequest.UserId = User.GetUserId();
			taskRequest.DaysSelected = GetDaysSelected(collection.Days);

			var response = await _mediator.Send(taskRequest);

			if (response.TaskCreated)
			{
				return RedirectToAction("Index", "Home");
			}
		}

		collection.Categories = await GetAllCategories();
		return View(collection);


	}

	// GET: TaskController/Edit/5


	public async Task<IActionResult> Edit(int id)
	{
		var response = await _mediator.Send(new TaskByIdRequest(id));
		if (response.TaskItem == null) return NotFound();

		TaskViewModel taskView = _mapper.Map<TaskViewModel>(response.TaskItem);
		taskView.SetSelectedDays();
		taskView.Categories = await GetAllCategories();
		return View(taskView);
	}

	// POST: TaskController/Edit/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Edit(TaskViewModel collection)
	{
		try
		{
			var updateTaskRequest = _mapper.Map<UpdateTaskRequest>(collection);
			updateTaskRequest.UserId = User.GetUserId();
			updateTaskRequest.DaysSelected = GetDaysSelected(collection.Days);
			var response = await _mediator.Send(updateTaskRequest);
			if (response.TaskUpdated)
			{
				return RedirectToAction("Index", "Home");
			}
			collection.Categories = await GetAllCategories();
			return View(collection);
		}
		catch
		{
			return View();
		}
	}

	public async Task<IActionResult> CheckTask(int id)
	{
		//Get Task
		if (id == null)
		{
			return RedirectToAction(nameof(Index));
		}
		var response = await _mediator.Send(new TaskByIdRequest(id));
		if (response.TaskItem == null) return NotFound();


		//Map Task Response to UpdateTask
		var updateTaskRequest = _mapper.Map<UpdateTaskRequest>(response.TaskItem);
		updateTaskRequest.UserId = User.GetUserId();
		updateTaskRequest.Completed = true;
		//Update Task
		var updateResponse = await _mediator.Send(updateTaskRequest);

		return RedirectToAction(nameof(Index));
	}

	// GET: TaskController/Delete/5
	public IActionResult Delete(int id)
	{
		return View(new DeleteViewModel() { Id = id });
	}

	// POST: TaskController/Delete/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	[ActionName("Delete")]
	public async Task<IActionResult> DeleteItem(DeleteViewModel deleteView)
	{
		try
		{
			var response = await _mediator.Send(new DeleteTaskByIdRequest(deleteView.Id));
			if (response.TaskDeleted)
			{
				//alert sucessfully deleted
				return RedirectToAction(nameof(Index));
			}
			//alert: did not delete
			return RedirectToAction(nameof(Index));
		}
		catch
		{
			return View();
		}
	}



	private async Task<List<SelectListItem>> GetAllCategories()
	{
		var categories = await _categoryService.GetCategoriesAsync();
		return categories.ConvertAll(e => new SelectListItem()
		{
			Text = e.Name,
			Value = e.Id.ToString()

		});
	}

	private string GetDaysSelected(List<CheckboxInput> days)
	{
		var daysSelected = days.FindAll(e => e.IsChecked).Select(e => e.Text);
		return string.Join(",", daysSelected.ToArray());
	}
}
