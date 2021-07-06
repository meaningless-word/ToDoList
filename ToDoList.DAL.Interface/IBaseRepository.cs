using System;

namespace ToDoList.DAL.Interface
{
	public interface IBaseRepository : IDisposable
	{
		IJobDAO jobDAO { get; }
		void Save();
	}
}
