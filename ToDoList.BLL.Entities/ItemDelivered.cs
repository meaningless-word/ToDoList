using System;

namespace ToDoList.BLL.Entities
{
	public class ItemDelivered
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
		/// Дата истечения срока исполнения
		/// </summary>
		public DateTime ExpiredDate { get; set; }
	}
}
