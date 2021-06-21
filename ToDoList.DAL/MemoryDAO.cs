using System.Collections.Generic;
using ToDoList.Entities;

namespace ToDoList.DAL
{
	/// <summary>
	/// Объект под список задач
	/// </summary>
	public static class MemoryDAO
	{
		/// <summary>
		/// Список задач
		/// </summary>
		public static List<Job> jobs = new List<Job>();
	}
}
