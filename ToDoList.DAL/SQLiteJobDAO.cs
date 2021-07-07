using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DAL.Interface;
using ToDoList.Entities;

namespace ToDoList.DAL
{
	public class SQLiteJobDAO : IJobDAO
	{
		private SQLiteContext db;

		public SQLiteJobDAO(SQLiteContext db)
		{
			this.db = db;
		}

		public int Create(Job job)
		{
			db.Jobs.Add(job);
			Save();
			return GetLastId();
		}

		public int CheckItem(int id, bool check)
		{
			Job job = GetById(id);
			job.Checked = check;
			db.Jobs.Update(job);
			Save();
			return job.Id;
		}

		public int Delete(int id)
		{
			Job job = GetById(id);
			db.Jobs.Remove(job);
			Save();
			return job.Id;
		}

		public IEnumerable<Job> GetAll()
		{
			return db.Jobs.ToList();
		}

		public Job GetById(int id)
		{
			return db.Jobs.FirstOrDefault(x => x.Id == id);
		}

		public Job GetByName(string name)
		{
			return db.Jobs.FirstOrDefault(x => x.Name == name);
		}

		private int GetLastId()
		{
			return db.Jobs.Max(x => x.Id);
		}

		public void Save()
		{
			db.SaveChanges();
		}
	}
}
