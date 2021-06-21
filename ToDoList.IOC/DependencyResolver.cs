using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ToDoList.BLL;
using ToDoList.BLL.Interface;
using ToDoList.DAL;
using ToDoList.DAL.Interface;
using ToDoList.Exceptions;
using ToDoList.Settings;

namespace ToDoList.IOC
{
	/// <summary>
	/// Объект для создания бизнес-логики
	/// </summary>
	public static class DependencyResolver
	{
		/// <summary>
		/// Объект под DAO
		/// </summary>
		private static IJobDAO jobDAO { get; } = new JobDAO();

		/// <summary>
		/// Объект под райтер
		/// </summary>
		private static IToDoListWriter toDoListJSONWriter { get; } = new ToDoListJSONWriter();

		/// <summary>
		/// Объект под бизнес-логику
		/// </summary>
		public static IToDoListLogic toDoListLogic { get; } = new ToDoListLogic(jobDAO);

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
