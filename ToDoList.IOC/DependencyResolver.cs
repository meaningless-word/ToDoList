using System;
using System.IO;
using ToDoList.BLL;
using ToDoList.BLL.Interface;
using ToDoList.DAL;
using ToDoList.DAL.Interface;
using ToDoList.Entities.Configuration;
using ToDoListCommon;

namespace ToDoList.IOC
{
	/// <summary>
	/// Объект для создания бизнес-логики
	/// </summary>
	public class DependencyResolver
	{
		private IBaseRepository baseRepository;
		public IPublicCache _publicCache;

		/// <summary>
		/// Объект под бизнес-логику
		/// </summary>
		public IToDoListLogic toDoListLogic { get; } 
		
		public DependencyResolver(ConfigurationDAL configurationDAL)
		{
			baseRepository = GetBaseRepositoryByType(configurationDAL);
			_publicCache = new PublicCache();
			toDoListLogic = new ToDoListLogic(baseRepository.jobDAO, _publicCache);
		}

		private IBaseRepository GetBaseRepositoryByType(ConfigurationDAL configurationDAL)
		{
			string fileFullPth = Path.Combine(configurationDAL.filePath.Length == 0 ? 
				Directory.GetParent(AppContext.BaseDirectory).FullName : 
				configurationDAL.filePath, configurationDAL.fileName);
			switch (configurationDAL.type)
			{
				case TypeOfDAO.SQLite:
					return new SQLiteBaseRepository(fileFullPth);
				case TypeOfDAO.JSON:
					return new MemoryBaseRepository(fileFullPth);
				default:
					throw new ArgumentException("Can't resolve type for JobDAO");
			}
		}
	}
}
