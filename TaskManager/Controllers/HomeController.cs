using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskManager.ApplicationCore.Extensions;
using TaskManager.ApplicationCore.Mediators.GetTasksByUsernameMediator;
using TaskManager.Contracts.Requests;
using TaskManager.ViewModels;

namespace TaskManager.Controllers;

public class HomeController : Controller
{
	private readonly IMediator _mediator;
	public HomeController(IMediator mediator)
	{
		_mediator = mediator;
	}

	public async Task<IActionResult> Index()
	{
		
		return View();
	}


	public IActionResult Privacy()
	{
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}
