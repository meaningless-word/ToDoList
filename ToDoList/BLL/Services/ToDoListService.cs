using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.BLL.Common;
using ToDoList.Common.Exceptions;
using ToDoList.BLL.Models;
using ToDoList.DAL.Common;
using ToDoList.DAL.Entities;
using System.Threading.Tasks;

namespace ToDoList.BLL.Services
{
    /// <summary>
    /// Бизнес-логика списка задач
    /// </summary>
    public class ToDoListService : IToDoListBLL, IToDoListBLLWriter
    {
        /// <summary>
        /// Интерфейс списка задач
        /// </summary>
        private readonly IToDoListDAO _toDoListDAL;

        /// <summary>
        /// Интерфейс райтера списка задач
        /// </summary>
        private readonly IToDoListWriter _toDoListWriter;

        /// <summary>
        /// Конструктор бизнес-логики
        /// </summary>
        /// <param name="toDoListDAL">Интерфейс списка задач</param>
        /// <param name="toDoListWriter">Интерфейс райтера списка задач</param>
        public ToDoListService(IToDoListDAO toDoListDAL, IToDoListWriter toDoListWriter)
        {
            _toDoListDAL = toDoListDAL;
            _toDoListWriter = toDoListWriter;
        }

        /// <summary>
        /// Создание задачи в листе
        /// </summary>
        /// <param name="itemCreation">Вводимые пользователем параметры через UI</param>
        public void Create(ItemCreation itemCreation)
        {
            if (String.IsNullOrEmpty(itemCreation.Name))
                throw new PropertyIsNotValid();

            if (String.IsNullOrEmpty(itemCreation.Text))
                throw new PropertyIsNotValid();

            if (itemCreation.Priority < 0)
                throw new PropertyIsNotValid();

            var toDoListEntity = new ToDoListEntity()
            {
                Name = itemCreation.Name,
                Text = itemCreation.Text,
                Priority = itemCreation.Priority
            };

            if (_toDoListDAL.Create(toDoListEntity) == 0)
                throw new Exception();
        }

        /// <summary>
        /// Удаление задачи в листе по id
        /// </summary>
        /// <param name="id">Id задачи</param>
        public void Delete(int id)
        {
            if (!CheckId(id))
                throw new InfoIsNotValid();

            if (_toDoListDAL.Delete(id) == 0)
                throw new Exception();
        }

        /// <summary>
        /// Возврат списка задач
        /// </summary>
        /// <returns>Список задач</returns>
        public IEnumerable<ToDoListEntity> GetAll()
        {
            return _toDoListDAL.GetAll();
        }

        /// <summary>
        /// Возврат списка задач с сортировкой
        /// </summary>
        /// <param name="asc">Параметр сортировки, по умолчанию - по возрастанию</param>
        /// <returns>Отсортированный список задач</returns>
        public IEnumerable<ToDoListEntity> GetAllSortedByPriority(bool asc = true)
        {
            if (asc)
                return GetAll().OrderBy(item => item.Priority);

            return GetAll().OrderByDescending(item => item.Priority);
        }

        /// <summary>
        /// Получение задачи по имени
        /// </summary>
        /// <param name="name">Имя задачи</param>
        /// <returns>Задача</returns>
        public ToDoListEntity GetByName(string name)
        {
            var item = _toDoListDAL.GetByName(name);

            if (item == null)
                throw new InfoIsNotValid();

            return item;
        }

        /// <summary>
        /// Выставляет признак исполнения задачи
        /// </summary>
        /// <param name="id">Id задачи</param>
        /// <param name="check">Признак исполнения задачи</param>
        public void CheckItem(int id, bool check)
        {
            if (!CheckId(id))
                throw new InfoIsNotValid();

            if (_toDoListDAL.CheckItem(id, check) == 0)
                throw new Exception();
        }

        /// <summary>
        /// Проверка существования Id в списке
        /// </summary>
        /// <param name="id">Id проверяемой задачи</param>
        /// <returns>Признак существования задачи</returns>
        private bool CheckId(int id)
        {
            var list = GetAll();

            if (id < 0 || id > list.ToList().Count)
                return false;

            return true;
        }

        /// <summary>
        /// Считывание списка задач из файла
        /// </summary>
        public async Task GetAllFromFile()
        {
            await _toDoListWriter.GetAllFromFile();
        }

        /// <summary>
        /// Записывание списка задач в файл
        /// </summary>
        public async Task SetAllToFile()
        {
            await _toDoListWriter.SetAllToFile();
        }
    }
}
