using System.Collections.Generic;
using System.Linq;
using ToDoList.DAL.Interface;
using ToDoList.Entities;

namespace ToDoList.DAL
{
	/// <summary>
	/// Объект под список задач
	/// </summary>
	public class JobDAO : IJobDAO
	{
		private MemoryDAO memoryDAO;

		public JobDAO()
		{
			memoryDAO = new MemoryDAO();
		}

		/// <summary>
		/// Создание задачи в листе
		/// </summary>
		/// <param name="job">Сущность задачи</param>
		public int Create(Job job)
		{
			job.Id = GetLastId() + 1;
			job.Checked = false;

			memoryDAO.jobs.Add(job);

			return job.Id;
		}

		/// <summary>
		/// Удаление задачи в листе по id
		/// </summary>
		/// <param name="id">Id задачи</param>
		public int Delete(int id)
		{
			memoryDAO.jobs.Remove(GetById(id));

			return id;
		}

		/// <summary>
		/// Возврат списка задач
		/// </summary>
		/// <returns>Список задач</returns>
		public IEnumerable<Job> GetAll()
		{
			return memoryDAO.jobs.ToList();
		}

		/// <summary>
		/// Получение задачи по имени
		/// </summary>
		/// <param name="name">Имя задачи</param>
		/// <returns>Задача</returns>
		public Job GetByName(string name)
		{
			return memoryDAO.jobs.FirstOrDefault(item => item.Name == name);
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
			return memoryDAO.jobs.FirstOrDefault(item => item.Id == id);
		}

		/// <summary>
		/// Получение последней в списке задачи
		/// </summary>
		/// <returns>Номер последней задачи в списке</returns>
		private int GetLastId()
		{
			return (memoryDAO.jobs.Count == 0) ? 0 : memoryDAO.jobs.Max(item => item.Id);
		}
	}
}
