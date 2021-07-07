using System.Collections.Generic;
using ToDoList.BLL.Entities;

namespace ToDoList.BLL.Interface
{
	/// <summary>
	/// Интерфейс для бизнес-логики списка задач
	/// </summary>
	public interface IToDoListLogic
	{
		/// <summary>
		/// Создание задачи в листе
		/// </summary>
		/// <param name="itemCreated">Вводимые пользователем параметры через UI</param>
		void Create(ItemCreated itemCreated);

		/// <summary>
		/// Удаление задачи в листе по id
		/// </summary>
		/// <param name="id">Id задачи</param>
		void Delete(int id);

		/// <summary>
		/// Возврат списка задач
		/// </summary>
		/// <returns>Список задач</returns>
		IEnumerable<ItemDelivered> GetAll();

		/// <summary>
		/// Возврат списка задач с сортировкой
		/// </summary>
		/// <param name="asc">Параметр сортировки, по умолчанию - по возрастанию</param>
		/// <returns>Отсортированный список задач</returns>
		IEnumerable<ItemDelivered> GetAllSortedByPriority(bool asc = true);

		/// <summary>
		/// Получение задачи по id
		/// </summary>
		/// <param name="id">идентификатор</param>
		/// <returns>Задача</returns>
		ItemDelivered GetById(int id);

		/// <summary>
		/// Получение задачи по имени
		/// </summary>
		/// <param name="name">Имя задачи</param>
		/// <returns>Задача</returns>
		ItemDelivered GetByName(string name);

		/// <summary>
		/// Получение задачи по фрагменту имени
		/// </summary>
		/// <param name="partOfName">часть имени задачи</param>
		/// <returns>список задач, содержащих фрагмент в наименовании</returns>
		IEnumerable<ItemDelivered> GetByPartOfName(string partOfName);

		/// <summary>
		/// Получение задачи по фрагменту текста
		/// </summary>
		/// <param name="partOfText">часть текста задачи</param>
		/// <returns>список задач, содержащих фрагмент в тексте</returns>
		IEnumerable<ItemDelivered> GetByPartOfText(string partOfText);

		/// <summary>
		/// Выставляет признак исполнения задачи
		/// </summary>
		/// <param name="id">Id задачи</param>
		/// <param name="check">Признак исполнения задачи</param>
		void CheckItem(int id, bool check);

		/// <summary>
		/// Обеспечение сохранения данных
		/// </summary>
		void Save();
	}
}
