﻿using AutoMapper;
using TaskManager.ApplicationCore.Entities;
using TaskManager.ApplicationCore.Mediators.CreateTaskMediator;
using TaskManager.ApplicationCore.Mediators.GetTaskMediator;
using TaskManager.ApplicationCore.Mediators.UpdateTaskMediator;
using TaskManager.Contracts.Responses;
using TaskManager.ViewModels;

namespace TaskManager.ApplicationCore.Profiles;

public class TaskMapProfile : Profile
{
	public TaskMapProfile()
	{
		CreateMap<TaskViewModel, CreateTaskRequest>();
		CreateMap<TaskItem, TaskViewModel>();
		CreateMap<TaskResponse, TaskViewModel>();
		CreateMap<TaskViewModel, UpdateTaskRequest>();
		CreateMap<TaskResponse, UpdateTaskRequest >();
		CreateMap<TaskItem, TaskResponse>();
		CreateMap<Category, CategoriesResponse>();
	}
}
