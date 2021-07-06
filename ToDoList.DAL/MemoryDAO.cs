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
	public class MemoryDAO : IJobDAO
	{
		/// <summary>
		/// Список задач
		/// </summary>
		public List<Job> jobs;
		
		public MemoryDAO()
		{
			jobs = new List<Job>();
		}

		public int CheckItem(int id, bool check)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Считывание списка задач из файла
		/// </summary>
		public async Task Connect(string filePath)
		{
			if (File.Exists(filePath))
			{
				using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
				{
					jobs = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Job>>(fs);
				}
			}
		}

		public int Create(Job job)
		{
			throw new System.NotImplementedException();
		}

		public int Delete(int id)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Записывание списка задач в файл
		/// </summary>
		public async Task Disconnect(string filePath)
		{
			using (FileStream fs = new FileStream(filePath, FileMode.Create))
			{
				await System.Text.Json.JsonSerializer.SerializeAsync<List<Job>>(fs, jobs);
			}
		}

		public IEnumerable<Job> GetAll()
		{
			throw new System.NotImplementedException();
		}

		public Job GetById(int id)
		{
			throw new System.NotImplementedException();
		}

		public Job GetByName(string name)
		{
			throw new System.NotImplementedException();
		}
	}
}
