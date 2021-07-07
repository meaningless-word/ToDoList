using System;

namespace ToDoList.BLL.Entities
{
	/// <summary>
	/// Вводимые параметры из UI
	/// </summary>
	public class ItemCreated
	{
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
		/// Дата истечения срока исполнения
		/// </summary>
		public DateTime ExpireDate { get; set; }
	}
}
