using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.BLL.Entities;
using ToDoList.BLL.Interface;
using ToDoList.DAL.Interface;
using ToDoList.Entities;
using ToDoList.Exceptions;
using ToDoListCommon;

namespace ToDoList.BLL
{
	/// <summary>
	/// Бизнес-логика списка задач
	/// </summary>
	public class ToDoListLogic : IToDoListLogic
	{
		/// <summary>
		/// Интерфейс списка задач
		/// </summary>
		private readonly IJobDAO _jobDAO;
		/// <summary>
		/// интерфейс кэширования
		/// </summary>
		private readonly IPublicCache _publicCache;

		private const string CACHE_KEY_JOB = "CACHE_KEY_JOB";

		/// <summary>
		/// Конструктор бизнес-логики
		/// </summary>
		/// <param name="toDoListDAL">Интерфейс списка задач</param>
		public ToDoListLogic(IJobDAO jobDAO, IPublicCache publicCache)
		{
			_jobDAO = jobDAO;
			_publicCache = publicCache;
		}

		/// <summary>
		/// Создание задачи в листе
		/// </summary>
		/// <param name="itemCreated">Вводимые пользователем параметры через UI</param>
		public void Create(ItemCreated itemCreated)
		{
			if (String.IsNullOrEmpty(itemCreated.Name))
				throw new PropertyIsNotValidException();

			if (String.IsNullOrEmpty(itemCreated.Text))
				throw new PropertyIsNotValidException();

			if (itemCreated.Priority < 0)
				throw new PropertyIsNotValidException();

			if (itemCreated.ExpireDate < DateTime.Now)
				throw new ExpiredDateException();

			var job = new Job()
			{
				Name = itemCreated.Name,
				Text = itemCreated.Text,
				Priority = itemCreated.Priority,
				ExpireDate = itemCreated.ExpireDate
			};

			if (_jobDAO.Create(job) == 0)
				throw new Exception();

			// после добавления записи кэш уже не свеж - зачищаем его
			_publicCache.Reset(CACHE_KEY_JOB);
		}

		/// <summary>
		/// Удаление задачи в листе по id
		/// </summary>
		/// <param name="id">Id задачи</param>
		public void Delete(int id)
		{
			if (!CheckId(id))
				throw new InfoIsNotValidException();

			if (_jobDAO.Delete(id) == 0)
				throw new Exception();

			// после удаления записи кэш уже не свеж - зачищаем его
			_publicCache.Reset(CACHE_KEY_JOB);
		}

		/// <summary>
		/// Возврат списка задач
		/// </summary>
		/// <returns>Список задач</returns>
		public IEnumerable<ItemDelivered> GetAll()
		{
			// запрос всех записей проходит через кэш. если он есть, записи будут получены из него, если нет, то сначала закэшируются, затем получены
			return _publicCache.GetOrCreate(CACHE_KEY_JOB, () => _jobDAO.GetAll())
				.Select(x => new ItemDelivered() { Id = x.Id, Name = x.Name, Text = x.Text, Priority = x.Priority, Checked = x.Checked, ExpireDate = x.ExpireDate }).ToList();
		}

		/// <summary>
		/// Возврат списка задач с сортировкой
		/// </summary>
		/// <param name="asc">Параметр сортировки, по умолчанию - по возрастанию</param>
		/// <returns>Отсортированный список задач</returns>
		public IEnumerable<ItemDelivered> GetAllSortedByPriority(bool asc = true)
		{
			if (asc)
				return GetAll().OrderBy(item => item.ExpireDate).ThenBy(item => item.Priority);

			return GetAll().OrderByDescending(item => item.ExpireDate).ThenByDescending(item => item.Priority);
		}

		/// <summary>
		/// Получение задачи по Id
		/// </summary>
		/// <param name="id">идентификтор</param>
		/// <returns>Задача</returns>
		public ItemDelivered GetById(int id)
		{
			// до кэширования запрашивалась запись непосредственно из базы через метод из DAO
			// var item = _jobDосвежAO.GetById(id);
			// теперь из всего кэша, а чтоб не повторяться - из текущего метода GetAll
			var item = GetAll().FirstOrDefault(x => x.Id == id);

			if (item == null)
				throw new InfoIsNotValidException();

			return new ItemDelivered() { Id = item.Id, Name = item.Name, Text = item.Text, Priority = item.Priority, Checked = item.Checked, ExpireDate = item.ExpireDate };
		}

		/// <summary>
		/// Получение задачи по имени
		/// </summary>
		/// <param name="name">Имя задачи</param>
		/// <returns>Задача</returns>
		public ItemDelivered GetByName(string name)
		{
			// до кэширования запрашивалась запись непосредственно из базы через метод из DAO
			// var item = _jobDAO.GetByName(name);
			// теперь из всего кэша, а чтоб не повторяться - из текущего метода GetAll
			var item = GetAll().FirstOrDefault(x => x.Name == name);

			if (item == null)
				throw new InfoIsNotValidException();

			return new ItemDelivered() { Id = item.Id, Name = item.Name, Text = item.Text, Priority = item.Priority, Checked = item.Checked, ExpireDate = item.ExpireDate };
		}

		/// <summary>
		/// Получение задачи по фрагменту имени
		/// </summary>
		/// <param name="partOfName">часть имени задачи</param>
		/// <returns>список задач, содержащих фрагмент в наименовании</returns>
		public IEnumerable<ItemDelivered> GetByPartOfName(string partOfName)
		{
			return GetAll().Where(x => x.Name.Contains(partOfName)).Select(x => new ItemDelivered() { Id = x.Id, Name = x.Name, Text = x.Text, Priority = x.Priority, Checked = x.Checked, ExpireDate = x.ExpireDate }).ToList();
		}

		/// <summary>
		/// Получение задачи по фрагменту текста
		/// </summary>
		/// <param name="partOfText">часть тексте задачи</param>
		/// <returns>список задач, содержащих фрагмент в тексте</returns>
		public IEnumerable<ItemDelivered> GetByPartOfText(string partOfText)
		{
			return GetAll().Where(x => x.Text.Contains(partOfText)).Select(x => new ItemDelivered() { Id = x.Id, Name = x.Name, Text = x.Text, Priority = x.Priority, Checked = x.Checked, ExpireDate = x.ExpireDate }).ToList();
		}

		/// <summary>
		/// Выставляет признак исполнения задачи
		/// </summary>
		/// <param name="id">Id задачи</param>
		/// <param name="check">Признак исполнения задачи</param>
		public void CheckItem(int id, bool check)
		{
			if (!CheckId(id))
				throw new InfoIsNotValidException();

			if (_jobDAO.CheckItem(id, check) == 0)
				throw new Exception();

			// после изменения записи кэш уже не свеж - зачищаем его
			_publicCache.Reset(CACHE_KEY_JOB);
		}

		/// <summary>
		/// Проверка существования Id в списке
		/// </summary>
		/// <param name="id">Id проверяемой задачи</param>
		/// <returns>Признак существования задачи</returns>
		private bool CheckId(int id)
		{
			var item = GetById(id);

			if (item == null)
				return false;

			return true;
		}

		/// <summary>
		/// Обеспечение сохранения данных
		/// </summary>
		public void Save()
		{
			_jobDAO.Save();
		}
	}
}
