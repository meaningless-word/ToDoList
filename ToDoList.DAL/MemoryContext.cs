using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using ToDoList.Entities;

namespace ToDoList.DAL
{
	public class MemoryContext
	{
		private string fileLocation;

		public List<Job> jobs { get; set; }
		public MemoryContext(string filePath)
		{
			fileLocation = filePath;
			jobs = new List<Job>();

			if (File.Exists(fileLocation))
			{
				using (StreamReader r = new StreamReader(fileLocation))
				{
					string json = r.ReadToEnd();
					jobs = JsonConvert.DeserializeObject<List<Job>>(json);
				}
			}
		}
	}
}
