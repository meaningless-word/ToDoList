using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DAL.Interface;

namespace ToDoList.DAL
{
	public class MemoryBaseRepository : IBaseRepository
	{
		private MemoryContext db;
		private MemoryJobDAO _jobDAO;

		public IJobDAO jobDAO { get => _jobDAO; }

		public MemoryBaseRepository(string baseLocation)
		{
			db = new MemoryContext(baseLocation);
			_jobDAO = new MemoryJobDAO(db);
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public void Save()
		{
			_jobDAO.Save();
		}
	}
}
