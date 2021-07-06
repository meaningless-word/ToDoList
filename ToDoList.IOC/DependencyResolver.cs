using System;
using System.IO;
using ToDoList.BLL;
using ToDoList.BLL.Interface;
using ToDoList.DAL;
using ToDoList.DAL.Interface;
using ToDoList.Entities.Configuration;

namespace ToDoList.IOC
{
	/// <summary>
	/// Объект для создания бизнес-логики
	/// </summary>
	public class DependencyResolver
	{
		private IBaseRepository baseRepository;

		/// <summary>
		/// Объект под бизнес-логику
		/// </summary>
		public IToDoListLogic toDoListLogic { get; } 
		
		public DependencyResolver(ConfigurationDAL configurationDAL)
		{
			baseRepository = GetBaseRepositoryByType(configurationDAL);
			toDoListLogic = new ToDoListLogic(baseRepository.jobDAO);
		}

		private IBaseRepository GetBaseRepositoryByType(ConfigurationDAL configurationDAL)
		{
			string fileFullPth = Path.Combine(configurationDAL.filePath.Length == 0 ? Directory.GetParent(AppContext.BaseDirectory).FullName : configurationDAL.filePath, configurationDAL.fileName);
			switch (configurationDAL.type)
			{
				case TypeOfDAO.SQLite:
					return new SQLiteBaseRepository(fileFullPth);
				case TypeOfDAO.JSON:
					return new MemoryBaseRepository(fileFullPth);
				default:
					throw new ArgumentException("Can't resolve type for JobDAO");
			}
		}
/*
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
*/
	}
}
