using ToDoList.DAL.Interface;

namespace ToDoList.DAL
{
	public class SQLiteBaseRepository : IBaseRepository
	{
		private SQLiteContext db;
		private SQLiteJobDAO _jobDAO;
		public IJobDAO jobDAO { get => _jobDAO; }

		public SQLiteBaseRepository(string baseLocation)
		{
			db = new SQLiteContext(baseLocation);
			_jobDAO = new SQLiteJobDAO(db);
		}

		public void Save()
		{
			db.SaveChanges();
		}

		public void Dispose()
		{
			db.Dispose();
		}
	}
}
