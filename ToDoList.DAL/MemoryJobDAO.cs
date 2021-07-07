using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ToDoList.DAL.Interface;
using ToDoList.Entities;

namespace ToDoList.DAL
{
	public class MemoryJobDAO : IJobDAO
	{
		/// <summary>
		/// хранилище данных
		/// </summary>
		private MemoryContext db;

		public MemoryJobDAO(MemoryContext db)
		{
			this.db = db;
		}

		/// <summary>
		/// Создание задачи в листе
		/// </summary>
		/// <param name="job">Сущность задачи</param>
		public int Create(Job job)
		{
			job.Id = GetLastId() + 1;
			job.Checked = false;
			db.jobs.Add(job);
			return job.Id;
		}

		/// <summary>
		/// Удаление задачи в листе по id
		/// </summary>
		/// <param name="id">Id задачи</param>
		public int Delete(int id)
		{
			db.jobs.Remove(GetById(id));
			return id;
		}

		/// <summary>
		/// Возврат списка задач
		/// </summary>
		/// <returns>Список задач</returns>
		public IEnumerable<Job> GetAll()
		{
			return db.jobs.ToList();
		}

		/// <summary>
		/// Получение задачи по имени
		/// </summary>
		/// <param name="name">Имя задачи</param>
		/// <returns>Задача</returns>
		public Job GetByName(string name)
		{
			return db.jobs.FirstOrDefault(item => item.Name == name);
		}

		/// <summary>
		/// Выставляет признак исполнения задачи
		/// </summary>
		/// <param name="id">Id задачи</param>
		/// <param name="check">Признак исполнения задачи</param>
		public int CheckItem(int id, bool check)
		{
			var item = GetById(id);
			item.Checked = check;
			return id;
		}

		/// <summary>
		/// Получение задачи по Id
		/// </summary>
		/// <param name="id">Имя задачи</param>
		/// <returns>Задача</returns>
		public Job GetById(int id)
		{
			return db.jobs.FirstOrDefault(item => item.Id == id);
		}

		/// <summary>
		/// Получение последней в списке задачи
		/// </summary>
		/// <returns>Номер последней задачи в списке</returns>
		private int GetLastId()
		{
			return (db.jobs.Count == 0) ? 0 : db.jobs.Max(item => item.Id);
		}

		/// <summary>
		/// Обеспечение сохранения данных
		/// </summary>
		public void Save()
		{
			using (StreamWriter sw = new StreamWriter(db.fileLocation))
			{
				string json = JsonConvert.SerializeObject(db.jobs, Formatting.Indented);
				sw.Write(json);
			}
		}
	}
}
