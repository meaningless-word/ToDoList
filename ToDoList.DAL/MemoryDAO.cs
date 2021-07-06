using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ToDoList.DAL.Interface;
using ToDoList.Entities;

namespace ToDoList.DAL
{
	// пусть, помимо содержания списка, этот класс заботится о чтении и записи данных в json файле
	/// <summary>
	/// Объект под список задач
	/// </summary>
	public class MemoryDAO : IToDoListWriter
	{
		/// <summary>
		/// Список задач
		/// </summary>
		public List<Job> jobs;
		
		public MemoryDAO()
		{
			jobs = new List<Job>();
		}

		/// <summary>
		/// Считывание списка задач из файла
		/// </summary>
		public async Task GetAllFromFile(string filePath)
		{
			if (File.Exists(filePath))
			{
				using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
				{
					jobs = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Job>>(fs);
				}
			}
		}

		/// <summary>
		/// Записывание списка задач в файл
		/// </summary>
		public async Task SetAllToFile(string filePath)
		{
			using (FileStream fs = new FileStream(filePath, FileMode.Create))
			{
				await System.Text.Json.JsonSerializer.SerializeAsync<List<Job>>(fs, jobs);
			}
		}

	}
}
