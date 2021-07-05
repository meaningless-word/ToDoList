using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ToDoList.BLL;
using ToDoList.BLL.Interface;
using ToDoList.DAL;
using ToDoList.DAL.Interface;
using ToDoList.Entities.Configuration;
using ToDoList.Exceptions;
using ToDoList.Settings;

namespace ToDoList.IOC
{
	/// <summary>
	/// Объект для создания бизнес-логики
	/// </summary>
	public class DependencyResolver
	{
		/// <summary>
		/// Объект под DAO
		/// </summary>
		private IJobDAO jobDAO;

		/// <summary>
		/// Объект под бизнес-логику
		/// </summary>
		public IToDoListLogic toDoListLogic { get; } 
		
		public DependencyResolver(ConfigurationDAL configurationDAL)
		{

			jobDAO = GetJobDAOByType(configurationDAL.type);
			toDoListLogic = new ToDoListLogic(jobDAO);
		}

		private IJobDAO GetJobDAOByType(TypeOfDAO typeOfDAO)
		{
			switch (typeOfDAO)
			{
				case TypeOfDAO.File:
					return null;
				case TypeOfDAO.Memory:
					return new JobDAO();
				default:
					throw new ArgumentException("Can't resolve type for JobDAO");
			}
		}

		/// <summary>
		/// Объект под райтер
		/// </summary>
		private static IToDoListWriter toDoListJSONWriter { get; } = new ToDoListJSONWriter();



		/// <summary>
		/// Считывает значение конфиги, и если это JSON, то считывает записанные в файле JSON значения
		/// </summary>
		public static async Task GetTypeDAL()
		{
			try
			{
				using (FileStream fs = new FileStream(Config.configPath, FileMode.OpenOrCreate))
				{
					Config.restoredConfig = await JsonSerializer.DeserializeAsync<ConfigObject>(fs);
				}

				if (Config.restoredConfig.TypeDAL == "JSON")
					await toDoListJSONWriter.GetAllFromFile(Config.jsonPath);
			}
			catch
			{
				throw new JSONException();
			}
		}

		public static async Task SetTypeDAL()
		{
			try
			{
				if (Config.restoredConfig.TypeDAL == "JSON")
					await toDoListJSONWriter.SetAllToFile(Config.jsonPath);
			}
			catch
			{
				throw new JSONException();
			}
		}
	}
}
