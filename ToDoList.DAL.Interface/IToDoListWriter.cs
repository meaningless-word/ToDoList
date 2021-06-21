using System.Threading.Tasks;

namespace ToDoList.DAL.Interface
{
	/// <summary>
	/// Интерфейс для райтера в слое данных
	/// </summary>
	public interface IToDoListWriter
	{
		/// <summary>
		/// Считывание списка задач из файла
		/// </summary>
		public Task GetAllFromFile(string jsonPath);

		/// <summary>
		/// Записывание списка задач в файл
		/// </summary>
		public Task SetAllToFile(string jsonPath);
	}
}
