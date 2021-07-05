using System.Collections.Generic;
using ToDoList.Entities;

namespace ToDoList.DAL
{
	/// <summary>
	/// Объект под список задач
	/// </summary>
	public class MemoryDAO
	{
		/// <summary>
		/// Список задач
		/// </summary>
		public List<Job> jobs;
		
		public MemoryDAO()
		{
			jobs = new List<Job>();
		}


	}
}
