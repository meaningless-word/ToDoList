using System.Collections.Generic;
using System.Linq;
using ToDoList.DAL.Common;
using ToDoList.DAL.Entities;

namespace ToDoList.DAL.Memory
{
    /// <summary>
    /// Объект под список задач
    /// </summary>
    public class ToDoListMemory : IToDoListDAO
    {
        /// <summary>
        /// Создание задачи в листе
        /// </summary>
        /// <param name="toDoListEntity">Сущность пользователя</param>
        public int Create(Job toDoListEntity)
        {
            toDoListEntity.Id = GetLastId() + 1;
            toDoListEntity.Checked = false;

            ToDoListDAO.toDoList.Add(toDoListEntity);

            return toDoListEntity.Id;
        }

        /// <summary>
        /// Удаление задачи в листе по id
        /// </summary>
        /// <param name="id">Id задачи</param>
        public int Delete(int id)
        {
            ToDoListDAO.toDoList.Remove(GetById(id));

            return id;
        }

        /// <summary>
        /// Возврат списка задач
        /// </summary>
        /// <returns>Список задач</returns>
        public IEnumerable<Job> GetAll()
        {
            return ToDoListDAO.toDoList.ToList();
        }

        /// <summary>
        /// Получение задачи по имени
        /// </summary>
        /// <param name="name">Имя задачи</param>
        /// <returns>Задача</returns>
        public Job GetByName(string name)
        {
            return ToDoListDAO.toDoList.FirstOrDefault(item => item.Name == name);
        }

        /// <summary>
        /// Выставляет признак исполнения задачи
        /// </summary>
        /// <param name="id">Id задачи</param>
        /// <param name="check">Признак исполнения задачи</param>
        public int CheckItem(int id, bool check)
        {
            var item = GetById(id);

            item.Checked = check;

            return id;
        }

        /// <summary>
        /// Получение задачи по Id
        /// </summary>
        /// <param name="id">Имя задачи</param>
        /// <returns>Задача</returns>
        public Job GetById(int id)
        {
            return ToDoListDAO.toDoList.FirstOrDefault(item => item.Id == id);
        }

        /// <summary>
        /// Получение последней в списке задачи
        /// </summary>
        /// <returns>Номер последней задачи в списке</returns>
        private int GetLastId()
        {
            return (ToDoListDAO.toDoList.Count == 0) ? 0 : ToDoListDAO.toDoList.Max(item => item.Id);
        }
	}
}
