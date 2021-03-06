using System;

namespace ToDoList.Entities
{
	/// <summary>
	/// Сущность задачи
	/// </summary>
	public class Job
	{
		/// <summary>
		/// Id задачи
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Имя задачи
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Приоритет задачи
		/// </summary>
		public int Priority { get; set; }

		/// <summary>
		/// Описание задачи
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Признак исполнения
		/// </summary>
		public bool Checked { get; set; }

		/// <summary>
		/// Дата окончания срока выполнения задания
		/// </summary>
		public DateTime ExpireDate { get; set; }
	}
}
