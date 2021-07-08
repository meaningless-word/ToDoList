using System;

namespace ToDoListCommon
{
	// создаётся интерфейс для внедрения в логику
	public interface IPublicCache
	{
		T GetOrCreate<T>(string key, Func<T> func);

		void Reset(string key);
	}
}