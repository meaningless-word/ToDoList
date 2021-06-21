using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ToDoList.DAL.Interface;
using ToDoList.Entities;

namespace ToDoList.DAL
{
	/// <summary>
	/// Объект под райтер в слое данных
	/// </summary>
	public class ToDoListJSONWriter : IToDoListWriter
	{
		/// <summary>
		/// Считывание списка задач из файла
		/// </summary>
		public async Task GetAllFromFile(string filePath)
		{
			if (File.Exists(filePath))
			{
				using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
				{
					MemoryDAO.jobs = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Job>>(fs);
				}
			}
		}

		/// <summary>
		/// Записывание списка задач в файл
		/// </summary>
		public async Task SetAllToFile(string filePath)
		{
			FileInfo f = new FileInfo(filePath);
			f.Delete();

			using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
			{
				await System.Text.Json.JsonSerializer.SerializeAsync<List<Job>>(fs, MemoryDAO.jobs);
			}
		}
	}
}
