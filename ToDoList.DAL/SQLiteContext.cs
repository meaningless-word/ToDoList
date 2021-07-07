using Microsoft.EntityFrameworkCore;
using ToDoList.Entities;

namespace ToDoList.DAL
{
	public class SQLiteContext : DbContext
	{
		private string fileLocation;
		/// <summary>
		/// объекты таблицы списка дел
		/// </summary>
		public DbSet<Job> Jobs { get; set; }

		public SQLiteContext(string filePath)
		{
			fileLocation = filePath;
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite($"Data Source={fileLocation}");
		}
	}
}
