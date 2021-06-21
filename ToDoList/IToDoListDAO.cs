using System.Collections.Generic;
using ToDoList.DAL.Entities;

namespace ToDoList.DAL.Common
{
    /// <summary>
    /// Интерфейс для слоя данных списка задач
    /// </summary>
    public interface IToDoListDAO
    {
        /// <summary>
        /// Создание задачи в листе
        /// </summary>
        /// <param name="toDoListEntity">Сущность пользователя</param>
        int Create(Job toDoListEntity);

        /// <summary>
        /// Удаление задачи в листе по id
        /// </summary>
        /// <param name="id">Id задачи</param>
        int Delete(int id);

        /// <summary>
        /// Возврат списка задач
        /// </summary>
        /// <returns>Список задач</returns>
        IEnumerable<Job> GetAll();

        /// <summary>
        /// Получение задачи по имени
        /// </summary>
        /// <param name="name">Имя задачи</param>
        /// <returns>Задача</returns>
        Job GetByName(string name);

        /// <summary>
        /// Получение задачи по id
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns>Задача</returns>
        Job GetById(int id);

        /// <summary>
        /// Выставляет признак исполнения задачи
        /// </summary>
        /// <param name="id">Id задачи</param>
        /// <param name="check">Признак исполнения задачи</param>
        int CheckItem(int id, bool check);
	}
}
