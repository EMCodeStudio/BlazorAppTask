
using BlazorAppTask.Models;

public class TaskService
{


	// Definimos Datos para el Modelo de Tareas
	private readonly List<TaskModel> newTaskData =
	[
		new() {Id = 1 ,IsDone = false, Title= "Title 1", Description = "Description 1"},
		new() {Id= 2, IsDone = true, Title = "Title 2", Description = "Description 2" }
	];
	public IReadOnlyList<TaskModel> NewTaskItemList => newTaskData;


	// Metodo para Crear una Tarea
	public void AddTask(int taskIdData , string taskTitleData, string taskDescriptionData)
	{
		if (!string.IsNullOrWhiteSpace(taskTitleData) && !string.IsNullOrWhiteSpace(taskDescriptionData))
		{
			newTaskData.Add(new TaskModel {Id = taskIdData, Title = taskTitleData, Description = taskDescriptionData });
		}
	}


	// Metodo para Leer una Tarea
	public TaskModel? GetTaskById(int id)
	{
		var taskDataRead = newTaskData.FirstOrDefault(taskData => taskData.Id == id);
		if (taskDataRead != null)
		{
			return taskDataRead;
		}
			return null;
	}


	// Metodo para Actualizar una Tarea
	public void EditTask(int taskIdData, string taskTitleData, string taskDescriptionData)
	{
		var taskDataUpdate = newTaskData.FirstOrDefault(taskData => taskData.Id == taskIdData);
		if (taskDataUpdate != null)
		{
			taskDataUpdate.Title = taskTitleData;
			taskDataUpdate.Description = taskDescriptionData;
		}
	}


	// Metodo para Eliminar una Tarea
	public void RemoveTask(int id)
	{
		var taskDataDelete = newTaskData.FirstOrDefault(taskData => taskData.Id == id);
		if (taskDataDelete != null)
		{
			newTaskData.Remove(taskDataDelete);
		}
	}
}
